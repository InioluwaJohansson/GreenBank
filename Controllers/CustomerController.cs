using BankApp.Context;
using BankApp.Models.DTOs;
using BankApp.Repositories;
using BankApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService customerService;
        private readonly CustomerRepository customerRepository;
        private readonly BankAppDbContext context;

        public CustomerController(BankAppDbContext dbContext)
        {
            context = dbContext;
            customerRepository = new CustomerRepository(dbContext);
            customerService = new CustomerService(customerRepository);
        }
        // GET: CustomerController
        public IActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public IActionResult Profile(string accountNumber)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var customer = customerService.Find1(accountNumber);
                if (customer != null)
                {
                    TempData["Message"] = "Login Successful";
                    return View(customer);
                }
                else
                {
                    TempData["Message"] = "Invalid Email Or Password";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        // GET: CustomerController/Create
        public IActionResult Create(CreateCustomerDto createCustomer)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var customer = customerService.Register(createCustomer);
                if (customer)
                {
                    TempData["Message"] = "Successfully Created";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public IActionResult Login(string accountNumber, string password ,CreateCustomerDto createCustomer)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var customer = customerService.Find(accountNumber, password);
                if (customer != null)
                {
                    TempData["Message"] = "Login Successful";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Invalid Email Or Password";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
