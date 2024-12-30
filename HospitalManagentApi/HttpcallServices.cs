using Domain.Entities;

namespace HospitalManagentApi
{
    public class HttpcallServices:IHttpcallServices
    {
        private IBaseApiClient _baseApiClient;
        public HttpcallServices(IBaseApiClient baseApiClient)
        {
            _baseApiClient = baseApiClient;
        }
        public async Task<ApiResponse<List<Doctor>>> GetDoctors()
        {
            return await _baseApiClient.GetAsync<ApiResponse<List<Doctor>>>("api/v1/employees");
        }
    }
    public class Doctor
    {
        public int id { get; set;   }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }

    }

    public interface IHttpcallServices
    {
        Task<ApiResponse<List<Doctor>>> GetDoctors();
    }



}
