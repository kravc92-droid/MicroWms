using System;
using System.Collections.Generic;
using System.Text;


namespace MicroWms.Domain.Entities;

public class ParcelLine
{
    public Guid Id { get; set; }

    public Guid ParcelId { get; set; }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
}

