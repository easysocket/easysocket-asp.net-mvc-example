using System;
using System.Net;
using System.Text;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EasySocketDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Post(String privateKey, String data)
        {
            return !Request.IsAjaxRequest() ? 
                Json(new { result = "Must be ajax request" }) :
                Json(new { result = HttpPost("http://api.easysocket.io", "privateKey=" + privateKey + "&esocket=" + data) });
        }


        private static string HttpPost(string uri, string parameters)
        {
            var req = WebRequest.Create(uri);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            var bytes = Encoding.ASCII.GetBytes(parameters);
            req.ContentLength = bytes.Length;
            var os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            var resp = req.GetResponse();
            var sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
    }
}
