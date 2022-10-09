using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Authentication;

namespace AbpProject.Web.Controllers;

public class AccountController : ChallengeAccountController
{
    private readonly IPersonService _personService;
    public AccountController( IPersonService personService)
    {
        _personService=personService;
    }
    public IActionResult GetData() {
        var name= _personService.GetAsync("qmj");
        return Ok(name);
    }
}
