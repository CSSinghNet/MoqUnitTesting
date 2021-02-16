using DemoAPITest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPITest.Repository
{
    public class DataRepository : IDataRepository
    {
        readonly Dictionary<int, User> _user = new Dictionary<int, User>();
        public DataRepository()
        {
            _user.Add(1, new User() { Id = 1, UserName = "xyz", Role = "Admin" });
            _user.Add(2, new User() { Id = 2, UserName = "ABC", Role = "Manager" });
            _user.Add(3, new User() { Id = 3, UserName = "DEF", Role = "Client" });

        }
        public User AddUser(User user)
        {

            int newId = !getUsersList().Any() ? 1 : getUsersList().Max(x => x.Id) + 1;
            user.Id = newId;
            _user.Add(newId, user);
            return user;
        }

        public User Update(User user)
        {
            User obj = GetById(user.Id);
            if (obj == null)
                return null;
            _user[obj.Id] = user;
            return user;
        }

        public bool Delete(int Id)
        {
           var result= _user.Remove(Id);
            return result;
        }

        public User GetById(int id)
        {
            return _user.FirstOrDefault(x => x.Key == id).Value;
        }
        public IList<User> getUsersList()
        {
            return _user.Select(x => x.Value).ToList();
        }
    }
}