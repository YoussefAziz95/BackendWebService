using Application.Profiles;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain;

namespace BackendWebService.Application.DTOs;
public record AddServiceRequest(string Name, string Code, int CategoryId);
public record ServiceResponse(int Id, string Name, string Code, int CategoryId);
public record UpdateServiceRequest(int Id, string Name, string Code, int CategoryId);
public record GetPaginatedService(int Id, string Name, string Code);
