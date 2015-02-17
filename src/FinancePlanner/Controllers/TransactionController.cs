using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using FinancePlanner.Models;

namespace FinancePlanner.Controllers
{
    public class TransactionController : Controller
    {
        private FinancePlannerDbContext _context;

        public TransactionController(FinancePlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Transaction> Get()
        {
            return _context.Transaction.ToList();
        } 

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Transaction Get(int id)
        {
            return _context.Transaction.Single(m => m.Id == id);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public void Post([FromBody]Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Transaction.Add(transaction);
                _context.SaveChanges();
            }
        }

        // PUT api/values/5
        [HttpPut("api/[controller]/{id}")]
        public void Put(int id, [FromBody]Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(transaction).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("api/[controller]/{id}")]
        public void ApiDelete(int id)
        {
            var transaction = _context.Transaction.Single(m => m.Id == id);
            _context.Transaction.Remove(transaction);
            _context.SaveChanges();
        }

        // GET: Transaction
        public IActionResult Index()
        {
            return View(Get());
        }

        // GET: Transaction/Details/5
        public IActionResult Details(System.Int32? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var transaction = this.Get(id.Value);
            if (transaction == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(transaction);
        }

        // GET: Transaction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                Post(transaction);
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        // GET: Transaction/Edit/5
        public IActionResult Edit(System.Int32? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var transaction = this.Get(id.Value);
            if (transaction == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(transaction);
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                Put(transaction.Id,transaction);
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        // GET: Transaction/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(System.Int32? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Transaction transaction = _context.Transaction.Single(m => m.Id == id);
            if (transaction == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(System.Int32 id)
        {
            this.ApiDelete(id);

            return RedirectToAction("Index");
        }
    }
}
