using DatabaseConnection.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class LoginService : ILoginService
    {
        private ILoginDAL _loginDAL;
        public LoginService(ILoginDAL loginDAL)
        {
            _loginDAL = loginDAL;
        }

        public bool ValidateUser(string username, string password)
        {
            return _loginDAL.ValidateUser(username, password);
        }
    }
}
