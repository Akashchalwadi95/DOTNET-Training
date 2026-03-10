using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class CustomerHist
{
    public int HistId { get; set; }

    public int? CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? City { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? OperationType { get; set; }

    public DateTime? OperationDate { get; set; }
}
