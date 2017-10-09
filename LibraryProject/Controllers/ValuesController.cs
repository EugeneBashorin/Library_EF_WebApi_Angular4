using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryProject.Controllers
{
    public class ValuesController : ApiController
    {
        IHomeService homeService;

        public ValuesController(HomeService _homeService)
        {
            homeService = _homeService;
        }

        //[HttpGet]
        //public ActionResult Books(string bookPublisher)
        //{
        //    BooksFilterModel bookModel = new BooksFilterModel();
        //    InitializeBooks(bookModel);
        //    bookModel = CheckBooksPublisher(bookModel, bookPublisher);

        //    return View(bookModel);
        //}

        // public HttpResponseMessage GetBooks(string bookPublisher)
        // {
        ////     return 
        // }
    }
}
