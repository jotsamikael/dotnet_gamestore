
using System.ComponentModel.DataAnnotations;

public class Game
{
    [Key]
    public int idGame { get; set; }

    [Required]
    [StringLength(50)]
    public required string nameGame { get; set; }

    [Required]
    [StringLength(50)]
    public required string genre { get; set; }
    public DateTime releasedDate { get; set; }

    [Range(0, 150000)]
    public int price { get; set; }

    [Url]
    public required string imageUri { get; set; }




}
