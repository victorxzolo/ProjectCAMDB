using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CAMDBScreen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace CAMDBScreen.Controllers
{
    public class RegisterCampaignController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string strpathAPI;
        public RegisterCampaignController(IConfiguration configuration)
        {
            _configuration = configuration;
            strpathAPI = _configuration.GetValue<string>("Pathapi:Local").ToString();
       }

        public IActionResult Index()
        {
            return View();
        }
        public class CampaignCode
        {

   
            public  string campaigncode { get; set; }
           
        }
        public class statusValue
        {
            public string statusvalue { get; set; }
            public string statustext { get; set; }

        }
        public JsonResult LoadCampaignCode(string query)
        {
            var Result = new List<CampaignCode>();
            var c = new CampaignModel();
            c.campaigncode = query;
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(c);
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri( strpathAPI + "api/autosearch"),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = client.SendAsync(request).ConfigureAwait(false);

            var responseInfo = response.GetAwaiter().GetResult();
            if (responseInfo.IsSuccessStatusCode)
            {
                var result = responseInfo.Content.ReadAsStringAsync().Result;

                if (result != null)
                {
                    //data
                    Result = JsonConvert.DeserializeObject<List<CampaignCode>>(result);

                }
            }
            else
            {

                var result = responseInfo.Content.ReadAsStringAsync().Result;
            }




            return Json(new { response = Result });
        
        }

        public JsonResult getStatus()
        {
            List<statusValue> stStatus = new List<statusValue>
            {
            new statusValue { statusvalue = "A", statustext = "Approve" },
            new statusValue { statusvalue = "R", statustext = "Request" },
            new statusValue { statusvalue = "P", statustext = "Pending" },
            new statusValue { statusvalue = "D", statustext = "Delete" },
            new statusValue { statusvalue = "RE", statustext = "Return" }
            };


         return Json(stStatus);
        }



        public List<CampaignModel> GetDataByCampaignCode(string campaigncode)
        {
            var DetailList =  new List<CampaignModel>();
            var c = new CampaignModel();
            c.campaigncode = campaigncode;

            // Getting all company data  
            HttpClient client = new HttpClient();

            //    HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(c);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                // RequestUri = new Uri("http://localhost:18657/api/CampDetail"),
                RequestUri = new Uri(strpathAPI + "api/CampDetail"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

               HttpResponseMessage response = client.SendAsync(request).Result;
            //var response = client.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                //data
                DetailList = JsonConvert.DeserializeObject<List<CampaignModel>>(result);


            }

            return DetailList;
        }
       

            public ActionResult LoadCampaignList(string campaigncode ,string campaignstatus)
        {


          
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            // Skiping number of Rows count  
            var start = Request.Form["start"].FirstOrDefault();
            // Paging Length 10,20  
            var length = Request.Form["length"].FirstOrDefault();
            // Sort Column Name  
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            // Sort Column Direction ( asc ,desc)  
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            // Search Value from (Search box)  
            var searchValue = Request.Form["search[value]"].FirstOrDefault();


             var Result = new List<CampaignModel>();
          
            // Getting all Campaign data  
            var c = new  CampaignModel();
            if (campaigncode == null)
            {
                campaigncode = "";
            }
            c.campaigncode = campaigncode;

            c.campaignstatus = campaignstatus;
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(c);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                //  RequestUri = new Uri("http://localhost:18657/api/campaignsearch"),
                RequestUri = new Uri(strpathAPI + "api/campaignsearch"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = client.SendAsync(request).ConfigureAwait(false);

            var responseInfo = response.GetAwaiter().GetResult();
            if (responseInfo.IsSuccessStatusCode)
            {
                var result = responseInfo.Content.ReadAsStringAsync().Result;
              
                if (result != null)
                {
                    //data
                    Result = JsonConvert.DeserializeObject<List<CampaignModel>>(result);

                }
            }
            else
            {

                var result = responseInfo.Content.ReadAsStringAsync().Result;
            }
           


            //Paging Size (10,20,50,100)  
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

              


                //total number of rows count   
                 recordsTotal = Result.Count();

                //Paging   
                var data = Result.Skip(skip).Take(pageSize).ToList();


                // Returning Json Data
                return Json(new { draw = draw, recordsTotal = recordsTotal, recordsFiltered = recordsTotal, data = data });


        }
    }
}