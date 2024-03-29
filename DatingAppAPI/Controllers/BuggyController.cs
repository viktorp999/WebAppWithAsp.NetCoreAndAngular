﻿using Microsoft.AspNetCore.Authorization;
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
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public async Task<ActionResult<AppUser>> GetNotFound()
        {
            string guidstring = "00000000-0000-0000-0000-000000000000";

            var guid = Guid.Parse(guidstring);

            var thing = await _unitOfWork.UserRepository.GetById(guid);

            if (thing == null)
            {
                return NotFound();
            }

            return thing;
        }

        [HttpGet("server-error")]
        public async Task<ActionResult<string>> GetServerError()
        {
            string guidstring = "00000000-0000-0000-0000-000000000000";

            var guid = Guid.Parse(guidstring);

            var thing = await _unitOfWork.UserRepository.GetById(guid);

            var thingToReturn = thing.ToString();

            return thingToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not good request");
        }
    }
}
