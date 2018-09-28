using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCECommerceRemake.Models;

namespace MVCECommerceRemake.Controllers
{
    public class BasketsController : Controller
    {
        private readonly ADMINContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BasketsController(ADMINContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        // GET: Baskets
        public async Task<IActionResult> Index(BasketCompatabiltyModel basketVM)
        {
            var baskets = from b in _context.Basket
                              select b;

            var products = from p in _context.Products
                               select p;
 
           //If no user exists catch error
           var user = await _userManager.FindByNameAsync(ControllerContext.HttpContext.User.Identity.Name);

           string userId = await _userManager.GetUserIdAsync(user);

           baskets = baskets.OrderBy(d => d.ProductId).Where(s => s.CustomerId.Equals(userId));
           products = products.OrderBy(q => q.ProductId).Where(p => baskets.Any(p2 => p2.ProductId == p.ProductId));
           
           basketVM.Bvm.baskets = baskets.ToList();
           basketVM.Pvm.products = products.ToList();

           //If user basket is empty return null model instance
           if (basketVM.Bvm.baskets.Count() == 0)
            {
                basketVM = new BasketCompatabiltyModel();
            }

            await _context.SaveChangesAsync();

            return View(basketVM);
        }

        // GET: Baskets/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _context.Basket
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // GET: Baskets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baskets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,ProductId,Quantity")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(basket);
        }

        // GET: Baskets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var basket = await _context.Basket.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }
            return View(basket);
        }

        // POST: Baskets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> Edit([FromBody]Products data)
        {
            Products product = new Products { ProductId = data.ProductId, ProductQuantity = data.ProductQuantity };

            //Code to update once current quantity and prodID can be retrieved 

            var baskets = from b in _context.Basket
                           select b;

            List<Basket> productToUpdate = baskets.Where(b => b.ProductId == product.ProductId).ToList();

            if (productToUpdate == null)
            {
                //return NotFound();
            }

            foreach (Basket b in productToUpdate)
            {
                b.Quantity = product.ProductQuantity;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Baskets/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _context.Basket
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // POST: Baskets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basket = await _context.Basket.FindAsync(id);
            _context.Basket.Remove(basket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasketExists(string id)
        {
            return _context.Basket.Any(e => e.CustomerId == id);
        }
    }
}
