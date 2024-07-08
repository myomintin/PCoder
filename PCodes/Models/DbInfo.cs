using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCodes.Models;

[Table("DbInfos")]
public class DbInfo
{
    [Required]
    [MaxLength(100)]
    public string Id { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Value { get; set; } = null!;
}
