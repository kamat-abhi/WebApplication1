using System;
using System.Collections.Generic;

namespace WebApplication1.Models;
 
public partial class Employe
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Department { get; set; } = null!;

    public decimal Salary { get; set; }

    public string Designation { get; set; } = null!;
}
