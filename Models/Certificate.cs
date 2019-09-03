using rating.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBTWebAPI.Models
{
    public class Certificate
    {
        public static IEnumerable<User> GetAllUsers()
        {
            var db = new CBTWebAPIContext();
            return db.Users;
        }
    }
}