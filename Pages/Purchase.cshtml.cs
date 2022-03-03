using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookstore.Infrastructure;
using OnlineBookstore.Models;

namespace OnlineBookstore.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public PurchaseModel(IBookstoreRepository temp, Basket ba)
        {
            repo = temp;
            basket = ba;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            basket.AddItem(b, 1, b.Price);
            return RedirectToPage(new { ReturnUrl = returnUrl });

        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
