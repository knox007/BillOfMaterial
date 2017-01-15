using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BillOfMaterial {
    public partial class MainWND : Form {
        public MainWND() {
            InitializeComponent();
        }

        private DataTable partsTable = new DataTable();
        private BOM.Assembly assembly = new BOM.Assembly();

       private void saveData() {
            DataRow row;
            partsTable.Clear();
            string filename = assemblyName.Text.ToString();
            partsTable.TableName = filename;
            for (int i = 0; i < dataGridProfiles.Rows.Count - 1; i++) {
                row = partsTable.NewRow();
                row["Type"] = dataGridProfiles.Rows[i].Cells[0].Value.ToString();
                row["Number"] = dataGridProfiles.Rows[i].Cells[3].Value.ToString();
                row["Length"] = dataGridProfiles.Rows[i].Cells[2].Value.ToString();
                partsTable.Rows.Add(row);
            }
            partsTable.WriteXml(filename+".xml");
        }

        private void loadData() {
            partsTable.Clear();
            string filename = assemblyName.Text.ToString();
            partsTable.ReadXml(filename + ".xml");
        }

        private void MainWND_Load(object sender, EventArgs e) {
            DataColumn dcProfileType = new DataColumn("Type");
            DataColumn dcProfileNumber = new DataColumn("Number");
            DataColumn dcProfileLength = new DataColumn("Length");
            partsTable.Columns.Add(dcProfileType);
            partsTable.Columns.Add(dcProfileNumber);
            partsTable.Columns.Add(dcProfileLength);
            assemblyNumber.Text = assembly.Number.ToString();
            assemblyName.Text = assembly.Name;
            
        }
            

        private void buttonUpdate_Click(object sender, EventArgs e) {
            this.assembly.Parts.Clear();
            for (int i = 0; i < dataGridProfiles.Rows.Count - 1; i++) {
                Profile profile;
                profile = this.profileBindingSource.List[i] as Profile;
                this.assembly.Parts.Add(profile);
            }
            double result = Math.Round(assembly.Weight, 2);
            txtAssemblyWeight.Text = result.ToString();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            Console.WriteLine(assemblyName.Text.ToString());
            saveData();         
        }

        // Assembly data
        private void assemblyNumber_TextChanged(object sender, EventArgs e) {
            int number;
            string str = assemblyNumber.Text;
            bool prased = Int32.TryParse(str, out number);
            if (prased) {
                this.assembly.Number = number;
            }
        }

        private void assemblyName_TextChanged(object sender, EventArgs e) {
            assembly.Name = assemblyName.Text;
        }

        private void assemblyNumber_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                SendKeys.Send("{TAB}");
            }
        }

        private void assemblyName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                SendKeys.Send("{TAB}");
            }
        }
    }

}
