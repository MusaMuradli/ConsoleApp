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
    
}
