using Activity2b.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2b.Services
{
    public class SecurityService
    {
        UsersDAO userDAO = new UsersDAO();
        public SecurityService()
        {

        }

        public bool isValid(UserModel userIn) 
        {
            return userDAO.findUserByNameAndPassword(userIn);

        }
    }
}
