using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Tekla.Structures.Model.Operations;

namespace QuickReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillCombo();
        }

        private void FillCombo()
        {
            string path = @"C:\TeklaStructures\18.0\environments\finland\template\";
            string[] dirs = Directory.GetDirectories(path);
            string[] dirFiles = Directory.GetFiles(path, "*.rpt");

            foreach (string file in dirFiles)
            {
                this.comboBox1.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            string Valinta = comboBox1.SelectedItem.ToString();
            string output_path = Environment.GetEnvironmentVariable("XS_REPORT_OUTPUT_DIRECTORY");
            
            if (!System.IO.Directory.Exists(output_path))
                System.IO.Directory.CreateDirectory(output_path);
            
            if (Operation.CreateReportFromSelected(Valinta, Valinta + ".xsr", "", "", ""))
            {
                Operation.DisplayReport(Valinta + ".xsr");
            }
        }
    }
}
