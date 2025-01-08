using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

[Table(Name = "users")]
public class User
{
    [Column(IsPrimaryKey = true, IsDbGenerated = true)]
    public int Id { get; set; }

    [Column]
    public string Username { get; set; }

    [Column]
    public string Password { get; set; }
}
