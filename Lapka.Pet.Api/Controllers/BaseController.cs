using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Lapka.Pet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected Guid GetPrincipalId() //TODO: get id from claims
    {
        var stringId = User.FindFirstValue(ClaimTypes.NameIdentifier);

     //   if (stringId.IsNullOrEmpty())
      //  {
           // throw new UserNotFoundException();
       // }

        return Guid.Parse(stringId);
    }
    
    //TODO: get role from claims
}