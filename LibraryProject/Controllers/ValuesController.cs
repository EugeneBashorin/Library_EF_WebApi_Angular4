using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using ConfigurationData.Configurations;
using Entities.Entities;
using LibraryProject.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace LibraryProject.Controllers
{
    public class ValuesController : ApiController
    {

        IHomeService homeService;
        public ValuesController(IHomeService _homeService)
        {
            homeService = _homeService;
        }

        protected HttpResponseMessage ToJson(dynamic obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }

        public /*IHttpActionResult*/HttpResponseMessage Get()
        {
           return ToJson(homeService.GetBooks());
           // return Ok(homeService.GetBooks()/*db.Users.ToList()*/);
        }

        public IHttpActionResult Post([FromBody]Book book)
        {
            homeService.AddBook(book);
            return Ok();
        }

        public IHttpActionResult Put(int id, [FromBody]Book book)
        {
             homeService.UpdateBook(book.Id,book);
             return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
           homeService.DeleteBook(id);
            return Ok();
        }

        //public IHttpActionResult Get(int id)
        //{
        //    User user = db.Users.FirstOrDefault(x => x.Id == id);
        //    if (user != null)
        //        return Ok(user);

        //    return NotFound();
        //}

        //public IHttpActionResult Post([FromBody]User user)
        //{
        //    db.Users.Add(user);
        //    db.SaveChanges();
        //    return Ok(user);
        //}

        //public IHttpActionResult Put(int id, [FromBody]User user)
        //{
        //    User u = db.Users.Find(id);
        //    if (u != null)
        //    {
        //        u.Name = user.Name;
        //        u.Age = user.Age;
        //        db.Entry(u).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return Ok(u);
        //    }
        //    return NotFound();
        //}

        //public IHttpActionResult Delete(int id)
        //{
        //    User user = db.Users.Find(id);
        //    if (user != null)
        //    {
        //        db.Users.Remove(user);
        //        db.SaveChanges();
        //        return Ok(user);
        //    }

        //    return NotFound();
        //}


        //[HttpPost]
        //[Authorize(Roles = IdentityConfiguration._ADMIN_ROLE)]
        //public ActionResult CreateBook(Book book)
        //{
        //    if (book.Price < 0)
        //    {
        //        ModelState.AddModelError("Price", "Price should be positive");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        homeService.AddBook(book);

        //        return Json(book);
        //    }
        //    return Json(HttpStatusCode.NotModified);
        //}

        //[HttpPost]
        //[Authorize(Roles = IdentityConfiguration._ADMIN_ROLE)]
        //public ActionResult EditBook(int? Id, Book newBook)
        //{
        //    if (Id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    if (newBook.Price < 0)
        //    {
        //        ModelState.AddModelError("Price", "Price should be positive");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        homeService.UpdateBook(Id, newBook);
        //        return Json(newBook);
        //    }
        //    return Json(HttpStatusCode.NotModified);
        //}

        //[HttpPost]
        //[Authorize(Roles = IdentityConfiguration._ADMIN_ROLE)]
        //public ActionResult DeleteBook(int? id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    homeService.DeleteBook(id);
        //    return Json(HttpStatusCode.OK);
        //}



        //[HttpGet]
        //[Route("api/values/SaveBooksTxtList")]
        //public HttpResponseMessage SaveBooksTxtList()
        //{
        //    homeService.GetBooksTxtList();
        //    return Request.CreateResponse(HttpStatusCode.OK);           
        //}

        //[HttpGet]
        //[Route("api/values/SaveBooksXmlList")]
        //public HttpResponseMessage SaveBooksXmlList()
        //{
        //    homeService.GetBooksXmlList();
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //[HttpGet]
        //[Route("api/values/SaveBukletsTxtList")]
        //public HttpResponseMessage SaveBukletsTxtList()
        //{
        //    homeService.GetBukletsTxtList();
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //[HttpGet]
        //[Route("api/values/SaveBukletsXmlList")]
        //public HttpResponseMessage SaveBukletsXmlList()
        //{
        //    homeService.GetBukletsXmlList();
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //[HttpGet]
        //[Route("api/values/SaveNewspapersTxtList")]
        //public HttpResponseMessage SaveNewspapersTxtList()
        //{
        //    homeService.GetNewspapersTxtList();
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //[HttpGet]
        //[Route("api/values/SaveNewspapersXmlList")]
        //public HttpResponseMessage SaveNewspapersXmlList()
        //{
        //    homeService.GetNewspapersXmlList();
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //[HttpGet]
        //[Route("api/values/SaveMagazinesTxtList")]
        //public HttpResponseMessage SaveMagazinesTxtList()
        //{
        //    homeService.GetMagazinesTxtList();
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //[HttpGet]
        //[Route("api/values/SaveMagazinesXmlList")]
        //public HttpResponseMessage SaveMagazinesXmlList()
        //{
        //    homeService.GetMagazinesXmlList();
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}
    }
}
