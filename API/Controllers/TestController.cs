using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Commons;
using BL.Helpers;
using BO.Models;
using DAL.Repository.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly UserHelper _userHelper;
        private readonly IUnitOfWork _uow;
        private readonly AppSettings _appSettings;
        public TestController(IOptions<AppSettings> appSettings, UserHelper userHelper, IUnitOfWork uow)
        {

            _userHelper = userHelper;

            _uow = uow;
            _appSettings = appSettings.Value;
        }
        // GET: api/Test
        [HttpGet]
        public IEnumerable<string> Get()
        {
            try
            {
                var a = _uow.GetRepository<UserEntity>().GetAll().Where(c => c.Name.Equals("thanh123"));
                return new string[] { a.Count().ToString(), "value2" };
            }
            catch (Exception e)
            {
                return new string[] { e.ToString() };
            }
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}