using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace UnzipandAlterXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "zip files (.zip)|*.zip";
            DialogResult fp = openFileDialog1.ShowDialog();
            string fn = openFileDialog1.FileName;
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename_xml = "customizations.xml";
            try
            {
                FastZip fz = new FastZip();
                
                string filename_zip = Path.GetFileNameWithoutExtension(textBox1.Text);
                string filepath_xml = Path.GetDirectoryName(textBox1.Text) + "\\" + filename_zip;
                string filepath_zip = Path.GetDirectoryName(textBox1.Text);

                fz.ExtractZip(textBox1.Text, filepath_xml, null);
                //MessageBox.Show("Unzip successful!");

                /* test values
                 * Search String = SantosSRMDev
                 * Key String = c360
                 * Replace with = //any string you need
                 * */
                XDocument xe = XDocument.Load(filepath_xml+"\\"+filename_xml);

                var qry = from atr in xe.Descendants().Attributes() where atr.Value.ToString().Contains(textBox4.Text.ToString()) select atr;
                int count = 0;
                foreach (var q in qry)
                {
                    if (q.Value.Contains(textBox2.Text.ToString()))
                    {
                        q.Value = q.Value.Replace(textBox2.Text.ToString(), textBox3.Text.ToString());//Replace the old with new string
                        count++;
                    }
                }
                //save xml
                xe.Save(filepath_xml + "/customizations.xml");
                //ceate Zip
                fz.CreateZip(filepath_zip + @"\" + filename_zip + "_new.zip", filepath_xml, true, null);
                //delete created dir
                Directory.Delete(filepath_xml, true);
                MessageBox.Show(count + " occurrences Updated and saved as '" + filename_zip + "_new.zip'");

            }
            catch
            {
                MessageBox.Show("Error Occured!");
            }
        }
    }
}
