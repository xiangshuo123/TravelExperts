// Author : Andrew
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
    public partial class frmSuppliers : Form
    {
        Supplier? currentSupplier = null;
        public frmSuppliers()
        {
            InitializeComponent();
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            UpdateList();

        }

        private void UpdateList()
        {
            using (var context = new TravelExpertsContext())
            {
                // Fetch data from Suppliers table
                var suppliers = context.Suppliers.ToList();

                //show newly added suppliers first
                suppliers.Reverse();

                // Prepare the data for the ListBox
                var supplierDetails = suppliers.Select(s =>
                    $"{s.SupplierId.ToString().PadRight(10)}\t\t{s.SupName}"
                ).ToList();

                // Create a header
                var header = $"{"SupplierId".PadRight(10)}\tSupplier";

                // Add the header to the top of the list
                supplierDetails.Insert(0, header);

                // Assign the data source for the ListBox
                lbxSuppliers.DataSource = supplierDetails;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifySuppliers secondForm = new frmAddModifySuppliers();
            secondForm.isAdd = true;
            secondForm.supplier = null;
            DialogResult result = secondForm.ShowDialog(); // display second form
            if (result == DialogResult.OK) // user clicked accept
            {
                currentSupplier = secondForm.supplier;
                //add product
                try
                {
                    using (TravelExpertsContext db = new())
                    {
                        if (currentSupplier != null)
                        {
                            db.Suppliers.Add(currentSupplier); // adds to the data within the app
                            db.SaveChanges(); // saves to the database

                            UpdateList();

                            lbxSuppliers.SelectedItem = currentSupplier;
                            lblEdited.Visible = false;
                            lblAdded.Visible = true;

                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error while adding supplier: " + ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbxSuppliers.SelectedIndex > 0)
            {
                frmAddModifySuppliers secondForm = new frmAddModifySuppliers();
                secondForm.isAdd = false;
                secondForm.supplier = currentSupplier;
                DialogResult result = secondForm.ShowDialog(); // displays second form
                if (result == DialogResult.OK) // user clicked accept
                {
                    //add supplier
                    try
                    {
                        using (TravelExpertsContext db = new())
                        {
                            if (secondForm.supplier != null)
                            {
                                //find current supplier 
                                int supplierID = currentSupplier.SupplierId;
                                currentSupplier = db.Suppliers.Find(supplierID);
                                if (currentSupplier != null)
                                {
                                    currentSupplier.SupplierId = secondForm.supplier.SupplierId;
                                    currentSupplier.SupName = secondForm.supplier.SupName;
                                    db.SaveChanges();

                                    UpdateList();

                                    lblEdited.Visible = true;
                                    lblAdded.Visible = false;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error while adding supplier: " + ex.Message, ex.GetType().ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a supplier");
            }
        }

        private void lbxSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxSuppliers.SelectedIndex > 0) // Exclude the header row
            {
                using (var context = new TravelExpertsContext())
                {
                    // Split the selected item using the padded length to extract the SupplierId
                    string selectedItem = lbxSuppliers.SelectedItem.ToString();
                    string supplierIdString = selectedItem.Substring(0, 10).Trim();
                    int supplierId = int.Parse(supplierIdString);


                    currentSupplier = context.Suppliers.FirstOrDefault(s => s.SupplierId == supplierId);
                }
            }
            else
            {
                currentSupplier = null; // No supplier is selected
            }
        }
    }
}
