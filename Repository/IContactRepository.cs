using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPIRepository
{
    public interface IContactRepository : IRepository<Contact>
    {
        
        Task<Contact> UpdateAsync(Contact entity);
       
       
    }
}
