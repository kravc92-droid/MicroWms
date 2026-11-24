using System;
using System.Collections.Generic;
using System.Text;


namespace MicroWms.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }

    public string Number { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public ICollection<OrderLine> Lines { get; set; } = new List<OrderLine>();
}

