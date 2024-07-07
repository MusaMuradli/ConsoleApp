using System.Xml.Linq;

namespace Console_Project.Models;

public class Category:BaseEntity
{
    private static int _id;
    public string Name { get; set; }
    public override string ToString()
    {
        return  $"Category :{Id}.{Name}";
    }
    public Category()
    {
        Id = ++_id;
    }
}


