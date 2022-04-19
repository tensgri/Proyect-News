using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiNoticia.Data;
using ApiNoticia.Models;

namespace ApiNoticia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly noticiaContext _context;

        public NewsController(noticiaContext context)
        {
            _context = context;
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            return await _context.News.ToListAsync();
        }


      
        

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.IdNews == id);
        }
    }
}
