using DemoAPITest.Models;
using DemoAPITest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPITest.Controllers
{
    public class UserController : ApiController
    {
        private readonly IDataRepository _dataRepository;
        public UserController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/User
        public IList<User> Get()
        {
            return _dataRepository.getUsersList();
        }

        // GET: api/User/5
        public IHttpActionResult Get(int id)
        {
            var obj= _dataRepository.GetById(id);
            return Ok(obj);
        }

        // POST: api/User
        public User Post([FromBody]User user)
        {
            return _dataRepository.AddUser(user);
        }

        // PUT: api/User/5
        public User Put([FromBody]User User)
        {
            return _dataRepository.Update(User);
        }

        // DELETE: api/User/5
        public bool Delete(int id)
        {
           var obj= _dataRepository.Delete(id);
            return obj;
        }
    }
}
