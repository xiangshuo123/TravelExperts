//Author: Shuo, Andrew, Jade, Osaid

using System.Linq;
using TravelExpertData;
namespace TravelExpert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lbxPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected package's name.
            var selectedPackage = lbxPackages.SelectedItem.ToString().Trim().Substring(0, 20).TrimEnd();


            using (var context = new TravelExpertsContext())
            {
                // Fetch the selected package from the database
                var package = context.Packages.FirstOrDefault(p => p.PkgName == selectedPackage);

                if (package != null)
                {
                    // Fetch the related products and suppliers from the database
                    var packageDetails = context.PackagesProductsSuppliers
                        .Where(pps => pps.PackageId == package.PackageId)
                        .Select(pps => new
                        {
                            ProductName = context.ProductsSuppliers
                                .Where(ps => ps.ProductSupplierId == pps.ProductSupplierId)
                                .Select(ps => context.Products.FirstOrDefault(p => p.ProductId == ps.ProductId).ProdName)
                                .FirstOrDefault(),

                            SupplierName = context.ProductsSuppliers
                                .Where(ps => ps.ProductSupplierId == pps.ProductSupplierId)
                                .Select(ps => context.Suppliers.FirstOrDefault(s => s.SupplierId == ps.SupplierId).SupName)
                                .FirstOrDefault()
                        })
                        .ToList();

                    // Prepare the data for lbxDetails
                    var details = packageDetails.Select(d => $"{d.ProductName,-20}\t{d.SupplierName}").ToList();

                    // Create a header
                    var header = $"{"Product",-20}\tSupplier";

                    // Add the header to the top of the list
                    details.Insert(0, header);

                    // Assign the data source for lbxDetails
                    lbxDetails.DataSource = details;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new TravelExpertsContext())
            {
                // Fetch data from Packages table
                var packages = context.Packages.ToList();

                // Prepare the data for the ListBox
                var packageDetails = packages.Select(p =>
                    $"{p.PkgName.PadRight(20)}{p.PkgStartDate.GetValueOrDefault().ToShortDateString().PadRight(15)}{p.PkgEndDate.GetValueOrDefault().ToShortDateString().PadRight(15)}{p.PkgDesc}"
                ).ToList();

                // Create a header
                var header = "Name".PadRight(20) + "Start Date".PadRight(15) + "End Date".PadRight(15) + "Description";

                // Add the header to the top of the list
                packageDetails.Insert(0, header);

                // Assign the data source for the ListBox
                lbxPackages.DataSource = packageDetails;
                lbxPackages.Font = new Font("Consolas", 10);  // make sure to use a fixed-width font
            }
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmSuppliers addModifySuppliers = new frmSuppliers();

            addModifySuppliers.ShowDialog();
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {

            frmPackages packagesForm = new frmPackages();

            packagesForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (var context = new TravelExpertsContext())
            {
                // Fetch data from Packages table
                var packages = context.Packages.ToList();

                // Prepare the data for the ListBox
                var packageDetails = packages.Select(p =>
                    $"{p.PkgName.PadRight(20)}{p.PkgStartDate.GetValueOrDefault().ToShortDateString().PadRight(15)}{p.PkgEndDate.GetValueOrDefault().ToShortDateString().PadRight(15)}{p.PkgDesc}"
                ).ToList();

                // Create a header
                var header = "Name".PadRight(20) + "Start Date".PadRight(15) + "End Date".PadRight(15) + "Description";

                // Add the header to the top of the list
                packageDetails.Insert(0, header);

                // Assign the data source for the ListBox
                lbxPackages.DataSource = packageDetails;
                lbxPackages.Font = new Font("Consolas", 10);  // make sure to use a fixed-width font
            }
        }

        private void btnPS_Click(object sender, EventArgs e)
        {
            frmAssignProdSup nextForm = new frmAssignProdSup();
            DialogResult result = nextForm.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            //displays frmAddProducts
            frmAddProducts addProductsForm = new frmAddProducts();
            addProductsForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}