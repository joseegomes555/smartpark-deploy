using MySql.Data.MySqlClient;
using SmartPark.SoapService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace SmartPark.SoapService
{
    public class SmartParkSoapService : ISmartParkSoapService
    {
        private string ConnStr =>
            ConfigurationManager.ConnectionStrings["SmartParkDb"].ConnectionString;

        public List<ParkingLotDto> GetParkingLots()
        {
            var lots = new Dictionary<int, ParkingLotDto>();

            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();

                var sql = @"
SELECT p.ParkingLotId, p.Name, p.Address, p.Capacity,
       s.SpotId, s.Code, s.Status, s.ParkingLotId as SpotParkingLotId
FROM ParkingLots p
LEFT JOIN Spots s ON s.ParkingLotId = p.ParkingLotId
ORDER BY p.ParkingLotId, s.SpotId;";

                using (var cmd = new MySqlCommand(sql, conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        int lotId = r.GetInt32("ParkingLotId");

                        if (!lots.ContainsKey(lotId))
                        {
                            lots[lotId] = new ParkingLotDto
                            {
                                ParkingLotId = lotId,
                                Name = r.GetString("Name"),
                                Address = r.GetString("Address"),
                                Capacity = r.GetInt32("Capacity")
                            };
                        }

                        if (!r.IsDBNull(r.GetOrdinal("SpotId")))
                        {
                            lots[lotId].Spots.Add(new SpotDto
                            {
                                SpotId = r.GetInt32("SpotId"),
                                Code = r.GetString("Code"),
                                Status = r.GetString("Status"),
                                ParkingLotId = r.GetInt32("SpotParkingLotId")
                            });
                        }
                    }
                }
            }

            return new List<ParkingLotDto>(lots.Values);
        }

        public bool UpdateSpotStatus(int spotId, string status)
        {
            var allowed = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            { "free", "occupied", "unknown" };

            if (!allowed.Contains(status))
                return false;

            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();

                var sql = "UPDATE Spots SET Status = @status WHERE SpotId = @id;";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@status", status.ToLower());
                    cmd.Parameters.AddWithValue("@id", spotId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
