namespace SmartPark.Data.Entities;

public class Spot
{
    public int SpotId { get; set; }
    public string Code { get; set; } = "";
    public string Status { get; set; } = "free"; // free/occupied/unknown

    public int ParkingLotId { get; set; }
    public ParkingLot? ParkingLot { get; set; }
}
