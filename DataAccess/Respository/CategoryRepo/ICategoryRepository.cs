using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.CategoryRepo
{
    public interface ICategoryRepository
    {
        List<CategoryDto>? LoadAllCategories();
        bool AddCategory(CategoryDto model);
        bool UpdateCategory(CategoryDto model);
        bool RemoveCategory(int cId);
    }
}
