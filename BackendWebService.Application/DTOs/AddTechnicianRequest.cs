using Domain.Enums;
using System;

namespace Application.DTOs;

public record AddTechnicianRequest( string FirstName, string LastName, string Email, string Password, string PhoneNumber, bool MFAEnabled = false);

public record TechnicianResponse( int Id, string FirstName, string LastName, string Email, string PhoneNumber,  string Role,  DateTime? CreatedDate);

public record UpdateTechnicianRequest( int Id, string FirstName, string LastName, string Email, string PhoneNumber, string Status);
