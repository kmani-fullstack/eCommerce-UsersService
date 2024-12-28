using System;

namespace eCommerce.Core.DTO;

public record AuthenticationResponse(
    Guid UserId,
    string? Email,
    string? PersonName,
    string? Gender,
    string? Token,
    bool Success
)
{
    // Default/Parameterless Constructor
    public AuthenticationResponse(): this(Guid.Empty, null, null,null, null, false)
    {
        
    }
};

