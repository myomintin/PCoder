using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCodes.Models;

[Table("Townships")]
public class Township
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Unicode(false)]
    [MaxLength(13)]
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
    [MaxLength(14)]
    public string DistrictId { get; set; } = null!;

    public District District { get; set; } = null!;
    public HashSet<Town> Towns { get; set; }
    public HashSet<VillageTract> VillageTracts { get; set; }

    public Township()
    {
        Towns = [];
        VillageTracts = [];
    }
}
