using Microsoft.AspNetCore.Mvc;
using PetProject.Interfaces;
using PetProject.Entities;
using PetProject.Models;
using PetProject.Data;
using Microsoft.AspNetCore.Authorization;

namespace PetProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ArticleController : InitController<Article>
    {
        public ArticleController(PetProjectContext context, IUnitOfWork uof) :  base(context, uof)
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var articles = await _uof.ArticleRepository.GetAll();
            if (articles != null) 
            {
                return Json(articles);
            }
            return NotFound();
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(string id) 
        {
            var article = _uof.ArticleRepository.Get(id);
            if (article != null) 
            {
                return Json(article);
            }
            return NotFound();
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] ArticleRequest articleRequest) 
        {
            var article = _uof.ArticleRepository.Get(articleRequest.Id.ToString());
            if (article != null) 
            {
                article.Title = articleRequest.Title != null ? articleRequest.Title : article.Title;
                article.Text = articleRequest.Text != null ? articleRequest.Text : article.Text;
                article.PreviewImgSrc = articleRequest.PreviewImgSrc != null ? articleRequest.PreviewImgSrc : article.PreviewImgSrc;
                await _uof.Complete();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ArticleRequest article) 
        {
            if (article != null)
            {
                await _uof.ArticleRepository.Add(
                new Article 
                {
                    Id = article.Id == null ? Guid.NewGuid() : (Guid)article.Id,
                    Title = article.Title,
                    Text = article.Text,
                    PreviewImgSrc = article.PreviewImgSrc != null ? article.PreviewImgSrc : "./public/favicon.ico",
                    DateAdd = DateTime.UtcNow,
                }
                );
                await _uof.Complete();
                return Ok();
            }
            return BadRequest();
        }
        
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(string id) 
        {
            var article = _uof.ArticleRepository.Get(id.ToString());
            if (article != null)
            {
                _uof.ArticleRepository.Delete(article);
                await _uof.Complete();
                return Ok();
            }
            return BadRequest();
        }
    }
}