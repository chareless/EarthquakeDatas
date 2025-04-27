using System.Net;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EarthquakeDataFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            GetData();
        }

        static string urlAFAD = "https://deprem.afad.gov.tr/last-earthquakes.html";
        static string urlKandilli = "http://www.koeri.boun.edu.tr/scripts/lst4.asp";
        static string url = urlAFAD;
        static string urlHolder = "";
        static int maxCount = 10;
        static int count = 1;
        static int timeCount = 5;

        private void radioButtonAfad_CheckedChanged(object sender, EventArgs e)
        {
            urlHolder = urlAFAD;
        }

        private void radioButtonKandilli_CheckedChanged(object sender, EventArgs e)
        {
            urlHolder = urlKandilli;
        }

        private void GetData()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            if (url != "")
            {
                List<InfoData> dataList = new List<InfoData>();
                count = 1;

                WebClient client = new WebClient();

                string htmlContent = "";

                if (url == urlKandilli)
                {
                    byte[] rawData = client.DownloadData(url);
                    htmlContent = Encoding.GetEncoding("iso-8859-9").GetString(rawData); // DÜZGÜN çöz
                }
                else if (url == urlAFAD)
                {
                    client.Encoding = Encoding.UTF8;
                    htmlContent = client.DownloadString(url);
                }

                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(htmlContent);

                if (url == urlKandilli)
                {
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

                        int headerLines = 6; // Ýlk 6 satýr baþlýk ve açýklama satýrlarý
                        var selectedLines = lines.Skip(0).Take(headerLines + maxCount); // 6 baþlýk satýrý + maxCount kadar veri

                        richTextBox1.Clear();
                        foreach (var line in selectedLines)
                        {
                            richTextBox1.Text += line + "\n";
                        }
                    }
                }


                else if (url == urlAFAD)
                {
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
                            dataList.Add(new InfoData
                            {
                                id = count++,
                                Tarih = tarihNode.InnerText.Trim(),
                                Enlem = enlemNode.InnerText.Trim(),
                                Boylam = boylamNode.InnerText.Trim(),
                                Derinlik = derinlikNode.InnerText.Trim(),
                                Buyukluk = buyuklukNode.InnerText.Trim(),
                                Yer = yerNode.InnerText.Trim()
                            });
                        }
                    }

                    richTextBox1.Clear();
                    foreach (var item in dataList.OrderBy(d => d.id))
                    {
                        richTextBox1.Text += item.ToInfoString() + "\n";
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetData();
        }

        private void buttonDatas_Click(object sender, EventArgs e)
        {
            url = urlHolder;
            maxCount = textBoxCount.Text != "" ? Int32.Parse(textBoxCount.Text) : 10;
            textBoxCount.Text = "10";
            timeCount = textBoxTimer.Text != "" ? Int32.Parse(textBoxTimer.Text) : 5;
            textBoxTimer.Text = "5";
            timer1.Interval = timeCount * 1000;
            GetData();
        }

        private void buttonTimer_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            { 
                timer1.Stop();
                buttonTimer.Text = "Sayacý Baþlat";
            }
            else
            { 
                timer1.Start();
                buttonTimer.Text = "Sayacý Durdur";
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakamlara ve kontrol karakterlerine (örneðin Backspace) izin ver
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
                    textBoxCount.SelectionStart = textBoxCount.Text.Length; // Ýmleci sona al
                }
            }
        }
    }
}
