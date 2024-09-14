using System.ComponentModel.DataAnnotations;

namespace BPKB_API.Entities;
#pragma warning disable
public record Location
{
    [Key]
    public string location_id { get; set; }
    public string location_name { get; set; }

}
