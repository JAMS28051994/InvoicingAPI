namespace Services.Interfaces
{
    public interface ILoginService
    {
        public bool ValidateUser(string username, string password);
    }
}
