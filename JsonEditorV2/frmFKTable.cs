using Aritiafel.Organizations;
using JsonEditor;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

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
                if(!MainForm.LoadOrScanJsonFile(FKTable))
                    return null;

            Var.LockDgvMain = true;

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
            frmFKTable.dgvMain.Columns[FKColumnName].DisplayIndex = 0;
            Var.LockDgvMain = false;
            frmFKTable.ShowDialogOrCallEvent(owner);
            return frmFKTable.Value;
        }

        public void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            Value = dgvMain.Rows[e.RowIndex].Cells[keyColumnName].Value;
            DialogResult = DialogResult.OK;
        }

        public void frmFKTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                Value = null;
                DialogResult = DialogResult.Cancel;
            }
            else if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Value = dgvMain.SelectedRows[0].Cells[keyColumnName].Value;
                DialogResult = DialogResult.OK;
            }
        }

        public void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (Var.LockDgvMain)
                return;
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
            autoHeight += dgvMain.Rows.Count * (dgvMain.Rows[0].Height + dgvMain.Rows[0].DividerHeight);

            if (i != dgvMain.Rows.Count)
                dgvMain.FirstDisplayedScrollingRowIndex = i;

            int autoWidth = 3;
            for (i = 0; i < dgvMain.Columns.Count; i++)
                autoWidth += dgvMain.Columns[i].Width + dgvMain.Columns[i].DividerWidth;

            if (autoHeight < dgvMain.Height)
                dgvMain.Height = autoHeight;
            if (autoWidth < dgvMain.Width)
                dgvMain.Width = autoWidth;
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
            if(e.Value != DBNull.Value)
                e.Value = e.Value.ToString(fkTable.Columns[e.ColumnIndex].Type);
            else
            {
                e.Value = "(null)";
                e.CellStyle.Font = new Font(Font, FontStyle.Italic);
            }
        }
    }
}
