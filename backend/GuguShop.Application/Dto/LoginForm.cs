﻿namespace GuguShop.Application.Dto;

public class LoginForm
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}