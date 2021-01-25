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
using Aritiafel.Organizations;

namespace JsonEditorV2
{
    public partial class frmFKTable : Form
    {
        public object Value { get; set; }
        private string keyColumnName;
        private string currentValue;
        private JTable fkTable;

        public frmFKTable()
        {
            InitializeComponent();
        }

        public static object Show(IWin32Window owner, string ColumnName, JTable FKTable, string FKColumnName, string currentValue)
        {
            
            frmFKTable frmFKTable = new frmFKTable();

            if (!FKTable.Loaded)
                MainForm.LoadJsonFile(FKTable);

            frmFKTable.fkTable = FKTable;
            DataTable dt = FKTable.ToDataTable();
            frmFKTable.Text = ColumnName;
            frmFKTable.keyColumnName = FKColumnName;
            frmFKTable.currentValue = currentValue;           
            frmFKTable.dgvMain.Columns.Clear();            
            frmFKTable.dgvMain.DataSource = dt;
            frmFKTable.dgvMain.Columns[FKColumnName].HeaderCell.Style.Font = 
                new Font(frmFKTable.Font, FontStyle.Bold);
            frmFKTable.dgvMain.Columns[FKColumnName].HeaderCell.Style.BackColor =
            frmFKTable.dgvMain.Columns[FKColumnName].DefaultCellStyle.BackColor = Color.Azure;
            frmFKTable.dgvMain.ClearSelection();
            
            frmFKTable.ShowDialogOrCallEvent(owner);
            return frmFKTable.Value;
        }

        public void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            Value = dgvMain.Rows[e.RowIndex].Cells[keyColumnName].Value;
            DialogResult = DialogResult.OK;
            Hide();
        }

        public void frmFKTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                Value = null;
                DialogResult = DialogResult.Cancel;
                Hide();
            }
        }

        public void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {            
            int i;
            for (i = 0; i < dgvMain.Rows.Count; i++)
            {
                if (dgvMain.Rows[i].Cells[keyColumnName].Value.ToString() == currentValue)
                {
                    dgvMain.Rows[i].Selected = true;                    
                    break;
                }
            }

            int autoHeight = dgvMain.ColumnHeadersHeight + 5;
            int autoWidth = dgvMain.RowHeadersWidth + 3;

            if (dgvMain.Rows.Count != 0)
            {
                autoHeight += dgvMain.Rows.Count * (dgvMain.Rows[0].Height + dgvMain.Rows[0].DividerHeight);
                autoWidth += dgvMain.Columns.Count * (dgvMain.Columns[0].Width + dgvMain.Columns[0].DividerWidth);
            }

            if (autoHeight < dgvMain.Height)
                dgvMain.Height = autoHeight;
            if (autoWidth < dgvMain.Width)
                dgvMain.Width = autoWidth;

            if (i != dgvMain.Rows.Count)
                dgvMain.FirstDisplayedScrollingRowIndex = i;
        }

        public void dgvMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmFKTable_KeyPress(this, e);
        }

        public void frmFKTable_Paint(object sender, PaintEventArgs e)
        {
            Left = (Owner.Width - Width) / 2 + Owner.Left;
            Top = (Owner.Height - Height) / 2 + Owner.Top;
        }

        public void dgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.Value = e.Value.ToString(fkTable.Columns[e.ColumnIndex].Type);
        }
    }
}
