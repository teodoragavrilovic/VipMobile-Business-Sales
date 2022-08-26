﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Model.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace VipAPI.Auth
{
    public class JwtAuthentication
    {
        public JwtAuthentication(UserManager<User> manager)
        {
            this.manager = manager;
        }

        private const string KEY = "NemaPristupaBezLozinke";
        private readonly UserManager<User> manager;

        public async Task<Object> AuthenticateAsync(string username, string password)
        {
            var user = await manager.FindByNameAsync(username);

            if (user == null)
            {
                return null;
            }

            if (await manager.CheckPasswordAsync(user, password))
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Name));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
                //claims.Add(new Claim(ClaimTypes.Role, user.GetType().Name));

                var roles = await manager.GetRolesAsync(user);

                claims.Add(new Claim(ClaimTypes.Role, roles.First()));

                ClaimsIdentity identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                var signInCred = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY)),
                SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddHours(1),
                    Subject = identity,
                    SigningCredentials = signInCred
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenValue = tokenHandler.WriteToken(token);
                var response = new
                {
                    token = tokenValue
                };
                return response;
            }

            return null;
        }
    }
}
