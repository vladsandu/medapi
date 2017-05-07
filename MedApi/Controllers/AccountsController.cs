﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Identity.Models;
using Microsoft.AspNet.Identity;

namespace MedApi.Controllers {
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController {
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApiUser
            {
                UserName = createUserModel.Username,
                Email = createUserModel.Email,
                PersonId = createUserModel.PersonId
            };

            var addUserResult = await AppUserManager.CreateAsync(user, createUserModel.Password);

            if (!addUserResult.Succeeded)
                return GetErrorResult(addUserResult);

            var locationHeader = new Uri(Url.Link("GetUserById", new {id = user.Id}));

            return Created(locationHeader, TheModelFactory.Create(user));
        }

        [Authorize]
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result =
                await AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
                    model.NewPassword);

            if (!result.Succeeded)
                return GetErrorResult(result);

            return Ok();
        }

        [Authorize]
        [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {
            var appUser = await AppUserManager.FindByIdAsync(id);

            if (appUser != null)
            {
                var result = await AppUserManager.DeleteAsync(appUser);

                if (!result.Succeeded)
                    return GetErrorResult(result);

                return Ok();
            }

            return NotFound();
        }

        [Authorize]
        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            return Ok(AppUserManager.Users.ToList().Select(u => TheModelFactory.Create(u)));
        }

        [Authorize]
        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string Id)
        {
            var user = await AppUserManager.FindByIdAsync(Id);

            if (user != null)
                return Ok(TheModelFactory.Create(user));

            return NotFound();
        }

        [Authorize]
        [Route("user/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            var user = await AppUserManager.FindByNameAsync(username);

            if (user != null)
                return Ok(TheModelFactory.Create(user));

            return NotFound();
        }
    }
}