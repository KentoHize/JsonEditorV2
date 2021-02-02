using Aritiafel.Organizations;
using JsonEditorV2.Resources;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JsonEditorV2
{
    public partial class frmChoices : Form
    {
        public List<string> ReturnValue { get; set; }

        public frmChoices()
        {
            InitializeComponent();
            btnDeleteItem.Text = Res.JE_CHOICES_DELETE_ITEM;
            btnAddItem.Text = Res.JE_CHOICES_ADD_ITEM;
            btnConfirm.Text = Res.JE_CHOICES_CONFIRM;
            Text = Res.JE_COLUMN_CHOICES;
            ReturnValue = new List<string>();
        }

        private void RefreshList()
        {
            int index = lsbItems.SelectedIndex;
            lsbItems.DataSource = null;
            lsbItems.DataSource = ReturnValue;
            if (index < lsbItems.Items.Count)
                lsbItems.SelectedIndex = index;
            else
                lsbItems.SelectedIndex = -1;
        }

        public static List<string> ShowDialog(IWin32Window owner, List<string> Items)
        {
            frmChoices frmChoices = new frmChoices();
            frmChoices.ReturnValue.AddRange(Items);
            frmChoices.lsbItems.DataSource = frmChoices.ReturnValue;
            frmChoices.ShowDialogOrCallEvent(owner);
            return frmChoices.ReturnValue;
        }

        public void btnAddItem_Click(object sender, EventArgs e)
        {   
            if (string.IsNullOrEmpty(txtItemName.Text))
                return;

            if (ReturnValue.Contains(txtItemName.Text.Trim()))
                return;
            
            ReturnValue.Add(txtItemName.Text.Trim());
            RefreshList();
            lsbItems.SelectedIndex = lsbItems.Items.Count - 1;
        }

        public void btnItemMoveUp_Click(object sender, EventArgs e)
        {
            if (lsbItems.SelectedIndex == -1 || lsbItems.SelectedIndex == 0)
                return;
            string s = ReturnValue[lsbItems.SelectedIndex - 1];
            ReturnValue[lsbItems.SelectedIndex - 1] = ReturnValue[lsbItems.SelectedIndex];
            ReturnValue[lsbItems.SelectedIndex] = s;
            RefreshList();
        }

        public void btnItemMoveDown_Click(object sender, EventArgs e)
        {
            if (lsbItems.SelectedIndex == -1 || lsbItems.SelectedIndex == lsbItems.Items.Count - 1)
                return;
            string s = ReturnValue[lsbItems.SelectedIndex + 1];
            ReturnValue[lsbItems.SelectedIndex + 1] = ReturnValue[lsbItems.SelectedIndex];
            ReturnValue[lsbItems.SelectedIndex] = s;
            RefreshList();
        }

        public void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (lsbItems.SelectedIndex == -1)
                return;
            ReturnValue.RemoveAt(lsbItems.SelectedIndex);
            RefreshList();            
        }

        public void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtItemName_Click(object sender, EventArgs e)
        {
            txtItemName.SelectAll();
        }

        private void lsbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnItemMoveUp.Enabled = lsbItems.SelectedIndex != -1 && lsbItems.SelectedIndex != 0;
            btnItemMoveDown.Enabled = lsbItems.SelectedIndex != -1 && lsbItems.SelectedIndex != lsbItems.Items.Count - 1;
            btnDeleteItem.Enabled = lsbItems.SelectedIndex != -1;
        }

        private void frmChoices_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                DialogResult = DialogResult.Cancel;
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            btnAddItem.Enabled = txtItemName.Text != "";
        }
    }
}
