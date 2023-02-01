namespace PetProject.Models 
{
    public class ArticleRequest 
    {
        public Guid? Id { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string? PreviewImgSrc { get; set; }
        public string Author { get; set; } = null!;
    }
}