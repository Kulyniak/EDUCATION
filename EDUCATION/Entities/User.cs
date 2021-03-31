using System.Collections.Generic;

namespace EDUCATION.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public UserLevel Level { get; set; }
        public int Progress { get; set; }

        public List<Question> Questions { get; set; }
    }
}
