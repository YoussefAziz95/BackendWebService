using Application.Profiles;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain;

namespace Application.DTOs;
public class AddServiceRequest 
{ 
    public string Name { get; set;} 
    public string Code { get; set;} 
    public required string CategoryName { get; set; }    
        
 };
public record ServiceResponse(int Id, string Name, string Code, int CategoryName);
public record UpdateServiceRequest(int Id, string Name, string Code);
public record GetPaginatedService(int Id, string Name, string Code);
