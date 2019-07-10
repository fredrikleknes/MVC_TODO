using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TODOWEB.Models;
using System.Diagnostics;

namespace TODOWEB.Models
{

    public class OverviewController : Controller
    {
        private readonly TODOWEBContext _context;

        public OverviewController(TODOWEBContext context)
        {
            _context = context;
        }

        // GET: Overview
        public async Task<IActionResult> Index()
        {
            return View(await _context.Overview.ToListAsync());
        }

        // GET: Overview/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var overview = await _context.Overview
                .FirstOrDefaultAsync(m => m.Id == id);
            if (overview == null)
            {
                return NotFound();
            }
            return View(overview);
        }

        // GET: Overview/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Overview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Address,Title,Type,Description")] Overview overview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(overview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(overview);
        }

        //public IActionResult CreateList()
        //{
        //    return View();
        //}

        // POST: Overview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateList(int pid)
        {
            Person p = GetPerson(pid);
            Todolist l = GetList(1);
            Overview o = createNewOverview(p, l);
            if (ModelState.IsValid)
            {
                _context.Add(o);
            }
            return View(o);
        }



        public Overview createNewOverview(Person p, Todolist l) 
        {
            if (p != null && l != null)
            {
                Overview o = new Overview();
                o.Id = p.Id; o.Name = p.Name; o.Email = p.Email; o.Address = p.Address; o.Title = l.Title; o.Type = l.Type; o.Description = l.Description;
                return o;
            }
            return null;
        }   



        public Person GetPerson(int id)
        {
            System.Diagnostics.Trace.WriteLine("TEST THDIOSGDFSJKGHFDJSKGHJK !!!!!!!!!!");
            var person = _context.Person.Find(id);
            if (person == null)
            {
                System.Diagnostics.Trace.WriteLine("TEST THDIOSGDFSJKGHFDJSKGHJK !!!!!!!!!!");
                return null;
            }
            return person;
        }

        public Todolist GetList(int id)
        {
            var list = _context.Todolist.Find(id);
            if (list == null)
            {
                return null;
            }
            return list;
        }




        // GET: Overview/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var overview = await _context.Overview.FindAsync(id);
            if (overview == null)
            {
                return NotFound();
            }
            return View(overview);
        }

        // POST: Overview/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Address,Title,Type,Description")] Overview overview)
        {
            if (id != overview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(overview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OverviewExists(overview.Id))
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
            return View(overview);
        }

        // GET: Overview/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var overview = await _context.Overview
                .FirstOrDefaultAsync(m => m.Id == id);
            if (overview == null)
            {
                return NotFound();
            }

            return View(overview);
        }

        // POST: Overview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var overview = await _context.Overview.FindAsync(id);
            _context.Overview.Remove(overview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OverviewExists(int id)
        {
            return _context.Overview.Any(e => e.Id == id);
        }
    }
}
