namespace WebApplicationCore.DTOs;

public record ComponentResponse(
    string Code,
    string Name,
    string Description,
    ManufacturerResponse Manufacturer,
    TypeResponse Type
);