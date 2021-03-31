namespace EDUCATION.Entities
{
    public class Question : BaseEntity
    {
        public string Name { get; set; }
        public QuestionType Type { get; set; }
        public UserLevel Level { get; set; }

        public string TestAnswer1 { get; set; }
        public string TestAnswer2 { get; set; }
        public string TestAnswer3 { get; set; }
        public string TestAnswer4 { get; set; }

        public string RightTestAnswer { get; set; }

        public string RightWordAnswer { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
