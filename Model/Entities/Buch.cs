using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("BUECHER")]
public class Buch
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("BUCH_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(200)]
    [Column("TITEL")]
    public string Titel { get; set; }
    
    [Required, StringLength(200)]
    [Column("AUTOR")]
    public string Autor { get; set; }
    
    [Column("ERSTER_SATZ")]
    public string Erster_Satz { get; set; }
    
    [Column("COVER_URL")]
    public string CoverURL { get; set; }
    
    [Column("ISBN")]
    public string ISBN { get; set; }

}