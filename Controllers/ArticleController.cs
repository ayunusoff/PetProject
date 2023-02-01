using Microsoft.AspNetCore.Mvc;
using PetProject.Interfaces;
using PetProject.Entities;
using PetProject.Models;
using PetProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
            var articles = await _context.Articles
            .Include(a => a.Author)
            .Select(
                a => 
                new ArticleResponse 
                {
                    Id = a.Id.ToString(),
                    Title = a.Title,
                    Text = a.Text,
                    PreviewImgSrc = a.PreviewImgSrc,
                    Author = a.Author.Nickname,
                    DateAdd = a.DateAdd.ToString("dd.MM.yy"),
                }
            )
            .ToListAsync();
            
            if (articles != null) 
            {
                return Json(articles);
            }
            return NotFound();
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(string id) 
        {
            var article = _uof.ArticleRepository.GetById(id);
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
            var article = _uof.ArticleRepository.GetById(articleRequest.Id.ToString());
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
        public async Task<IActionResult> Post([FromBody] ArticleRequest articleRequest) 
        {
            if (articleRequest != null)
            {
                var author = _context.Users.FirstOrDefault(a => a.Nickname == articleRequest.Author);
                Article article = new Article
                {
                    Id = articleRequest.Id == null ? Guid.NewGuid() : (Guid)articleRequest.Id,
                    Title = articleRequest.Title,
                    Text = articleRequest.Text,
                    PreviewImgSrc = articleRequest.PreviewImgSrc != null ? articleRequest.PreviewImgSrc : "./public/favicon.ico",
                    DateAdd = DateTime.UtcNow,
                    Author = author,
                };
                await _context.Articles.AddAsync(article);
                _context.SaveChanges();
                return Ok(article.Id);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult GetViewCount(string id)
        {
            var article = _uof.ArticleRepository.GetById(id.ToString());

            if (article != null)
                return Ok(article.ViewCount);
            return NotFound();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchViewCount(string id) 
        {
            var article = _uof.ArticleRepository.GetById(id.ToString());
            if (article == null)
                return NotFound();
            
            article.ViewCount += 1;
            _uof.ArticleRepository.Update(article);
            await _uof.Complete();

            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(string id) 
        {
            var article = _uof.ArticleRepository.GetById(id.ToString());
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