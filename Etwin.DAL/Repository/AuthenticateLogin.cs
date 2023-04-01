using EtwLogin.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EtwLogin.Repository
{
    public class AuthenticateLogin : IAuthenticateLogin
    {
        private readonly ETWLoginContext _context;
       

        public AuthenticateLogin(ETWLoginContext context)
        {
            _context = context;
            
        }
        public async Task<Operators> AuthenticateUser(string username, string passcode)
        {
            var succeeded = await _context.Operators.FirstOrDefaultAsync(authUser => authUser.Username == username && authUser.Password == passcode);
            return succeeded;
        }

        public async Task<IEnumerable<Operators>> getuser()
        {
            return await _context.Operators.ToListAsync();
        }
    }
}
