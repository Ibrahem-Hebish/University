global using AutoMapper;
global using FluentValidation;
global using MediatR;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using System.ComponentModel.DataAnnotations;
global using System.Linq.Expressions;
global using System.Net;
global using System.Security.Claims;
global using UniversityProject.Core.CQSR.Commands.AuthonticationCommands;
global using UniversityProject.Core.CQSR.Commands.DoctorCommands;
global using UniversityProject.Core.CQSR.Commands.EmailCommands;
global using UniversityProject.Core.CQSR.Commands.RolesCommands;
global using UniversityProject.Core.CQSR.Commands.StudentCommands;
global using UniversityProject.Core.CQSR.Commands.Teaching_Assistants_Commands;
global using UniversityProject.Core.CQSR.Commands.UserCommands;
global using UniversityProject.Core.CQSR.Queries.DoctorQueries;
global using UniversityProject.Core.CQSR.Queries.RoleQueries;
global using UniversityProject.Core.CQSR.Queries.StudentQueries;
global using UniversityProject.Core.CQSR.Queries.Teaching_Assistants_Quiries;
global using UniversityProject.Core.CQSR.Queries.UserQueries;
global using UniversityProject.Core.Dtos.CourseDtos;
global using UniversityProject.Core.Dtos.DoctorDtos;
global using UniversityProject.Core.Dtos.RoleDtos;
global using UniversityProject.Core.Dtos.SigningIn;
global using UniversityProject.Core.Dtos.Student_Dtos;
global using UniversityProject.Core.Dtos.Teaching_Assistant_Dtos;
global using UniversityProject.Core.Dtos.User_Dtos;
global using UniversityProject.Core.Pagination;
global using UniversityProject.Core.Response;
global using UniversityProject.Data.Entities;
global using UniversityProject.Data.Helper;
global using UniversityProject.Infrustructure.Data;
global using UniversityProject.Infrustructure.StudentRepositories;
global using UniversityProject.Services.AbstractionServices;








