using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCodes.Models;

[Table("VillageTracts")]
public class VillageTract
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Unicode(false)]
    [MaxLength(16)]
    public string Id { get; set; } = null!;

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(255)]
    public string NameMM { get; set; } = null!;

    [MaxLength(255)]
    public string? Source { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public bool Active { get; set; }

    public string? Remark { get; set; }

    [Unicode(false)]
    [MaxLength(13)]
    public string TownshipId { get; set; } = null!;

    public virtual Township Township { get; set; } = null!;
    public virtual HashSet<Village> Villages { get; set; }

    public VillageTract()
    {
        Villages = [];
    }
}
