using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;
using DatingAppAPI.Extensions;
using DatingAppAPI.Helpers;
using DatingAppAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppAPI.Controllers
{
    [Authorize]
    public class LikesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public LikesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("{username}")]
        public async Task<ActionResult> AddLike(string username)
        {
            var sourceUserId = User.GetUserId();
            var likedUser = await _unitOfWork.UserRepository.GetUserByUserName(username);
            var sourceUser = await _unitOfWork.LikeRepository.GetUserWithLikes(sourceUserId);

            if (likedUser == null)
            {
                return NotFound();
            }

            if (sourceUser.UserName == username)
            {
                return BadRequest("You can not like yourself.");
            }

            var userlike = await _unitOfWork.LikeRepository.GetUserLike(sourceUserId, likedUser.Id);

            if (userlike != null)
            {
                return BadRequest("You alredy liked this user.");
            }

            userlike = new UserLike
            {
                SourceUserId = sourceUserId,
                TargetUserId = likedUser.Id
            };

            sourceUser.LikedUsers.Add(userlike);

            if (await _unitOfWork.Complete())
            {
                return Ok();
            }

            return BadRequest("Failed to like user");
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<LikeDto>>> GetUserLikes([FromQuery] LikesParams likesParams)
        {
            var userId = User.GetUserId();

            likesParams.UserId = User.GetUserId();
            
            var users = await _unitOfWork.LikeRepository.GetUserLikes(likesParams);

            Response.AddPaginationHeader(new PaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages));

            return Ok(users);
        }
    }
}
