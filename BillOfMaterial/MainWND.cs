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

namespace BillOfMaterial {
    public partial class MainWND : Form {
        public MainWND() {
            InitializeComponent();
        }

        private DataTable partsTable = new DataTable();

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
        }
            

        private void buttonUpdate_Click(object sender, EventArgs e) {
            for (int i = 0; i < dataGridProfiles.Rows.Count - 1; i++) {
                Profile profile;
                profile = this.profileBindingSource.List[i] as Profile;
                Console.WriteLine(profile.Type);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            Console.WriteLine(assemblyName.Text.ToString());
            saveData();         
        }
    }

}
