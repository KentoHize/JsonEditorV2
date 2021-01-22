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

        public frmFKTable()
        {
            InitializeComponent();
            Width = dgvMain.Width;
            Height = dgvMain.Height;
        }

        public static object Show(JTable FKTable, string ColumnName, string currentValue)
        {            
            frmFKTable frmFKTable = new frmFKTable();
            frmFKTable.keyColumnName = ColumnName;

            if (!FKTable.Loaded)
                MainForm.LoadJsonFile(FKTable);

            frmFKTable.dgvMain.Columns.Clear();
            
            frmFKTable.dgvMain.AutoGenerateColumns = true;
            frmFKTable.dgvMain.DataSource = FKTable.ToDataTable();            
            frmFKTable.dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < frmFKTable.dgvMain.Rows.Count; i++)
                if (frmFKTable.dgvMain.Rows[i].Cells[ColumnName].Value.ToString() == currentValue)
                {   
                    frmFKTable.dgvMain.Rows[i].Selected = true;
                    break;
                }
                    
            frmFKTable.ShowDialog();
            return frmFKTable.Value;
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            Value = dgvMain.Rows[e.RowIndex].Cells[keyColumnName].Value;
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void frmInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                Value = null;
                DialogResult = DialogResult.Cancel;
                Hide();
            }
        }
    }
}
