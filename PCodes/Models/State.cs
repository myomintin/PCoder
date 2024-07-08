using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCodes.Models;

[Table("States")]
public class State
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Unicode(false)]
    [MaxLength(10)]
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

    public HashSet<District> Districts { get; set; }

    public State()
    {
        Districts = [];
    }
}
