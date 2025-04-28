using System.ComponentModel;

namespace EarthquakeDataFormsApp
{
    internal class InfoDataAfad
    {
        public string Yer { get; set; }
        public string Enlem { get; set; }
        public string Boylam { get; set; }
        public string Derinlik { get; set; }

        [DisplayName("Büyüklük")]
        public string Buyukluk { get; set; }
        public string Tarih { get; set; }

        public string ToInfoString()
        {
            return $"Tarih: {Tarih} | Enlem: {Enlem} | Boylam: {Boylam} | Derinlik: {Derinlik} | Büyüklük: {Buyukluk} | Yer: {Yer}";
        }
    }
}
