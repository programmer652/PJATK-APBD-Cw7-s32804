using Microsoft.EntityFrameworkCore;
using WebApplicationCore.DTOs;
using WebApplicationCore.Exceptions;
using WebApplicationCore.Infrastructure;
using WebApplicationCore.Models;

namespace WebApplicationCore.Services;

public class PcService(AppDbContext ctx) : IPcService
{
    public async Task<IEnumerable<PcResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(pc => new PcResponse(
             pc.Id,
             pc.Name,
             pc.Weight,
             pc.Warranty,
             pc.CreatedAt,
             pc.Stock
        )).ToListAsync(cancellationToken);
    }

    public async Task<PcDetailsResponse?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs
            .Where(pc => pc.Id == id)
            .Select(pc => new PcDetailsResponse(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock,
                pc.PCComponents.Select(pcc => new PcComponentResponse(
                    pcc.Amount,
                    new ComponentResponse(
                        pcc.Component.Code,
                        pcc.Component.Name,
                        pcc.Component.Description,
                        new ManufacturerResponse(
                            pcc.Component.ComponentManufacturer.Id,
                            pcc.Component.ComponentManufacturer.Abbreviation,
                            pcc.Component.ComponentManufacturer.FullName,
                            pcc.Component.ComponentManufacturer.FoundationDate
                        ),
                        new TypeResponse(
                            pcc.Component.ComponentType.Id,
                            pcc.Component.ComponentType.Abbreviation,
                            pcc.Component.ComponentType.Name
                        )
                    )
                ))
            ))
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException($"PC with id {id} not found");
    }

    public async Task<PcResponse> AddAsync(CreatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = new Pcs
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock,
        };
        ctx.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);
        
        return new PcResponse(pc.Id,pc.Name,pc.Weight,pc.Warranty,pc.CreatedAt,pc.Stock);
    }

    public async Task UpdateAsync(int id, UpdatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (pc is null)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
        
        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;
        await ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (pc is null)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
        
        ctx.PCs.Remove(pc);
        await ctx.SaveChangesAsync(cancellationToken);
    }
}