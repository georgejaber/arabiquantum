﻿namespace arabiquantum.Models
{
    public class User

    {
        [key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime  birthData { get; set; }
        public string  role { get; set; }

    }
}
