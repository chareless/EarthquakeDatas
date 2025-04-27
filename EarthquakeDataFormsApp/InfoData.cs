using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthquakeDataFormsApp
{
    internal class InfoData
    {
        public int id { get; set; }
        public string Yer { get; set; }
        public string Enlem { get; set; }
        public string Boylam { get; set; }
        public string Derinlik { get; set; }
        public string Buyukluk { get; set; }
        public string Tarih { get; set; }

        public string ToInfoString()
        {
            return $"Tarih: {Tarih} | Enlem: {Enlem} | Boylam: {Boylam} | Derinlik: {Derinlik} | Büyüklük: {Buyukluk} | Yer: {Yer}";
        }
    }
}
