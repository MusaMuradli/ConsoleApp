namespace Console_Project.Models;

public class Medicine:BaseEntity
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedDate { get; set; }

    public Medicine(string name, int price, int categoryId, int userId)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
        UserId = userId;
        CreatedDate = DateTime.Now;

    }
}
