using System;
using System.Collections.Generic;
using System.Text;
using MicroWms.Domain.Enums;
using TaskStatus = MicroWms.Domain.Enums.TaskStatus;

namespace MicroWms.Domain.Entities;

public class WarehouseTask
{
    public Guid Id { get; set; }

    public TaskType Type { get; set; }

    public TaskStatus Status { get; set; } = TaskStatus.Created;

    public Guid? BoxId { get; set; }

    public Guid? ParcelId { get; set; }

    public Guid? SorterOutputId { get; set; }

    public int? Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? StartedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public string? ErrorMessage { get; set; }
}

