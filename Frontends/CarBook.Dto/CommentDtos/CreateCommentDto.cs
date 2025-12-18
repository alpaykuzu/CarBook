namespace CarBook.Dto.CommentDtos
{
    public class CreateCommentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Content { get; set; }
        public int BlogID { get; set; }
    }
}
