using AutoMapper;
using DataAccess.Dto;
using Microsoft.EntityFrameworkCore;
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


       public async Task<List<CategoryDto>>? LoadAllCategories()
        {
            try
            {
                var list = await _context.Categories.ToListAsync();
                var result = _mapper.Map<List<CategoryDto>>(list);


                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
