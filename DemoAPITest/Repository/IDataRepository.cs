using DemoAPITest.Models;
using System.Collections.Generic;

namespace DemoAPITest.Repository
{
    public interface IDataRepository
    {
        User AddUser(User user);
        bool Delete(int Id);
        User GetById(int id);
        IList<User> getUsersList();
        User Update(User user);
    }
}