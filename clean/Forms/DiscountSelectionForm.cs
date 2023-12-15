using System;
using System.Collections.Generic;
using System.Windows.Forms;
using clean;
using clean.Models;

namespace CleaningManagementSystem
{
    public partial class DiscountSelectionForm : Form
    {
        public Discount SelectedDiscount { get; private set; }

        private ListBox lstDiscounts;
        private Button btnSelect;
        private Button btnCancel;

        public DiscountSelectionForm(List<Discount> availableDiscounts)
        {
            InitializeComponent();

            lstDiscounts.DataSource = availableDiscounts;
        }

        private void InitializeComponent()
        {
            this.lstDiscounts = new ListBox();
            this.btnSelect = new Button();
            this.btnCancel = new Button();
            
            // Initialize other form properties, such as size, location, etc.

            this.Controls.Add(lstDiscounts);
            this.Controls.Add(btnSelect);
            this.Controls.Add(btnCancel);

            btnSelect.Click += btnSelect_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectedDiscount = (Discount)lstDiscounts.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
