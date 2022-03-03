using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private Basket basket { get; set; }

        public PurchaseController (IPurchaseRepository temp, Basket ba)
        {
            repo = temp;
            basket = ba;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout (Purchase purchase)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = basket.Items.ToArray();
                repo.SavePurchase(purchase);
                basket.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");
            }
            else
            {
                return View();
            }
        }

    }
}
