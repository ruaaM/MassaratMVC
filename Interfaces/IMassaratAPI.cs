using MassaratMVC.Models;

namespace MassaratMVC.Interfaces
{
    public interface IMassaratAPI
    {
        public Task<StudentResponse> GetStudentByNameAPI(string name);
        public Task<LoginResponse> LoginService(LoginRequest loginRequest);
    }
}
