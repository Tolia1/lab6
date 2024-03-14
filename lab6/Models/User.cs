namespace lab6.Models
{
    public class User
    {
        public string Username { get; set; }
        public int Age { get; set; }
        public bool IsAgeAcceptable()
        {
            return Age >= 16;
        }
    }
}
