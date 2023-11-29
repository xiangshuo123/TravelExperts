// Author : Osaid
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
using static TravelExpert.frmAddP;

namespace TravelExpert
{
    public partial class frmAddProducts : Form
    {
        private List<string> productDetails; //list to hold product details
        public frmAddProducts()
        {
            InitializeComponent();
            productDetails = new List<string>(); //initialize the productDetails list
            LoadProducts();
        }

        public ListBox ProductListBox
        {
            get { return lbxProducts; }
        }

        //method for displaying products into listbox
        private void LoadProducts()
        {
            lbxProducts.Font = new Font("Segoe UI", 10); //sets font for consistency

            using (var context = new TravelExpertsContext())
            {
                //variable to specify products table
                var products = context.Products.ToList();

                //variable to specify which columns to display
                productDetails = products.Select(p => $"{p.ProductId,-20}\t{p.ProdName}").ToList();

                //specifies which columns to display using the previous productDetails variable
                lbxProducts.DataSource = productDetails;
            }
        }

        private void lbxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbxProducts.SelectedItem != null)
            {
                //assuming each item in the ListBox is a string representing the product details, 
                //and it's formatted as "ProductId\tProdName"
                string selectedProduct = lbxProducts.SelectedItem.ToString();
                string productId = selectedProduct.Split('\t')[0];
                string prodName = selectedProduct.Split('\t')[1];

                using (var editForm = new frmEditP(prodName, productId))
                {
                    //properly register the DataConfirmed event handler
                    editForm.DataConfirmed += EditForm_DataConfirmed;

                    editForm.ShowDialog();
                }
            }
        }

        private void EditForm_DataConfirmed(object sender, DataConfirmedEventArgs e)
        {
            string editedProductId = e.EditedProductId;
            string editedProductName = e.EditedProductName;

            //update the ListBox with the edited data
            int selectedIndex = lbxProducts.SelectedIndex;

            //ensure the selected index is valid before updating
            if (selectedIndex >= 0 && selectedIndex < productDetails.Count)
            {
                productDetails[selectedIndex] = $"{editedProductId}\t{editedProductName}";

                //reassign the updated data source to the ListBox
                lbxProducts.DataSource = null;
                lbxProducts.DataSource = productDetails;

                //refresh the ListBox to display the updated data
                lbxProducts.Refresh();

                int productId = int.Parse(editedProductId);
                //update the database using Entity Framework
                using (var context = new TravelExpertsContext())
                {
                    var product = context.Products.Find(productId);
                    if (product != null)
                    {
                        //update the properties with new values
                        product.ProdName = editedProductName;

                        //save changes to the database
                        context.SaveChanges();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //create an instance of frmAddP
            using (var addProductsForm = new frmAddP())
            {
                //subscribe to the custom event
                addProductsForm.NewProductAdded += AddProductsForm_NewProductAdded;

                addProductsForm.ShowDialog();
            }
        }

        //event handler to update the ListBox when a new product is added
        private void AddProductsForm_NewProductAdded(object sender, NewProductEventArgs e)
        {
            //gets the new product from the event args
            Product newProduct = e.NewProduct;

            //adds the new product to the productDetails list in the desired format
            productDetails.Add($"{newProduct.ProductId,-20}\t{newProduct.ProdName}");

            //reassigns the updated data source to the ListBox
            lbxProducts.DataSource = null;
            lbxProducts.DataSource = productDetails;

            //refreshes the ListBox to display the updated data
            lbxProducts.Refresh();

            ////adds the new product to the database
            //using (var context = new TravelExpertsContext())
            //{
            //    context.Products.Add(newProduct);
            //    context.SaveChanges();
            //}
        }
    }
}