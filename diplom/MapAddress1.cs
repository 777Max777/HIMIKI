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
    public partial class MapAddress1 : Form
    {
        private string latitude;
        private string longitude;

        public MapAddress1(string lat, string lng)
        {
            latitude = lat;
            longitude = lng;
            InitializeComponent();
        }

        private void MapAddress1_Load(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            try
            {
                this.WebBro.Navigate(new Uri(String.Format("file:///{0}/PageMap.html", curDir)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebBro.Document.GetElementById("lat").SetAttribute("value",latitude);
            WebBro.Document.GetElementById("lng").SetAttribute("value", longitude);
        }
    }
}
