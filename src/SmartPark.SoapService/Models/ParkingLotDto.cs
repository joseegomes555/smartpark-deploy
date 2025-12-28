using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartPark.SoapService.Models
{
    [DataContract]
    public class ParkingLotDto
    {
        [DataMember] public int ParkingLotId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public string Address { get; set; }
        [DataMember] public int Capacity { get; set; }
        [DataMember] public List<SpotDto> Spots { get; set; } = new List<SpotDto>();
    }

    [DataContract]
    public class SpotDto
    {
        [DataMember] public int SpotId { get; set; }
        [DataMember] public string Code { get; set; }
        [DataMember] public string Status { get; set; }
        [DataMember] public int ParkingLotId { get; set; }
    }
}
