using System;
using System.Collections.Generic;

namespace Luftborn.InfraStructure.Entity;

public partial class Products
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int AvailableAmount { get; set; }

    public decimal Cost { get; set; }
}
