using System.ComponentModel;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace EarthquakeDataFormsApp
{
    internal class InfoDataKandilli
    {
        public string Yer { get; set; }
        public string Enlem { get; set; }
        public string Boylam { get; set; }
        public string Derinlik { get; set; }
        public string Tarih { get; set; }
        public string Saat { get; set; }
        public string MD { get; set; }
        public string ML { get; set; }
        public string Mw { get; set; }

        [DisplayName("Çözüm Niteliği")]
        public string CozumNiteligi { get; set; }

    }
}