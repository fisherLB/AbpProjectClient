using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpProject
{
    //[Route("api/Person")]
    public class PersonService:ApplicationService, IPersonService
    {
        private readonly IHttpContextAccessor Accessor;
        private readonly ILogger<PersonService> _logger;
        public PersonService(IHttpContextAccessor accessor,ILogger<PersonService> logger)
        {
            Accessor = accessor;
            _logger= logger;
        }
        /// <summary>
        /// 获取get
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        [HttpGet("get")]
        public Task<List<Person>> GetAsync()
        {
           var result=new List<Person>();
            result.Add(new Person { Id=1,Name="周文王"});
            result.Add(new Person { Id = 2, Name = "周公" });

            return Task.FromResult(result);
        }

        [HttpPost("post")]   
        public async Task<Person> PostAsync([FromBody] Person mode)
        {

            var request = Accessor.HttpContext.Request;
            return await Task.FromResult(mode);
        }
    }

  
}
