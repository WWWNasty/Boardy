using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Abstraction.RepositoryInterfaces.Base;
using DataAccessLayer.Data.EntityFramework;
using DataAccessLayer.Implementation.Repositories.Base;
using DataAccessLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implementation.Repositories
{
    public class SubCategoryRepository: RepositoryBase<SubCategory>, ISubCategoryRepository
    {
        public override async Task<ICollection<SubCategory>> GetAllAsync()
        {
            return await DbContext.SubCategories
                .Include(subcategory => subcategory.Parent)
                .Where(subcategory => subcategory.ParentId.HasValue)
                .ToListAsync();
        }
        
        public SubCategoryRepository(BoardyDbContext dbContext) : base(dbContext)
        {
        }
    }
}
