namespace Dal.Models
{
    public class PromptDto
    {
        public string CategoryId { get; set; }
        public string SubCategoryId { get; set; }
        public string Prompt { get; set; }
        public string UserId { get; set; } // אם תרצי לשמור גם את המשתמש
    }
}