﻿namespace Domain.Models;

public class Experience
{
    public Guid Id { get; set; }
    public string Ocupation { get; set; }
    public string CompanyName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; set; }

}
