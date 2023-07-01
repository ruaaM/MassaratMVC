using MassaratMVC.Interfaces;
using MassaratMVC.Models;
using Newtonsoft.Json;
using System.Text;

namespace MassaratMVC.Services
{
    public class MassaratAPI : IMassaratAPI
    {
        public readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;
        public MassaratAPI(HttpClient httpClient, IHttpClientFactory clientFactory) {
            _httpClient = httpClient; 
            _clientFactory = clientFactory;
        }
        public Task<StudentResponse> GetStudentByNameAPI(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentNullException("name");

            StudentResponse response = new StudentResponse();

            throw new NotImplementedException();
        }

        public async Task<LoginResponse> LoginService(LoginRequest loginRequest)
        {
            if (loginRequest == null)
                return new LoginResponse
                {
                    message = "you must enter some data",
                    isSuccess = false,
                };

            var _MassaratAPILoginClient = _clientFactory.CreateClient("MassaratLogin");
            LoginResponse? loginResponse = new LoginResponse();

            var JSONRequest = System.Text.Json.JsonSerializer.Serialize(loginRequest);
            var requestContent = new StringContent(JSONRequest, Encoding.UTF8, "application/json");

            var response = await _MassaratAPILoginClient.PostAsync("/auth/Auth/Login", requestContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            loginResponse = JsonConvert.DeserializeObject<LoginResponse>(content);

            return loginResponse;
        }
    }
}
