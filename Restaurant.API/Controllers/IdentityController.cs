using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Users.Commands;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class IdentityController( IMediator mediatr) : ControllerBase
    {
        [HttpPatch("user")]
        [Authorize]
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
        {
            await mediatr.Send(command);
            return NoContent();
        }

    }
}
