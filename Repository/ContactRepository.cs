using DataAPI;
using Microsoft.EntityFrameworkCore;
using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//namespace Repository
namespace ContactAPIRepository
{
    public class ContactRepository : Repository<Contact>,IContactRepository
    {
        private readonly ContactContext _db;

        public ContactRepository (ContactContext db): base(db)
        {
            _db = db;
        }
   

        public async Task<Contact> UpdateAsync(Contact entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Contacts.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
