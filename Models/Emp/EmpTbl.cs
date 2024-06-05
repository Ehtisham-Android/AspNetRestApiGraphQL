using System;
using System.Collections.Generic;

namespace RestApiGraphQL.Models.Emp;

public partial class EmpTbl
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public short Age { get; set; }

    public string? City { get; set; }

    public string? Email { get; set; }
}
