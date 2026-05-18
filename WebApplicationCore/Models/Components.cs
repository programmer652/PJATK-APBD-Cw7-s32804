using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationCore.Models;
[Table("Components")]
public class Components
{
    [Key,Column(TypeName = "char(10)")]
    public string Code { get; set; }
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ComponentManufacturerId { get; set; }
    public int ComponentTypeId { get; set; }
    
    public IEnumerable<PcComponents> PCComponents { get; set; } = [];
    [ForeignKey(nameof(ComponentTypeId))]
    public ComponentTypes ComponentType { get; set; } = null!;
    [ForeignKey(nameof(ComponentManufacturerId))]
    public ComponentManufacturers ComponentManufacturer { get; set; } = null!;
}