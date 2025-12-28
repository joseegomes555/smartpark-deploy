namespace SmartPark.Data.Entities;

public class ParkingLot
{
    public int ParkingLotId { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public int Capacity { get; set; }

    public List<Spot> Spots { get; set; } = new();
}
