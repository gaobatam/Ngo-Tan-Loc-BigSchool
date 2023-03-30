using Microsoft.AspNet.Identity;
using NgoTanLoc.DTOs;
using NgoTanLoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NgoTanLoc.Controllers
{
    [Authorize]
    public class FollowingController : ApiController
    {
        private readonly ApplicationDbContext _dbcontext;
        public FollowingController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow (FollowingDTO followingDTO)
        {
            var userId = User.Identity.GetUserId();
            if (_dbcontext.Followings.Any(a => a.FollwerId == userId && a.FollweeId == followingDTO.FolloweeId))
                return BadRequest("Following already exists");

            var following = new Following
            {
                FollwerId =userId,
                FollweeId= followingDTO.FolloweeId
            };

            _dbcontext.Followings.Add(following);
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}