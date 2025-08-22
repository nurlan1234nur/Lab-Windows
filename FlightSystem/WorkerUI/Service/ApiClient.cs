using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerUI.Service
{
    public static class ApiClients
    {
        public static HttpClient HttpClient { get; } = new HttpClient
        {
            BaseAddress = new Uri("http://10.30.29.133:5000/")
        };

        public static UserApiClientAdmin UserClient { get; } = new UserApiClientAdmin(HttpClient);
        public static OrderApiClient OrderClient { get; } = new OrderApiClient(HttpClient);
        public static FlightApiClient FlightClient { get; } = new FlightApiClient(HttpClient);
        public static FlightInfoApiClient FlightInfoClient { get; } = new FlightInfoApiClient(HttpClient);
        public static SeatApiClient SeatClient { get; } = new SeatApiClient(HttpClient);
    }

}
