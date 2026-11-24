using System;
using System.Collections.Generic;
using System.Text;


namespace MicroWms.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }

    public string Article { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}

