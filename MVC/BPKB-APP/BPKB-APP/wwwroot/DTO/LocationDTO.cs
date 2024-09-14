using System.ComponentModel.DataAnnotations;

namespace BPKB_APP.wwwroot.DTO;
public record LocationDTO
{
    public string location_id { get; set; }
    public string location_name { get; set; }

}

