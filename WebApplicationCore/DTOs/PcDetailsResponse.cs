namespace WebApplicationCore.DTOs;

public record PcDetailsResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<PcComponentResponse> Components
);