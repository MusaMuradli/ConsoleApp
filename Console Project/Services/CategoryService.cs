using Console_Project.Models;
using System.Data.Common;

namespace Console_Project.Services;

public class CategoryService
{
    public void CreateCategory(Category category)
    {
        Array.Resize(ref DB.Categories, DB.Categories.Length + 1);
        DB.Categories[DB.Categories.Length-1] = category;
    }
    public void GetAllCategories()
    {
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine("Movcud olan kategorialar");
        Console.ResetColor();
        foreach (var category in DB.Categories)
        {   
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine($"{category.Id}) {category.Name}");
            Console.ResetColor();

        }
    }
    
}
