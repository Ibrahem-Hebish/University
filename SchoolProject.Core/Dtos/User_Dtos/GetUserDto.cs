﻿namespace UniversityProject.Core.Dtos.User_Dtos;

public class GetUserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Country { get; set; }
    public string Email { get; set; }
}
