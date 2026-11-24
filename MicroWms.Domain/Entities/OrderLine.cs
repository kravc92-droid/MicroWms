using System;
using System.Collections.Generic;
using System.Text;


namespace MicroWms.Domain.Entities;

public class OrderLine
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
}

