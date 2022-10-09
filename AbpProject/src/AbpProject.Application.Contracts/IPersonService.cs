using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpProject
{
    public interface IPersonService: IApplicationService
    {
        /// <summary>
        /// 获取get
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        Task<List<Person>> GetAsync();


        Task<Person> PostAsync(Person mode);
       
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

  
}
