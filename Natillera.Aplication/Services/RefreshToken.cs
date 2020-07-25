﻿namespace Natillera.Aplication.Services
{
    using Natillera.AplicationContract.IServices;
    using System;
    using System.Security.Cryptography;

    public class RefreshToken : IRefreshToken
    {
        public string GenerateToken()
        {
            var randomNumber = new byte[32];
            using(var randomNumberGenerator= RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }            
        }
    }
}
