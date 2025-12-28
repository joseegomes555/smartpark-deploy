using System.Collections.Generic;
using System.ServiceModel;
using SmartPark.SoapService.Models;

namespace SmartPark.SoapService
{
    [ServiceContract]
    public interface ISmartParkSoapService
    {
        [OperationContract]
        List<ParkingLotDto> GetParkingLots();

        [OperationContract]
        bool UpdateSpotStatus(int spotId, string status);
    }
}
