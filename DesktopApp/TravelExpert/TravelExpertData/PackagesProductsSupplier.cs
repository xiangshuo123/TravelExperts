﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertData;

[Table("Packages_Products_Suppliers")]
[Index("PackageId", Name = "PackagesPackages_Products_Suppliers")]
[Index("ProductSupplierId", Name = "ProductSupplierId")]
[Index("ProductSupplierId", Name = "Products_SuppliersPackages_Products_Suppliers")]
[Index("PackageId", "ProductSupplierId", Name = "UQ__Packages__29CA8E95A9381CCB", IsUnique = true)]
public partial class PackagesProductsSupplier
{
    [Key]
    public int PackageProductSupplierId { get; set; }

    public int PackageId { get; set; }

    public int ProductSupplierId { get; set; }

    [ForeignKey("PackageId")]
    [InverseProperty("PackagesProductsSuppliers")]
    public virtual Package Package { get; set; } = null!;

    [ForeignKey("ProductSupplierId")]
    [InverseProperty("PackagesProductsSuppliers")]
    public virtual ProductsSupplier ProductSupplier { get; set; } = null!;
}
