﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertData;

[Index("ProductId", Name = "ProductId")]
public partial class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [StringLength(50)]
    public string ProdName { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<ProductsSupplier> ProductsSuppliers { get; set; } = new List<ProductsSupplier>();
}
