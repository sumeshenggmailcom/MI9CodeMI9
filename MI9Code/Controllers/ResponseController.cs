using MI9.Models;
using MI9.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MI9.Controllers
{
    public class ResponseController : ApiController
    {

        public string Get()
        {
            return "Not implemented please use POST!";
        }

       

        public HttpResponseMessage Post([FromBody]RequestList request)
        {
            if (request != null && ModelState.IsValid)
            {
                return Request.CreateResponse<ResponseList>(HttpStatusCode.OK, new ResponseList { response = Filter.FilterMe(request) });
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, new Error { error = "Could not decode request: JSON parsing failed" });
            
        }

       
    }
}