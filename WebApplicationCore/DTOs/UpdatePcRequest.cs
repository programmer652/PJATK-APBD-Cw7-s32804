using System.ComponentModel.DataAnnotations;

namespace WebApplicationCore.DTOs;

public record UpdatePcRequest(
    [MaxLength(50),MinLength(1)] string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);