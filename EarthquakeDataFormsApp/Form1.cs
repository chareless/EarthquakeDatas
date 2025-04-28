using HtmlAgilityPack;
using System.Net;
using System.Text;

namespace EarthquakeDataFormsApp
{
    public partial class Form1 : Form
    {
        static string urlAFAD = "https://deprem.afad.gov.tr/last-earthquakes.html";
        static string urlKandilli = "http://www.koeri.boun.edu.tr/scripts/lst4.asp";

        static string url = "";
        static string urlHolder = "";
        static int maxCount;
        static int timeCount;
        static int remainingSeconds;

        public Form1()
        {
            InitializeComponent();
            SetDefault();
            GetData();
        }

        private void SetDefault()
        {
            maxCount = General.DEFAULTMAXCOUNT;
            timeCount = General.DEFAULTTMER;
            url = General.DEFAULTURL;
            urlHolder = General.DEFAULTURL;
            remainingSeconds = timeCount;
            timer1.Interval = 1000;
            textBoxTimer.Text = General.DEFAULTTMER.ToString();
            textBoxCount.Text = General.DEFAULTMAXCOUNT.ToString();
            timerLabel.Text = $"Gelen Veri: {remainingSeconds} Saniye";
        }

        private void GetData()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            try
            {
                if (url == urlKandilli)
                {
                    GetKandilliData();
                }
                else if (url == urlAFAD)
                {
                    GetAFADData();
                }
            }
            catch (Exception e)
            {
                StopTimer();
                MessageBox.Show($"{e.Message}", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;

            if (remainingSeconds <= 0)
            {
                GetData();
                remainingSeconds = timeCount;
            }

            timerLabel.Text = $"Gelen Veri: {remainingSeconds} Saniye";
        }

        private void buttonDatas_Click(object sender, EventArgs e)
        {
            ActivateChanges();
        }

        private void GetAFADData()
        {
            List<InfoDataAfad> dataListAfad = new List<InfoDataAfad>();
            WebClient client = new WebClient();

            string htmlContent = "";
            client.Encoding = Encoding.UTF8;
            htmlContent = client.DownloadString(url);

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlContent);

            for (int i = 1; i <= maxCount; i++)
            {
                string xpathPrefix = $"/html/body/div[2]/table/tbody/tr[{i}]";
                var tarihNode = document.DocumentNode.SelectSingleNode($"{xpathPrefix}/td[1]");
                var enlemNode = document.DocumentNode.SelectSingleNode($"{xpathPrefix}/td[2]");
                var boylamNode = document.DocumentNode.SelectSingleNode($"{xpathPrefix}/td[3]");
                var derinlikNode = document.DocumentNode.SelectSingleNode($"{xpathPrefix}/td[4]");
                var buyuklukNode = document.DocumentNode.SelectSingleNode($"{xpathPrefix}/td[6]");
                var yerNode = document.DocumentNode.SelectSingleNode($"{xpathPrefix}/td[7]");

                if (tarihNode != null && buyuklukNode != null && yerNode != null && enlemNode != null && boylamNode != null && derinlikNode != null)
                {
                    dataListAfad.Add(new InfoDataAfad
                    {
                        Tarih = tarihNode.InnerText.Trim(),
                        Enlem = enlemNode.InnerText.Trim(),
                        Boylam = boylamNode.InnerText.Trim(),
                        Derinlik = derinlikNode.InnerText.Trim(),
                        Buyukluk = buyuklukNode.InnerText.Trim(),
                        Yer = yerNode.InnerText.Trim()
                    });
                }
            }

            dataGridView1.DataSource = dataListAfad;

            var allCellsColumns = new[] { "Tarih", "Enlem", "Boylam", "Derinlik", "Buyukluk", };
            foreach (var colName in allCellsColumns)
            {
                if (dataGridView1.Columns[colName] != null)
                    dataGridView1.Columns[colName].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (dataGridView1.Columns["Yer"] != null)
                dataGridView1.Columns["Yer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void GetKandilliData()
        {
            List<InfoDataKandilli> dataListKandilli = new List<InfoDataKandilli>();

            WebClient client = new WebClient();

            byte[] rawData = client.DownloadData(url);
            string content = Encoding.GetEncoding("iso-8859-9").GetString(rawData);

            HtmlAgilityPack.HtmlDocument kandilliDoc = new HtmlAgilityPack.HtmlDocument();
            kandilliDoc.LoadHtml(content);

            var preNode = kandilliDoc.DocumentNode.SelectSingleNode("//pre");
            if (preNode != null)
            {
                var lines = preNode.InnerText.Split("Büyüklük")[1].Split('\n', StringSplitOptions.RemoveEmptyEntries)
                                .Select(l => l.TrimEnd('\r'))
                                .ToList();

                var selectedLines = lines.Skip(1).Take(maxCount + 2);

                int index = 0;
                foreach (var line in selectedLines)
                {
                    if (index == 0)
                    {
                        index++;
                        continue; // Ýlk satýrý atla
                    }

                    // Satýrlarý boþluklardan ayýr (birden fazla boþluk olabilir)
                    var parts = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s+");

                    if (parts.Length >= 10)
                    {
                        dataListKandilli.Add(new InfoDataKandilli
                        {
                            Tarih = parts[0],
                            Saat = parts[1],
                            Enlem = parts[2],
                            Boylam = parts[3],
                            Derinlik = parts[4],
                            MD = parts[5],
                            ML = parts[6],
                            Mw = parts[7],
                            Yer = string.Join(" ", parts.Skip(8).Take(parts.Length - 8)),
                        });
                    }
                }

                dataGridView1.DataSource = dataListKandilli;

                if (dataGridView1.Columns["Yer"] != null)
                {
                    dataGridView1.Columns["Yer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns["Yer"].MinimumWidth = 150;
                }

                var allCellsColumns = new[] { "Tarih", "Saat", "Enlem", "Boylam", "Derinlik", "MD", "ML", "Mw", "CozumNiteligi" };
                foreach (var colName in allCellsColumns)
                {
                    if (dataGridView1.Columns[colName] != null)
                        dataGridView1.Columns[colName].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void ActivateChanges()
        {
            url = urlHolder;
            maxCount = textBoxCount.Text != "" ? Int32.Parse(textBoxCount.Text) : General.DEFAULTMAXCOUNT;
            textBoxCount.Text = maxCount.ToString();
            timeCount = textBoxTimer.Text != "" ? Int32.Parse(textBoxTimer.Text) : General.DEFAULTTMER;
            textBoxTimer.Text = timeCount.ToString();
            timer1.Interval = 1000;
            remainingSeconds = timeCount;
            timerLabel.Text = $"Gelen Veri: {remainingSeconds} Saniye";
            GetData();
        }

        private void buttonTimer_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }

        private void radioButtonAfad_CheckedChanged(object sender, EventArgs e)
        {
            urlHolder = urlAFAD;
        }

        private void radioButtonKandilli_CheckedChanged(object sender, EventArgs e)
        {
            urlHolder = urlKandilli;
        }

        private void StopTimer()
        {
            timer1.Stop();
            buttonTimer.Text = "Sayacý Baþlat";
            buttonTimer.BackColor = Color.MediumSeaGreen;
        }

        private void StartTimer()
        {
            timer1.Start();
            buttonTimer.Text = "Sayacý Durdur";
            buttonTimer.BackColor = Color.LightCoral;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxCount.Text, out int value))
            {
                if (value > 500)
                {
                    MessageBox.Show("500'den büyük deðer girilemez.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxCount.Text = "500";
                    textBoxCount.SelectionStart = textBoxCount.Text.Length;
                }
                if (value < 1)
                {
                    MessageBox.Show("1'den küçük deðer girilemez.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxCount.Text = "1";
                    textBoxCount.SelectionStart = textBoxCount.Text.Length;
                }
            }
        }

        private void CheckUpdate()
        {
            try
            {
                Uri url = new Uri("https://chareless.github.io/saribayirdeniz/earthquakemonitor.html");
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
                dokuman.LoadHtml(html);
                HtmlNodeCollection titles = dokuman.DocumentNode.SelectNodes("/html/body/div/div/div[2]/div/div/div/div/div[2]/div[2]/div/div/p[5]/h7");
                string version = "";
                foreach (HtmlNode title in titles)
                {
                    version = title.InnerText;
                }

                if (version == General.VERSION)
                {
                    MessageBox.Show("Sürüm Güncel", "Güncellemeleri Denetle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Güncelleme Mevcut. Yeni Sürümü Ýndirmek Ýster Misiniz?", "Güncellemeleri Denetle",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        try
                        {
                            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = "https://github.com/chareless/EarthquakeMonitor-for-Windows/archive/master.zip",
                                UseShellExecute = true
                            };
                            System.Diagnostics.Process.Start(psi);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ýndirme sýrasýnda bir hata oluþtu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Güncel Sürüm Bulunurken Hata!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButtonContact_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://chareless.github.io/saribayirdeniz/#contact",
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Site Açýlamadý: " + ex.Message);
            }
        }

        private void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            CheckUpdate();
        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}