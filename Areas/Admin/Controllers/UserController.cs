// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Project_Sem3.Data;
//
// namespace Project_Sem3.Areas.Admin.Controllers;
//
// public class UserController : AdminBaseController
// {
//   private readonly MyDbContext _context;
//
//         public UserController(MyDbContext context)
//         {
//             _context = context;
//         }
//
//         // GET: Admin/Product
//         public async Task<IActionResult> Index()
//         {
//             return View(await _context.User.ToListAsync());
//         }
//
//         // GET: Admin/Product/Details/5
//         public async Task<IActionResult> Details(long? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//
//             var product = await _context.User
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             if (product == null)
//             {
//                 return NotFound();
//             }
//
//             return View(product);
//         }
//
//         // GET: Admin/Product/Create
//         public IActionResult Create()
//         {
//             return View();
//         }
//
//         // POST: Admin/Product/Create
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create([Bind("Id,Title,Description,Price,ImageUrl,Status")] Product product)
//         {
//             if (ModelState.IsValid)
//             {
//                 _context.Add(product);
//                 await _context.SaveChangesAsync();
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(product);
//         }
//
//         // GET: Admin/Product/Edit/5
//         public async Task<IActionResult> Edit(long? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//
//             var product = await _context.User.FindAsync(id);
//             if (product == null)
//             {
//                 return NotFound();
//             }
//             return View(product);
//         }
//
//         // POST: Admin/Product/Edit/5
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Description,Price,ImageUrl,Status")] Product product)
//         {
//             if (id != product.Id)
//             {
//                 return NotFound();
//             }
//
//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     _context.Update(product);
//                     await _context.SaveChangesAsync();
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {
//                     if (!ProductExists(product.Id))
//                     {
//                         return NotFound();
//                     }
//                     else
//                     {
//                         throw;
//                     }
//                 }
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(product);
//         }
//
//         // GET: Admin/Product/Delete/5
//         public async Task<IActionResult> Delete(long? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//
//             var product = await _context.User
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             if (product == null)
//             {
//                 return NotFound();
//             }
//
//             return View(product);
//         }
//
//         // POST: Admin/Product/Delete/5
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(long id)
//         {
//             var product = await _context.User.FindAsync(id);
//             if (product != null)
//             {
//                 _context.User.Remove(product);
//             }
//
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }
//
//         private bool ProductExists(long id)
//         {
//             return _context.User.Any(e => e.Id == id);
//         }
// }
