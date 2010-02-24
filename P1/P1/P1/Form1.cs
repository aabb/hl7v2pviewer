using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace P1
{
    public partial class Form1 : Form
    {
        private HL7v2xConformanceProfile xxx = new HL7v2xConformanceProfile();
        public Form1()
        {
            InitializeComponent();
        }

        private void fnFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.InitialDirectory = Application.CommonAppDataPath;
            openFile.Filter = "Profiile files (*.xml)|*.xml|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fullName = openFile.FileName;
                string fileName = Path.GetFileName(fullName);

                XmlSerializer serializer = new XmlSerializer(typeof(HL7v2xConformanceProfile));
                TextReader tr = new StreamReader(fullName);
                HL7v2xConformanceProfile b = (HL7v2xConformanceProfile)serializer.Deserialize(tr);
                tr.Close(); 
            }
        }

    }
}
