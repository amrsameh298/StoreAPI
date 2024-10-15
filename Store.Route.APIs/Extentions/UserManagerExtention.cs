﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Route.APIs.Errors;
using Store.Route.Core.Entities.Identity;
using System.Security.Claims;

namespace Store.Route.APIs.Extentions
{
    public static class UserManagerExtention
    {
        public static async Task<AppUser> FindByEmailWithAddressAsync(this UserManager<AppUser> userManager, ClaimsPrincipal User)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail is null) return null;

            var user = await userManager.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == userEmail);
            if (user is null) return null;

            return user;
        }
    }
}