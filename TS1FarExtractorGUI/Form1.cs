using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sims.Far;
namespace TS1FarExtractorGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var folderselected = folderBrowserDialog1.SelectedPath;
            openFileDialog1.ShowDialog();
            openFileDialog1.Title = "Select the far file of The Sims";
            openFileDialog1.DefaultExt = ".far";
            folderBrowserDialog1.ShowDialog();
            var fileselected = openFileDialog1.FileName;
            var farfile = new Far(fileselected);
            foreach (var entry in farfile.Manifest.ManifestEntries)
                try
                {
                    farfile.Extract(entry.ToString());
                }
                catch
                {
                    label1.Text = "Error";
                }
            
            progressBar1.Increment(100);
            if (progressBar1.Value >= 100)
            {
                MessageBox.Show("Done!");
            }
        }
    }
}
