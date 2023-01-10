namespace PetProject.Models 
{
    public class ArticleRequest 
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? PreviewImgSrc { get; set; }
    }
}