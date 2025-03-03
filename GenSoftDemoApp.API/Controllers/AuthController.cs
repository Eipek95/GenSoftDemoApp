﻿using AutoMapper;
using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.Dto.UserDtos;
using GenSoftDemoApp.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GenSoftDemoApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IUserService _userService) : CustomBaseController
    {

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model) => ActionResultInstance(await _userService.LoginAsync(model));

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model) => ActionResultInstance(await _userService.CreateUserAsync(model));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model) => ActionResultInstance(await _userService.ChangePassword(model));

        [Authorize]
        [HttpGet()]
        public async Task<IActionResult> GetUserId() => ActionResultInstance(await _userService.GetUserId());

        
    }
}
