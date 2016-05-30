using CountriesProcessUnit.Infrastructure.DAL;
using CountriesProcessUnit.Infrastructure.Exceptions;
using CountriesProcessUnit.ViewModels;
using CountryInfo.App_Start;
using CountryInfo.Infrastructure.Enums;
using CountryInfo.Infrastructure.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CountryInfo.Controllers
{
    public class CountriesController : Controller
    {
        private CountriesXMLDatasource datasource;

        // GET: Countries
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAllCountries()
        {
            InitializeDataSource();
            JsonResponseModel result = null;
            try
            {
                var entities = datasource.GetAll();
                result = new JsonResponseModel
                {
                    Code = (int)JsonResponseCode.Ok,
                    Data = entities,
                    Date = DateTime.Now,
                    Message = "OK"
                };
            }
            catch (CantLoadEntityException e)
            {
                result = new JsonResponseModel
                {
                    Code = (int)JsonResponseCode.Error,
                    Data = null,
                    Date = DateTime.Now,
                    Message = e.Message
                };
            }
            catch (Exception ex)
            {
                result = new JsonResponseModel
                {
                    Code = (int)JsonResponseCode.Error,
                    Data = null,
                    Date = DateTime.Now,
                    Message = "Exception occured: " + ex.Message
                };
            }
            return Json(result);
        }

        [HttpPost]
        public ActionResult Details(int id)
        {
            InitializeDataSource();
            JsonResponseModel result = null;
            try
            {
                var entity = datasource.Get(model => model.Id == id);
                result = new JsonResponseModel
                {
                    Code = (int)JsonResponseCode.Ok,
                    Data = entity,
                    Date = DateTime.Now,
                    Message = "OK"
                };
            }
            catch (CantLoadEntityException e)
            {
                result = new JsonResponseModel
                {
                    Code = (int)JsonResponseCode.Error,
                    Data = null,
                    Date = DateTime.Now,
                    Message = e.Message
                };
            }
            catch (Exception ex)
            {
                result = new JsonResponseModel
                {
                    Code = (int)JsonResponseCode.Error,
                    Data = null,
                    Date = DateTime.Now,
                    Message = "Exception occured: " + ex.Message
                };
            }
            return Json(result);
        }

        [HttpPost]
        public ActionResult Add(string model)
        {
            InitializeDataSource();
            JsonResponseModel result = null;
            try
            {
                var entity = new JavaScriptSerializer().Deserialize<CountryViewModel>(model);
                var methodResponse = datasource.Add(entity);
                result = new JsonResponseModel
                {
                    Code = (int)JsonResponseCode.Ok,
                    Data = entity,
                    Date = DateTime.Now,
                    Message = "OK"
                };
            }
            catch (CantAddEntityException e)
            {
                result = new JsonResponseModel
                {
                    Code = (int)JsonResponseCode.Error,
                    Data = null,
                    Date = DateTime.Now,
                    Message = e.Message
                };
            }
            catch (Exception ex)
            {
                result = new JsonResponseModel
                {
                    Code = (int)JsonResponseCode.Error,
                    Data = null,
                    Date = DateTime.Now,
                    Message = "Exception occured: " + ex.Message
                };
            }
            return Json(result);
        }

        [HttpPost]
        public ActionResult Edit(string model)
        {
            InitializeDataSource();
            JsonResponseModel result = null;
            try
            {
                var entity = new JavaScriptSerializer().Deserialize<CountryViewModel>(model);
                var methodResponse = datasource.Add(entity);
                result = new JsonResponseModel
                {
                    Code = (int)JsonResponseCode.Ok,
                    Data = entity,
                    Date = DateTime.Now,
                    Message = "OK"
                };
            }
            catch (CantLoadEntityException e)
            {
                result = new JsonResponseModel
                {
                    Code = (int)JsonResponseCode.Error,
                    Data = null,
                    Date = DateTime.Now,
                    Message = e.Message
                };
            }
            catch (Exception ex)
            {
                result = new JsonResponseModel
                {
                    Code = (int)JsonResponseCode.Error,
                    Data = null,
                    Date = DateTime.Now,
                    Message = "Exception occured: " + ex.Message
                };
            }
            return Json(result);
        }

        [HttpPost]
        public ActionResult Delete(string model)
        {
            InitializeDataSource();
            return Content("");
        }

        private void InitializeDataSource()
        {
            var path = Server.MapPath(PageConfig.XmlDatasourcePath);
            datasource = new CountriesXMLDatasource(path);
        }
    }
}