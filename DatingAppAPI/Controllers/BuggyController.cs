using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DatingAppAPI.Entities;
using DatingAppAPI.Interfaces;

namespace DatingAppAPI.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuggyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        [HttpGet("auth")]
        public async Task<ActionResult<string>> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public async Task<ActionResult<AppUser>> GetNotFound()
        {
            var thing = _unitOfWork.UserRepository.GetById(-1);

            if (thing == null)
            {
                return NotFound();
            }

            return await thing;
        }

        [HttpGet("server-error")]
        public async Task<ActionResult<string>> GetServerError()
        {
            var thing = _unitOfWork.UserRepository.GetById(-1);

            var thingToReturn = thing.ToString();

            return thingToReturn;
        }

        [HttpGet("bad-request")]
        public async Task<ActionResult<string>> GetBadRequest()
        {
            return BadRequest("This was not good request");
        }
    }
}
