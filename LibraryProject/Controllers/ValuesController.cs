using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Entities.Entities;
using LibraryProject.ViewModels;
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
        public ValuesController(IHomeService _homeService)
        {
            homeService = _homeService;
        }

        [HttpGet]
        public HttpResponseMessage Magazines(string magazinePublisher)
        {
            MagazineFilterModel magazineModel = new MagazineFilterModel();
            InitializeMagazines(magazineModel);
            magazineModel = CheckMagazinesPublisher(magazineModel, magazinePublisher);
            return Request.CreateResponse(HttpStatusCode.OK, magazineModel);
        }

        private MagazineFilterModel InitializeMagazines(MagazineFilterModel model)
        {
            List<string> magazinePublisherList = homeService.GetMagazinesPublishers();

            model.MagazinesPublisher = new System.Web.Mvc.SelectList(magazinePublisherList);
            model.Magazines = new List<Magazine>();

            return model;
        }

        public MagazineFilterModel CheckMagazinesPublisher(MagazineFilterModel model, string magazinePublisher)
        {
            List<Magazine> magazineList = homeService.CheckMagazinePublisher(magazinePublisher);
            model.Magazines = magazineList;
            return model;
        }









        [HttpGet]
        [Route("api/values/SaveBooksTxtList")]
        public HttpResponseMessage SaveBooksTxtList()
        {
            homeService.GetBooksTxtList();
            return Request.CreateResponse(HttpStatusCode.OK);           
        }

        [HttpGet]
        [Route("api/values/SaveBooksXmlList")]
        public HttpResponseMessage SaveBooksXmlList()
        {
            homeService.GetBooksXmlList();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/values/SaveBukletsTxtList")]
        public HttpResponseMessage SaveBukletsTxtList()
        {
            homeService.GetBukletsTxtList();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/values/SaveBukletsXmlList")]
        public HttpResponseMessage SaveBukletsXmlList()
        {
            homeService.GetBukletsXmlList();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/values/SaveNewspapersTxtList")]
        public HttpResponseMessage SaveNewspapersTxtList()
        {
            homeService.GetNewspapersTxtList();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/values/SaveNewspapersXmlList")]
        public HttpResponseMessage SaveNewspapersXmlList()
        {
            homeService.GetNewspapersXmlList();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/values/SaveMagazinesTxtList")]
        public HttpResponseMessage SaveMagazinesTxtList()
        {
            homeService.GetMagazinesTxtList();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/values/SaveMagazinesXmlList")]
        public HttpResponseMessage SaveMagazinesXmlList()
        {
            homeService.GetMagazinesXmlList();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
