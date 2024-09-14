using System.ComponentModel.DataAnnotations;

namespace BPKB_API.Entities;
#pragma warning disable
public record User
{
    [Key]
    public int user_id { get; set; }
    public string user_name { get; set; }
    public string password { get; set; }
    public bool is_active { get; set; }
}
