using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MI9.Models;
using MI9.Controllers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Net.Http;
using System.Net;
using MI9;
using MI9.Helper;

namespace MI9Tests
{
    [TestClass]
    public class ResponseControllerTest
    {
       
        private RequestList MyRequestInput()
        {
            var request = new RequestList
            {
                payload = new[] { new Payload
            {
                country = "AUD",
                description = "Test for MI9",
                drm = true,
                episodeCount = 3,
                image = new Image
                {
                    showImage = "https://www.google.com.au/search?q=mi9+images&espv=2&biw=1366&bih=667&source=lnms&tbm=isch&sa=X&ei=2YWaVaaUNoee8QXl8bngDQ&ved=0CAYQ_AUoAQ&dpr=1#imgrc=Vz2XqwEL-gA6nM%3A"
                },
                language = "English",
                nextEpisode = null,
                primaryColour = "#1B201E",
                seasons = new[] { new Season { slug = "testMI/Mi9/season/1" } },
                slug = "testMI/Mi9/",
                title = "Mi9",
                tvChannel = "ABC"
            } }
            };
            return request;
        }

        private ResponseController MyControllerToTest()
        {
            var controller = new ResponseController();
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            return controller;
        }

        [TestMethod]
        public void StatusCodeOK_RequestIsValid()
        {

            var controller = MyControllerToTest();
            var request = MyRequestInput();
            var status = controller.Post(request);

            //Assert
            Assert.IsNotNull(status);
            Assert.AreEqual(status.StatusCode, HttpStatusCode.OK);

        }


        [TestMethod]
        public void StatusCodeBadRequest_RequestIsInvalid()
        {

            var controller = MyControllerToTest();
            controller.ModelState.AddModelError("Key", "Error");
            var request = MyRequestInput();
            var status = controller.Post(request);

            //Assert
            Assert.IsNotNull(status);
            Assert.AreEqual(status.StatusCode, HttpStatusCode.BadRequest);

        }

        [TestMethod]
        public void StatusCodeBadRequest_RequestIsNull()
        {

            var controller = MyControllerToTest();
            RequestList request = null;
            var status = controller.Post(request);

            //Assert
            Assert.IsNotNull(status);
            Assert.AreEqual(status.StatusCode, HttpStatusCode.BadRequest);

        }


        [TestMethod]
        public void ErrorMessage_BadRequestSent()
        {

            var controller = MyControllerToTest();
            RequestList request = null;
            var response = controller.Post(request);
            var error = (ObjectContent<Error>)response.Content;
            var status = ((Error)error.Value).error;

            //Assert
            Assert.IsNotNull(status);
            Assert.AreEqual(status, "Could not decode request: JSON parsing failed");

        }

        [TestMethod]
        public void Response_WhenRequestIsValid()
        {

            var controller = MyControllerToTest();
            var request = MyRequestInput();
            var status = controller.Post(request);

            //Assert
            Filter.FilterMe(request);

        }


    }
       
}
