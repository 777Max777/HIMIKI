using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplom
{
    public partial class MapMarker : Form
    {
        private string lat;
        private string lng;

        public string Lng
        {

            get
            {
                return lng;
            }
            set
            {
                lng = value;
            }
        }
        public string Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
            }
        }
        public MapMarker()
        {
            InitializeComponent();
        }

        private void MapMarker_Load(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            try
            {
                this.WebBro.Navigate(new Uri(String.Format("file:///{0}/PageMarker.html", curDir)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void MapMarker_FormClosing(object sender, FormClosingEventArgs e)
        {
            lat= WebBro.Document.GetElementById("lat").GetAttribute("value");
            lng = WebBro.Document.GetElementById("lng").GetAttribute("value");
        }
    }
}
