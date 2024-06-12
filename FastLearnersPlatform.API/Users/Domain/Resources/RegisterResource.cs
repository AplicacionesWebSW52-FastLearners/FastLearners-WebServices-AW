namespace FastLearnersPlatform.API.Users.Domain.Resources
{
 
    public class RegisterResource
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdMembership { get; set; }
    }
}