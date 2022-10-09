using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace AbpProject.Web.Pages;

public class IndexModel : AbpProjectPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
