using System.Xml.Linq;

namespace Console_Project.Models;

public class Category:BaseEntity
{
    public string Name { get; set; }
    public override string ToString()
    {
        return  $"Category :{Id}.{Name}";
    }
}


