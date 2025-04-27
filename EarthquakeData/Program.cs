using HtmlAgilityPack;
using System.Net;
using System.Text;
using static Data;

public class Data
{
    public int id { get; set; }
    public string Yer { get; set; }
    public string Enlem { get; set; }
    public string Boylam { get; set; }
    public string Derinlik { get; set; }
    public string Buyukluk { get; set; }
    public string Tarih { get; set; }

    public override string ToString()
    {
        return $"Tarih: {Tarih} | Enlem: {Enlem} | Boylam: {Boylam} | Derinlik: {Derinlik} | Büyüklük: {Buyukluk} | Yer: {Yer}";
    }

    public enum Source
    {
        AFAD = 1,
        Kandilli = 2
    }
}

class Program
{
    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.OutputEncoding = Encoding.UTF8;

        int count = 1;
        string urlAFAD = "https://deprem.afad.gov.tr/last-earthquakes.html";
        string urlKandilli = "http://www.koeri.boun.edu.tr/scripts/lst4.asp";
        string url = "";
        int maxCount = 10;



        Source type;

        // Kullanıcı geçerli seçim yapana kadar seçim sorulacak
        while (true)
        {
            Console.WriteLine("Veri Kaynağı Seçiniz: \n1-AFAD\n2-Kandilli");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();

            if (keyInfo.KeyChar == '1')
            {
                type = Source.AFAD;
                Console.Clear();  // Seçim yapıldığında ekran temizleniyor
                break;
            }
            else if (keyInfo.KeyChar == '2')
            {
                type = Source.Kandilli;
                Console.Clear();  // Seçim yapıldığında ekran temizleniyor
                break;
            }
            else
            {
                Console.WriteLine("Geçersiz seçim! Lütfen 1 veya 2'yi seçin.");
                Console.WriteLine("Devam etmek için ENTER'a basın...");
                Console.ReadLine();  // ENTER'a basılmasını bekler
                Console.Clear();  // Ekranı temizler ve tekrar seçim ekranını gösterir
            }
        }

        while (true)
        {

            switch (type)
            {
                case Source.AFAD:
                    url = urlAFAD;
                    break;
                case Source.Kandilli:
                    url = urlKandilli;
                    break;
                default:
                    url = "";
                    break;
            };

            List<Data> dataList = new List<Data>();
            Console.Clear();
            count = 1;

            WebClient client = new WebClient();

            string htmlContent = "";

            if (type == Source.Kandilli)
            {
                byte[] rawData = client.DownloadData(url);
                htmlContent = Encoding.GetEncoding("iso-8859-9").GetString(rawData); // DÜZGÜN çöz
            }
            else if (type == Source.AFAD)
            {
                client.Encoding = Encoding.UTF8;
                htmlContent = client.DownloadString(url);
            }

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlContent);

            if (type == Source.Kandilli)
            {
                byte[] rawData = client.DownloadData(url);
                string content = Encoding.GetEncoding("iso-8859-9").GetString(rawData);

                HtmlDocument kandilliDoc = new HtmlDocument();
                kandilliDoc.LoadHtml(content);

                var preNode = kandilliDoc.DocumentNode.SelectSingleNode("//pre");
                if (preNode != null)
                {
                    var lines = preNode.InnerText.Split("Büyüklük")[1].Split('\n', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(l => l.TrimEnd('\r'))
                                    .ToList();

                    int headerLines = 6; // İlk 6 satır başlık ve açıklama satırları
                    var selectedLines = lines.Skip(0).Take(headerLines + maxCount); // 6 başlık satırı + maxCount kadar veri

                    foreach (var line in selectedLines)
                    {
                        Console.WriteLine(line);
                    }
                }
            }


            else if (type == Source.AFAD)
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
                        dataList.Add(new Data
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

                foreach (var item in dataList.OrderBy(d => d.id))
                {
                    Console.WriteLine(item);
                }
            }

            Thread.Sleep(5000);
        }
    }
}
