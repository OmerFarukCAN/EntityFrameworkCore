using System;
using System.Collections.Generic;

namespace DatabaseFirst.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public float Price { get; set; }
}
