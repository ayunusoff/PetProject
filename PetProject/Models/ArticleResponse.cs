namespace PetProject.Models
{
    public class ArticleResponse
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string? PreviewImgSrc { get; set; } 
        public string DateAdd { get; set; } = null!;
        public string Author { get; set; } = null!;
    }
}