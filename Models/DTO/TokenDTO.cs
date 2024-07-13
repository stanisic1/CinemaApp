﻿namespace CinemaApp.Models.DTO
{
    public class TokenDTO
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Role { get; set; }
    }
}
