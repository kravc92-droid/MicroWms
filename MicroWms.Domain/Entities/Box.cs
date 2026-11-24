using System;
using System.Collections.Generic;
using System.Text;


namespace MicroWms.Domain.Entities;

public class Box
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }

    public Guid StorageLocationId { get; set; }

    public StorageLocation StorageLocation { get; set; } = null!;
}

