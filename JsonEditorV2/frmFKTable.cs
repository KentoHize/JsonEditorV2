using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonEditor;

namespace JsonEditorV2
{
    public partial class frmFKTable : Form
    {
        public object Value { get; set; }
        private string keyColumnName;
        private string currentValue;

        public frmFKTable()
        {
            InitializeComponent();
        }

        public static object Show(JTable FKTable, string ColumnName, string currentValue)
        {            
            frmFKTable frmFKTable = new frmFKTable();
            frmFKTable.keyColumnName = ColumnName;
            frmFKTable.currentValue = currentValue;

            if (!FKTable.Loaded)
                MainForm.LoadJsonFile(FKTable);

            frmFKTable.dgvMain.Columns.Clear();            
            frmFKTable.dgvMain.AutoGenerateColumns = true;
            frmFKTable.dgvMain.DataSource = FKTable.ToDataTable();
            frmFKTable.dgvMain.ClearSelection();
            

            frmFKTable.ShowDialog();
            return frmFKTable.Value;
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            Value = dgvMain.Rows[e.RowIndex].Cells[keyColumnName].Value;
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void frmFKTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                Value = null;
                DialogResult = DialogResult.Cancel;
                Hide();
            }
        }

        private void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvMain.Rows.Count; i++)
            {
                if (dgvMain.Rows[i].Cells[keyColumnName].Value.ToString() == currentValue)
                {
                    dgvMain.Rows[i].Selected = true;
                    dgvMain.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }
    }
}
