using MbmStore.Infrastructure;
using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            Repository repository = new Repository();
            ViewBag.Invoices = repository.Invoices;


            // generete dropdown list
            List<SelectListItem> customers = new List<SelectListItem>();
            foreach (Invoice invoice in repository.Invoices)
            {
                customers.Add(new SelectListItem { Text = invoice.Customer.Firstname + " " + invoice.Customer.Lastname, Value = invoice.Customer.CustomerId.ToString() });
            }
            // removes duplicate entries with same ID from a IEnumerable
            customers = customers.GroupBy(x => x.Value).Select(y => y.First()).OrderBy(z => z.Text).ToList<SelectListItem>();

            ViewBag.CustomerId = customers;
            return View();
        }


        [HttpPost]
        public ActionResult Index(int? CustomerId)
        {
            Repository repository = new Repository();

            // generete dropdown list
            List<SelectListItem> customers = new List<SelectListItem>();
            foreach (Invoice invoice in repository.Invoices)
            {
                customers.Add(new SelectListItem { Text = invoice.Customer.Firstname + " " + invoice.Customer.Lastname, Value = invoice.Customer.CustomerId.ToString() });

            }

            // removes duplicate entries with same ID from a IEnumerable
            customers = customers.GroupBy(x => x.Value).Select(y => y.First()).OrderBy(z => z.Text).ToList<SelectListItem>();

            ViewBag.CustomerID = customers;

            IEnumerable<Invoice> invoices = repository.Invoices;

            if (CustomerId != null ) { 
                // select invoices for a customer with linq
                invoices = repository.Invoices.Where(r => r.Customer.CustomerId == CustomerId);    
            }
            ViewBag.Invoices = invoices;
            


            return View();
        }
    }
}