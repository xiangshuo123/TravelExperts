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
    public partial class frmAddEditPackage : Form
    {
        private Package _package;

        public frmAddEditPackage()
        {
            InitializeComponent();
        }
        public frmAddEditPackage(Package package) // For editing an existing package
        {
            InitializeComponent();
            _package = package;
        }

        private void frmAddEditPackage_Load(object sender, EventArgs e)
        {
            if (_package != null) // If we're editing a package
            {
                // Populate the fields with the package data
                txtPkgName.Text = _package.PkgName;
                txtPkgDesc.Text = _package.PkgDesc;
                dtpPkgStartDate.Value = _package.PkgStartDate.GetValueOrDefault();
                dtpPkgEndDate.Value = _package.PkgEndDate.GetValueOrDefault();
                txtPkgBasePrice.Text = _package.PkgBasePrice.ToString();
                txtPkgAgencyCommission.Text = _package.PkgAgencyCommission.ToString();
            }
        }

        private void btnCancelPackage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtPkgName) &&
                Validator.IsPresent(txtPkgDesc) &&
                Validator.IsNonNegativeDecimal(txtPkgBasePrice) &&
                Validator.IsNonNegativeDecimal(txtPkgAgencyCommission) &&
                Validator.IsEndDateLaterThanStartDate(dtpPkgStartDate, dtpPkgEndDate) &&
                Validator.IsCommissionLessThanOrEqualToBasePrice(txtPkgBasePrice, txtPkgAgencyCommission))
            {
                using (var context = new TravelExpertsContext())
                {
                    if (_package == null) // If we're adding a new package
                    {
                        // Create a new package and add it to the context
                        var package = new Package
                        {
                            PkgName = txtPkgName.Text,
                            PkgDesc = txtPkgDesc.Text,
                            PkgStartDate = dtpPkgStartDate.Value,
                            PkgEndDate = dtpPkgEndDate.Value,
                            PkgBasePrice = decimal.Parse(txtPkgBasePrice.Text),
                            PkgAgencyCommission = decimal.Parse(txtPkgAgencyCommission.Text)
                        };

                        context.Packages.Add(package);
                    }
                    else // If we're editing a package
                    {
                        // Find the package in the context and update its properties
                        var package = context.Packages.FirstOrDefault(p => p.PackageId == _package.PackageId);
                        if (package != null)
                        {
                            package.PkgName = txtPkgName.Text;
                            package.PkgDesc = txtPkgDesc.Text;
                            package.PkgStartDate = dtpPkgStartDate.Value;
                            package.PkgEndDate = dtpPkgEndDate.Value;
                            package.PkgBasePrice = decimal.Parse(txtPkgBasePrice.Text);
                            package.PkgAgencyCommission = decimal.Parse(txtPkgAgencyCommission.Text);
                        }
                    }

                    // Save the changes and close the form
                    context.SaveChanges();
                    this.Close();
                }
            }
        }

    }
}
