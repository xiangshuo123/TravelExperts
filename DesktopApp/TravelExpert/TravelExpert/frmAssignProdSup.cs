//Author: Jade
using Microsoft.EntityFrameworkCore;
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
    public partial class frmAssignProdSup : Form
    {
        public frmAssignProdSup()
        {
            InitializeComponent();

        }

        private void frmAssignProdSup_Load(object sender, EventArgs e)
        {
            GetProducts();
            DisplayList();
            lblSuccess.Visible = false;
        }

        private void DisplayList()
        {
            using (var context = new TravelExpertsContext())
            {
                var query = context.ProductsSuppliers
                    .Include(ps => ps.Product)
                    .Include(ps => ps.Supplier)
                    .Select(ps => new
                    {
                        ProductSupplierID = ps.ProductSupplierId,
                        ProductName = ps.Product.ProdName,
                        SupplierName = ps.Supplier.SupName
                    });

                lstProduct_Suppliers.Items.Clear();

                foreach (var item in query)
                {
                    int productSupplierID = item.ProductSupplierID;
                    string productName = item.ProductName;
                    string supplierName = item.SupplierName;


                    var listItem = $"{productSupplierID} \t\t {productName} \t\t({supplierName})";

                    var header = "ProductSupplierID \t\t Product Name \t\t Supplier Name";

                    listItem.Insert(0, header);

                    lstProduct_Suppliers.Items.Add(listItem);
                }
            }
        }

        private void GetProducts()
        {
            using (var context = new TravelExpertsContext())
            {
                List<Product> products = context.Products.OrderBy(p => p.ProdName).ToList();
                cboProducts.DataSource = products;
                cboProducts.DisplayMember = "ProdName";
                cboProducts.ValueMember = "ProductId";
            }
        }

        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducts.SelectedValue != null)
            {
                using (var context = new TravelExpertsContext())
                {
                    var selectedProduct = ((Product)cboProducts.SelectedItem).ProductId;


                    var excludedSuppliers = context.ProductsSuppliers
                                                   .Where(ps => ps.ProductId == selectedProduct)
                                                   .Select(ps => ps.SupplierId);

                    var suppliers = context.Suppliers
                                           .Where(s => !excludedSuppliers.Contains(s.SupplierId))
                                           .ToList();

                    cboSuppliers.DataSource = suppliers;
                    cboSuppliers.DisplayMember = "SupName";
                    cboSuppliers.ValueMember = "SupplierId";
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Assign " + ((Product)cboProducts.SelectedItem).ProdName + " to " + ((Supplier)cboSuppliers.SelectedItem).SupName, "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (confirm == DialogResult.OK)
            {
                using (var context = new TravelExpertsContext())
                {
                    var selectedProductId = ((Product)cboProducts.SelectedItem).ProductId;
                    var selectedSupplierId = Convert.ToInt32(cboSuppliers.SelectedValue);

                    var newProdSup = new ProductsSupplier
                    {
                        ProductId = selectedProductId,
                        SupplierId = selectedSupplierId
                    };

                    context.ProductsSuppliers.Add(newProdSup);
                    context.SaveChanges();
                }
                GetProducts();
                DisplayList();
                lblSuccess.Visible = true;
            }
        }

        private void frmAssignProdSup_Click(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;
        }
    }
}