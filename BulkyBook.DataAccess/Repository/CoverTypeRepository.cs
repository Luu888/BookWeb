using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDBContext _context;
        public CoverTypeRepository(ApplicationDBContext context):base(context)
        {
            _context = context;
        }

        public void Update(CoverType category)
        {
            _context.CoverTypes.Update(category);
        }
    }
}
