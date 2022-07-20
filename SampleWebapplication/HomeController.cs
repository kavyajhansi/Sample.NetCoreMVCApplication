using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebapplication
{
    public class HomeController : Controller
    {
        List<Sample> _data = new List<Sample>();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitDetails(Sample fm)
        {
           
            _data.Add(new Sample()
            {
                FirstName = fm.FirstName,
                LastName = fm.LastName
                
            });
            
           if(System.IO.File.Exists("WWWroot/User.Json"))
            {
                using (StreamWriter file = System.IO.File.AppendText("WWWroot/User.Json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, _data);
                    ViewBag.Message = "Scucessfully created User";
                }
            }
           else
            {
               
                System.IO.File.Create("WWWroot/User.Json");
                using(StreamWriter file = System.IO.File.AppendText("WWWroot/User.Json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, _data);
                    ViewBag.Message = "Successfully Created User";
                   
                }
            }
            //   await JsonSerializer.SerializeAsync(createStream, _data);
            return View("Views/Home/Success.cshtml");
        }
    }
}
