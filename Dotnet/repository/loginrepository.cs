using System.Collections.Generic;
using Entity;
using loginmodel;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public interface IloginRepository
    {
        Task<IEnumerable<Login>> GetUser();
        Task<Login> InsertUser(Login login);
        Task<Login> UpdateUser(Login login);
        List<string> validation(Login login);
    }

    public class LoginRepository : IloginRepository
    {
        private readonly dbContex _context;

        public LoginRepository(dbContex context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Login>> GetUser()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Login> InsertUser(Login login)
        {
            _context.Users.Add(login);
            await _context.SaveChangesAsync();
            return login;
        }

        public async Task<Login> UpdateUser(Login login)
        {
            _context.Entry(login).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return login;
        }

        public List<string> validation(Login login)
        {
            List<string> error = new List<string>();
            var existing = _context.Users.FirstOrDefault(
                t => t.email.ToLower() == login.email.ToLower()
            );
            if (existing != null)
            {
                error.Add("Customer Already Exist");
            }
            return error;
        }
    }
}
