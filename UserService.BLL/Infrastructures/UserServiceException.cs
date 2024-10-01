namespace UserService.BLL.Infrastructures
{
    public class UserServiceException : Exception
    {
        public string property { get; } = null!;
        public UserServiceException(string message, string property) : base(message) 
        { 
            this.property = property;
        }

        public UserServiceException(UserServiceException ex) : base(ex.Message) { this.property = ex.property; }

    }
}
