﻿// Global using directives

global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using FluentValidation;
global using Library.Application.Commands;
global using Library.Application.Options;
global using Library.Application.Queries;
global using Library.Application.Services;
global using Library.Application.ViewModels.Result;
global using Library.Domain.Entities;
global using Library.Infrastructure;
global using Library.WebApi.Configuration;
global using Library.Infrastructure.Base;
global using Library.WebApi.Filters.Exceptions;
global using Library.WebApi.Utils;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.ApiExplorer;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using Microsoft.AspNetCore.Mvc.Versioning;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Serilog;
global using Library.Application.Commands.Behaviors;
global using Hangfire;