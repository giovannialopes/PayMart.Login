﻿namespace PayMart.Domain.Login.Entities;

public class LoginUser
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Password { get; set; } = "";
    public string Email { get; set; } = "";

}
