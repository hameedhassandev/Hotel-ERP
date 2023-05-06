﻿namespace API.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime CreatedAt { get; set; } 

    }
}
