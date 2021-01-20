using ems.DTO;
using ems.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FileUploadAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        private IFileService FileService = null;
        public FileController(IFileService _FileService)
        {
            FileService = _FileService;
        }

        [HttpPost]
        [Route("AddFileDetails")]
        public IHttpActionResult AddFile()
        {
            string result = "";
            try
            {
                FileDetailDto file = new FileDetailDto();
                var httpRequest = HttpContext.Current.Request;
                file.Name = httpRequest.Form["UserName"];
                var postedImage = httpRequest.Files["ImageUpload"];
                var postedFile = httpRequest.Files["FileUpload"];
                
                if (postedImage != null)
                {
                    file.Image = new String(Path.GetFileNameWithoutExtension(postedImage.FileName).Take(10).ToArray()).Replace(" ", "-");
                    file.Image = file.Image + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedImage.FileName);
                    var filePath = HttpContext.Current.Server.MapPath("~/Files/" + file.Image);
                    postedImage.SaveAs(filePath);
                }
                if (postedFile != null)
                {
                    file.DocFile = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
                    file.DocFile = file.DocFile + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                    var filePath = HttpContext.Current.Server.MapPath("~/Files/" + file.DocFile);
                    postedFile.SaveAs(filePath);
                }
                
                int i = FileService.addFile(file);
                if (i > 0)
                {
                    result = "File uploaded sucessfully";
                }
                else
                {
                    result = "File uploaded faild";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetFile")]
        //download file api  
        public HttpResponseMessage GetFile(string docFile)
        {
            //Create HTTP Response.  
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            //Set the File Path.  
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Files/") + docFile + ".docx";
            //Check whether File exists.  
            if (!File.Exists(filePath))
            {
                //Throw 404 (Not Found) exception if File not found.  
                response.StatusCode = HttpStatusCode.NotFound;
                response.ReasonPhrase = string.Format("File not found: {0} .", docFile);
                throw new HttpResponseException(response);
            }
            //Read the File into a Byte Array.  
            byte[] bytes = File.ReadAllBytes(filePath);
            //Set the Response Content.  
            response.Content = new ByteArrayContent(bytes);
            //Set the Response Content Length.  
            response.Content.Headers.ContentLength = bytes.LongLength;
            //Set the Content Disposition Header Value and FileName.  
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = docFile + ".docx";
            //Set the File Content Type.  
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(docFile + ".docx"));
            return response;
        }
        [HttpGet]
        [Route("GetFileDetails")]
        public IHttpActionResult GetFile()
        {
            var url = HttpContext.Current.Request.Url;
            IEnumerable<FileDetailDto> lstFile = new List<FileDetailDto>();
            try
            {
                lstFile = FileService.getAllFile();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(lstFile);
        }
        [HttpGet]
        [Route("GetImage")]
        //download Image file api  
        public HttpResponseMessage GetImage(string image)
        {
            //Create HTTP Response.  
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            //Set the File Path.  
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Files/") + image + ".PNG";
            //Check whether File exists.  
            if (!File.Exists(filePath))
            {
                //Throw 404 (Not Found) exception if File not found.  
                response.StatusCode = HttpStatusCode.NotFound;
                response.ReasonPhrase = string.Format("File not found: {0} .", image);
                throw new HttpResponseException(response);
            }
            //Read the File into a Byte Array.  
            byte[] bytes = File.ReadAllBytes(filePath);
            //Set the Response Content.  
            response.Content = new ByteArrayContent(bytes);
            //Set the Response Content Length.  
            response.Content.Headers.ContentLength = bytes.LongLength;
            //Set the Content Disposition Header Value and FileName.  
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = image + ".PNG";
            //Set the File Content Type.  
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(image + ".PNG"));
            return response;
        }
    }
}