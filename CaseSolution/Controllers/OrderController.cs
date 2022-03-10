using CaseSolution.Data;
using CaseSolution.Extensions;
using CaseSolution.Models;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CaseSolution.Controllers
{
    public class OrderController : Controller
    {
        private readonly TestContext _context;

        public OrderController(TestContext context)
        {
            _context = context;
        }

        public IActionResult GetStartAndFinishDate(string dateStart, string dateFinish)
        {
            var model = new OrderDateRequestDTO { startDate = dateStart, endDate = dateFinish };

            return View(model);
        }

        [HttpGet]
        public IActionResult GetOrder(string dateStart, string dateFinish)
        {
            var repo = new Repository(_context);
            var OrderList = repo.getOrder(dateStart, dateFinish);
            OrderVM[] orderArray = OrderList.ToArray();
            return Ok(orderArray);
        }
    }
}
