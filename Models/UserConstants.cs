namespace FleetMan.Models
{
    public class UserConstants
    {
        public static List<User> Users = new()
            {
                    new User(){ Username="admin",Password="111",Role="Admin"}
            };
    }
}