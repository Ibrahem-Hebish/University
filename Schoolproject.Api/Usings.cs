global using MediatR;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Localization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Infrastructure;
global using Microsoft.AspNetCore.Mvc.Routing;
global using Microsoft.AspNetCore.RateLimiting;
global using Microsoft.Extensions.Options;
global using System.Globalization;
global using System.Net;
global using System.Threading.RateLimiting;
global using Universityproject.Api;
global using Universityproject.Api.Custom;
global using UniversityProject.Api.Routing;
global using UniversityProject.Core;
global using UniversityProject.Core.CQSR.Commands.AuthonticationCommands;
global using UniversityProject.Core.CQSR.Commands.EmailCommands;
global using UniversityProject.Core.CQSR.Commands.RolesCommands;
global using UniversityProject.Core.CQSR.Commands.StudentCommands;
global using UniversityProject.Core.CQSR.Commands.UserCommands;
global using UniversityProject.Core.CQSR.Queries.DoctorQueries;
global using UniversityProject.Core.CQSR.Queries.RoleQueries;
global using UniversityProject.Core.CQSR.Queries.StudentQueries;
global using UniversityProject.Core.CQSR.Queries.Teaching_Assistants_Quiries;
global using UniversityProject.Core.CQSR.Queries.UserQueries;
global using UniversityProject.Core.Dtos.DoctorDtos;
global using UniversityProject.Core.Dtos.CourseDtos;
global using UniversityProject.Core.Dtos.Teaching_Assistant_Dtos;
global using UniversityProject.Core.Response;
global using UniversityProject.Data.Entities;
global using UniversityProject.Infrustructure;
global using UniversityProject.Infrustructure.Seeder;
global using UniversityProject.Services;




