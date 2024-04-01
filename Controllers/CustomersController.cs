using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers/Details/1
        public ActionResult Details(int id)
        {
            CustomerBL customerBL = new CustomerBL();
            Customer customer = customerBL.GetCustomerDetails(1);

            ViewData["Customer"] = customer;
            ViewData["Header"] = "Customer Details";

            /*ViewBag.Employee = customer;
            ViewBag.Header = "Employee Details";*/

            return View();
        }

        // GET: Customers/List
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Doe", Email = "john@example.com", PhoneNumber = "123-456-7890" },
                new Customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com", PhoneNumber = "234-567-8901" },
                new Customer { Id = 3, Name = "Alice Johnson", Email = "alice@example.com", PhoneNumber = "345-678-9012" },
                new Customer { Id = 4, Name = "Bob Brown", Email = "bob@example.com", PhoneNumber = "456-789-0123" },
                new Customer { Id = 5, Name = "Emily Davis", Email = "emily@example.com", PhoneNumber = "567-890-1234" }

            };

            var viewModel = new CustomerListViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Method1()
        {
            TempData["Name"] = "Pranaya";
            TempData["Id"] = 30;
            return View();
        }
        public ActionResult Method2()
        {
            string Name;
            int Id;
            if (TempData.ContainsKey("Name"))
                Name = TempData["Name"].ToString();
            if (TempData.ContainsKey("Id"))
                Id = int.Parse(TempData["Id"].ToString());

            TempData.Keep();

            return View();
        }
        public ActionResult Method3()
        {
            string Name;
            int Id;
            if (TempData.ContainsKey("Name"))
                Name = TempData["Name"].ToString();
            if (TempData.ContainsKey("Id"))
                Id = int.Parse(TempData["Id"].ToString());

            return View();
        }


    }
}