// Author: Shuo

using System;
using System.Linq;
using System.Windows.Forms;
using TravelExpertData;

namespace TravelExpert
{
    public partial class frmAddProductSupplier : Form
    {
        public frmAddProductSupplier()
        {
            InitializeComponent();
            cbxProduct.Enabled = false;
            cbxSupplier.Enabled = false;
        }

        private void frmAddProductSupplier_Load(object sender, EventArgs e)
        {
            using (var context = new TravelExpertsContext())
            {
                var packages = context.Packages.ToList();
                cbxPackage.DataSource = packages;
                cbxPackage.DisplayMember = "PkgName";
                cbxPackage.ValueMember = "PackageId";
            }
            // Once the DataSource is set, now enable the Product ComboBox
            cbxProduct.Enabled = true;
        }

        private void cbxPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new TravelExpertsContext())
            {
                var products = context.Products.ToList();
                cbxProduct.DataSource = products;
                cbxProduct.DisplayMember = "ProdName";
                cbxProduct.ValueMember = "ProductId";
            }
        }

        private void cbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProduct.SelectedItem != null)
            {
                using (var context = new TravelExpertsContext())
                {
                    var selectedProductId = ((Product)cbxProduct.SelectedItem).ProductId;
                    var suppliers = context.ProductsSuppliers
                        .Where(ps => ps.ProductId == selectedProductId)
                        .Select(ps => ps.Supplier)
                        .ToList();

                    cbxSupplier.DataSource = suppliers;
                    cbxSupplier.DisplayMember = "SupName";
                    cbxSupplier.ValueMember = "SupplierId";
                }
                // Once the DataSource is set, now enable the Supplier ComboBox
                cbxSupplier.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var context = new TravelExpertsContext())
            {
                var selectedPackageId = ((Package)cbxPackage.SelectedItem).PackageId;
                var selectedProductId = ((Product)cbxProduct.SelectedItem).ProductId;
                var selectedSupplierId = ((Supplier)cbxSupplier.SelectedItem).SupplierId;

                var productSupplier = context.ProductsSuppliers
                    .FirstOrDefault(ps => ps.ProductId == selectedProductId && ps.SupplierId == selectedSupplierId);

                if (productSupplier == null)
                {
                    MessageBox.Show("This product-supplier pair does not exist.");
                    return;
                }

                var productSupplierId = productSupplier.ProductSupplierId;

                // Check if this product-supplier pair is already assigned to this package
                var existingPair = context.PackagesProductsSuppliers
                    .FirstOrDefault(pps => pps.PackageId == selectedPackageId && pps.ProductSupplierId == productSupplierId);

                if (existingPair != null)
                {
                    MessageBox.Show("This product-supplier pair is already assigned to this package.");
                    return;
                }

                var newPackageProductSupplier = new PackagesProductsSupplier
                {
                    PackageId = selectedPackageId,
                    ProductSupplierId = productSupplierId
                };

                context.PackagesProductsSuppliers.Add(newPackageProductSupplier);
                context.SaveChanges();

                MessageBox.Show("Product-Supplier pair added successfully to the package.");
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
