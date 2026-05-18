using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationCore.Models;
[Table("PCComponents"),PrimaryKey(nameof(PCId),nameof(ComponentCode))]
public class PcComponents
{
    public int PCId { get; set; }
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } =  string.Empty;
    public int Amount { get; set; }
    
    [ForeignKey(nameof(PCId))]
    public Pcs PC { get; set; } = null!;
    [ForeignKey(nameof(ComponentCode))]
    public Components Component { get; set; } = null!;
}