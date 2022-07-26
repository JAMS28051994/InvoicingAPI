namespace DatabaseConnection.Interfaces
{
    public interface ILoginDAL
    {
        public bool ValidateUser(string username, string password);
    }
}
