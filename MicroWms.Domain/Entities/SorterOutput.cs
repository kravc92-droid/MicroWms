using System;
using System.Collections.Generic;
using System.Text;


namespace MicroWms.Domain.Entities;

public class SorterOutput
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}

