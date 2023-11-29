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

namespace TravelExpert
{
    public partial class frmAddP : Form
    {
        public event EventHandler<NewProductEventArgs> NewProductAdded;
        public frmAddP()
        {
            InitializeComponent();
            //changes form title
            this.Text = "Add Products";
        }

        private void frmAddP_Load(object sender, EventArgs e)
        {

        }

        public class NewProductEventArgs : EventArgs
        {
            public Product NewProduct { get; }

            public NewProductEventArgs(Product newProduct)
            {
                NewProduct = newProduct;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {   //specifies textBox2 as newProdName
            string newProdName = textBox2.Text.Trim();

            //checks if ProdName has been entered
            if (!string.IsNullOrWhiteSpace(newProdName))
            {
                //creates new or edited ProdName by referring to newProdName
                Product newProduct = new Product
                {
                    ProdName = newProdName
                };

                //saves newProdName to database
                using (var context = new TravelExpertsContext())
                {
                    context.Products.Add(newProduct);
                    context.SaveChanges();
                }

                //invokes NewProductAdded
                NewProductAdded?.Invoke(this, new NewProductEventArgs(newProduct));

                //refreshes textBox2 after everything is executed
                textBox2.Clear();
                this.Close();
            }
            else
            {
                //error message if product name is not filled
                MessageBox.Show("Product Name is mandatory.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
