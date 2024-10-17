global using AutoMapper;
global using FluentValidation;
global using MediatR;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using SchoolProject.Core.CQSR.Commands.AuthonticationCommands;
global using SchoolProject.Core.CQSR.Commands.EmailCommands;
global using SchoolProject.Core.CQSR.Commands.RolesCommands;
global using SchoolProject.Core.CQSR.Commands.StudentCommands;
global using SchoolProject.Core.CQSR.Commands.UserCommands;
global using SchoolProject.Core.CQSR.Queries.RoleQueries;
global using SchoolProject.Core.CQSR.Queries.StudentQueries;
global using SchoolProject.Core.CQSR.Queries.UserQueries;
global using SchoolProject.Core.Dtos.RoleDtos;
global using SchoolProject.Core.Dtos.SigningIn;
global using SchoolProject.Core.Dtos.Student_Dtos;
global using SchoolProject.Core.Dtos.User_Dtos;
global using SchoolProject.Core.Pagination;
global using SchoolProject.Core.Response;
global using SchoolProject.Data.Entities;
global using SchoolProject.Data.Helper;
global using SchoolProject.Infrustructure.Data;
global using SchoolProject.Services.AbstractionServices;
global using System.ComponentModel.DataAnnotations;
global using System.Linq.Expressions;
global using System.Net;






