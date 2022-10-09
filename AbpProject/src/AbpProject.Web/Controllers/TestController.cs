using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.Authentication;

namespace AbpProject.Web.Controllers;

public class TestController : Controller
{
    private readonly IPersonService _personService;
    private readonly IHttpContextAccessor Accessor;

    public TestController( IPersonService personService, IHttpContextAccessor accessor)
    {
        _personService=personService;
        Accessor = accessor;
    }
    public async Task<string> GetData() {
        var result=await _personService.GetAsync("qmj");
        
        return result;
        
    }

    public  async Task<DataModel> Post()
    {
        var request = Accessor.HttpContext.Request;
        var result =await  _personService.PostAsync(new DataModel { Id = 12, Name = "qmj" });
        return result;
    }
}
