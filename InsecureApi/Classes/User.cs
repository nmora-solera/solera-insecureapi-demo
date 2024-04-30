namespace InsecureApi.Classes
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string password { get; set; }
    }

    public class UserLogin
    {
        public string name { get; set; }
        public string password { get; set; }
    }

    public class ChangePassword
    {
        public string id { get; set; }
        public string password { get; set; }
    }
}
