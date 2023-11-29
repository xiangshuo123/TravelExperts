// Author : Andrew
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TravelExpertData;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace TravelExpert
{
    public partial class frmAddModifySuppliers : Form
    {
        public bool isAdd;
        public Supplier? supplier;

        public frmAddModifySuppliers()
        {
            InitializeComponent();
        }

        private void frmAddModifySuppliers_Load(object sender, EventArgs e)
        {
            //if the modify button was clicked
            if (isAdd == false)
            {
                DisplaySupplier();
                txtSupID.ReadOnly = true;
                this.Text = "Modify Supplier";
                lblTitle.Text = "Modify Supplier Data";
            }
            else
            {
                this.Text = "Add Supplier";
                lblTitle.Text = "Add Supplier";
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtSupID) &&
                Validator.IsPresent(txtSupName)
                )
            {
                if (isAdd) //add
                {
                    supplier = new Supplier();
                }
                //always put data into the supplier object
                if (supplier != null)
                {

                    supplier.SupName = txtSupName.Text;

                    //only take product code if it is a new supplier
                    if (isAdd)
                    {
                        supplier.SupplierId = Convert.ToInt32(txtSupID.Text);
                    }
                }
                this.DialogResult = DialogResult.OK; // closes the form
            }
        }

        private void DisplaySupplier()
        {
            if (supplier != null)
            {
                txtSupID.Text = supplier.SupplierId.ToString();
                txtSupName.Text = supplier.SupName;
            }
        }
    }
}
