using AutoMapper;
using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.CategoryRepo
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly GameStoreContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(IMapper mapper, GameStoreContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddCategory(CategoryDto model)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDto>? LoadAllCategories()
        {
            throw new NotImplementedException();
        }

        public bool RemoveCategory(int cId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(CategoryDto model)
        {
            throw new NotImplementedException();
        }
    }
}
