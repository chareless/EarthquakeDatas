namespace EarthquakeDataFormsApp
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            labelVersion.Text = "Sürüm: " + General.VERSION;
        }
    }
}
