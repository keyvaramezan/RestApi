using RestApi.Application.Service.Core;

namespace RestApi.Application.Service
{
    public class TestService : IService
    {
        public string GetData()
        {
            return "Sample Data";
        }
    }
}
