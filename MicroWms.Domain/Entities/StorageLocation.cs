using System;
using System.Collections.Generic;
using System.Text;


namespace MicroWms.Domain.Entities;

public class StorageLocation
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public bool IsOccupied { get; set; }
}

