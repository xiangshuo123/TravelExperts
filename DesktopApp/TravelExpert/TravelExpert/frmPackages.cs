// Author: Shuo

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertData;

namespace TravelExpert
{
    public partial class frmPackages : Form
    {
        public frmPackages()
        {
            InitializeComponent();
        }

        private void frmPackages_Load(object sender, EventArgs e)
        {
            using (var context = new TravelExpertsContext())
            {
                // Load all packages into the ComboBox
                var packages = context.Packages.ToList();
                cmbPackageList.DataSource = packages;
                cmbPackageList.DisplayMember = "PkgName";
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Open the Add/Edit Package form for adding a new package
            frmAddEditPackage form = new frmAddEditPackage();
            form.ShowDialog();

            // Refresh the ComboBox
            frmPackages_Load(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Open the Add/Edit Package form for editing the selected package
            var selectedPackage = cmbPackageList.SelectedItem as Package;
            if (selectedPackage != null)
            {
                frmAddEditPackage form = new frmAddEditPackage(selectedPackage);
                form.ShowDialog();
            }

            // Refresh the ComboBox
            frmPackages_Load(sender, e);
        }

        private void btnPackageBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddProductSupplier_Click(object sender, EventArgs e)
        {
            frmAddProductSupplier frmAddProdSup = new frmAddProductSupplier();
            frmAddProdSup.ShowDialog();
        }
    }
}
