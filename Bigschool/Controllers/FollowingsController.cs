using Bigschool.DTOs;
using Bigschool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bigschool.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();

        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto folowingDto)
        {

            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == folowingDto.FolloweId))
                return BadRequest("Followings already exits! ");
            var Following = new Following
            {
                FollowerId = userId,
                FolloweeId = folowingDto.FolloweId
            };
            _dbContext.Followings.Add(Following);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
