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

namespace TravelExpert
{
    public partial class frmEditP : Form
    {
        //constructors for edited info
        public string EditedProductId { get; private set; }
        public string EditedProductName { get; private set; }

        public event EventHandler<DataConfirmedEventArgs> DataConfirmed; //updated event declaration

        private frmAddProducts frmAddProductsInstance; //uses frmAddProductsInstance to store info

        public frmEditP()
        {
            InitializeComponent();
            //changes form title to something more appropriate
            this.Text = "Edit Products";
        }

        //fills in textboxes with appropriate data
        public frmEditP(string ProdName, string ProductId) : this()
        {
            textBox1.Text = ProductId;
            textBox2.Text = ProdName;
            //stores the frmAddProducts info
            this.frmAddProductsInstance = frmAddProductsInstance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditedProductId = textBox1.Text;
            EditedProductName = textBox2.Text;

            //trigger the custom event to confirm the data edit
            DataConfirmed?.Invoke(this, new DataConfirmedEventArgs(EditedProductId, EditedProductName));

            //closes the form
            this.Close();
        }

    }
}

public class DataConfirmedEventArgs : EventArgs
{
    public string EditedProductId { get; }
    public string EditedProductName { get; }

    public DataConfirmedEventArgs(string editedProductId, string editedProductName)
    {
        EditedProductId = editedProductId;
        EditedProductName = editedProductName;
    }
}