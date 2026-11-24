using System;
using System.Collections.Generic;
using System.Text;


namespace MicroWms.Domain.Entities;

public class Parcel
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public Guid OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public ICollection<ParcelLine> Lines { get; set; } = new List<ParcelLine>();
}

