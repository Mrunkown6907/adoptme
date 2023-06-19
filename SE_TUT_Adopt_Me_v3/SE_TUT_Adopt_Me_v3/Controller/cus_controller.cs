using SE_TUT_Adopt_Me_v3.Model;
using SE_TUT_Adopt_Me_v3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Controller
{
    public class cus_controller
    {
        public static customer login(String name, String password)
        {
            if (cus_repo.GetByName(name) == null || cus_repo.GetByPass(password) == null)
            {
                throw new MemberAccessException("Wrong username or password!");
            }

            return u;
        }

        public static void register(string username, string email, string gender, string password)
        {
            customer u = cus_repo.
                createUser(username, email, gender, password);
            UserRepository.addUser(u);
        }
        public static bool duplicateAccount(string email, string username)
        {
            return UserRepository.duplicateAccount(email, username);
        }
    }
}