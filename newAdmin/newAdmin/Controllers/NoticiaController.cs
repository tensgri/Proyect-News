using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using newAdmin.Data;
using newAdmin.Models;

namespace newAdmin.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly noticiaContext _context;

        public NoticiaController(noticiaContext context)
        {
            _context = context;
        }

        // GET: Noticia
        public async Task<IActionResult> Index()
        {
            var noticiaContext = _context.News.Include(n => n.CategoriaNavigation).Include(n => n.CodepaisNavigation);
            return View(await noticiaContext.ToListAsync());
        }

        // GET: Noticia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.CategoriaNavigation)
                .Include(n => n.CodepaisNavigation)
                .FirstOrDefaultAsync(m => m.IdNews == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: Noticia/Create
        public IActionResult Create()
        {
            ViewData["Categoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria");
            ViewData["Codepais"] = new SelectList(_context.Pais, "CodePais", "CodePais");
            return View();
        }

        // POST: Noticia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNews,Codepais,Categoria,Titulo,Descripcion,UrlNews,UrlImage,FechaCreacion,FechaModificacion,Autor,Visible")] News news)
        {
            if (ModelState.IsValid)
            {
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria", news.Categoria);
            ViewData["Codepais"] = new SelectList(_context.Pais, "CodePais", "CodePais", news.Codepais);
            return View(news);
        }

        // GET: Noticia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            ViewData["Categoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria", news.Categoria);
            ViewData["Codepais"] = new SelectList(_context.Pais, "CodePais", "CodePais", news.Codepais);
            return View(news);
        }

        // POST: Noticia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNews,Codepais,Categoria,Titulo,Descripcion,UrlNews,UrlImage,FechaCreacion,FechaModificacion,Autor,Visible")] News news)
        {
            if (id != news.IdNews)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.IdNews))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria", news.Categoria);
            ViewData["Codepais"] = new SelectList(_context.Pais, "CodePais", "CodePais", news.Codepais);
            return View(news);
        }

        // GET: Noticia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.CategoriaNavigation)
                .Include(n => n.CodepaisNavigation)
                .FirstOrDefaultAsync(m => m.IdNews == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: Noticia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.IdNews == id);
        }
    }
}
