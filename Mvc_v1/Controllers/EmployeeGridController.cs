using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using Domain.Dto;
using Repository;
using ServiceLayer;

namespace Mvc_v1.Controllers
{
    public class EmployeeGridController : Controller
    {
        private readonly IServiceEmployee service;
        public EmployeeGridController(IServiceEmployee serviceEmployee)
        {
            this.service = serviceEmployee;
        }
        //

        // GET: EmployeeGrid
        public ActionResult Index()
        {
            return View(service.GetAllEmployees());
        }



    }
}
