using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("BUCHBEZIEHUNG_JT")]
public class BuchBeziehung_JT
{
    public Buch Buch { get; set; }
    [Column("BUCH_ID")]
    public int BuchId { get; set; }

    public Benutzer Benutzer { get; set; }
    [Column("BENUTZER_ID")]
    public int BenutzerId { get; set; }
    
    [Column("STATUS")]
    public BuchStatus Status { get; set; }
    
    [Column("ANFANGSDATUM")]
    public DateTime Anfangsdatum { get; set; }
    
    [Column("KOMMENTARE")]
    public string? Kommentar { get; set; }
    
    [Column("STERNE")]
    public int? Sterne { get; set; }
}