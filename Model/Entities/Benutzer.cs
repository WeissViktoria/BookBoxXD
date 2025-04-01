using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("BENUTZER")]
public class Benutzer
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("BENUTZER_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(20)]
    [Column("BENUTZER_NAME")]
    public string Benutzername { get; set; }
    
    [Required, StringLength(20)]
    [Column("PASSWORT")]
    public string Passwort { get; set; }
    
    [Required, StringLength(200)]
    [Column("EMAIL_ADDRESSE")]
    public string? EmailAdresse { get; set; }
    
    [Required]
    [Column("GEBURTSTAG")]
    public DateTime? Geburtstag { get; set; }
    
    [Column("PROFIL_BILD")]
    public byte[]? Profilbild { get; set; }
    
    [Column("LOGGED_IN")]
    public bool? loggedIn { get; set; }
}