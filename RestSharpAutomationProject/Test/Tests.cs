using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharpAutomationProject.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RestSharpAutomationProject
{
    [TestFixture]
    public class Tests
    {   

        [Test, Description("Verify GET request for Posts")]
        public void VerifyGETResponse()
        {
            var helper = new Helper<Post>();
            var response = helper.GETData("posts/2");
            
            Assert.That(response.userId, Is.EqualTo("1"), "Id is not correct.");
            Assert.That(response.title, Is.EqualTo("qui est esse"), "Title is not correct.");
            Assert.That(response.body, Is.EqualTo("est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"), "Body is not correct.");
            
        }

        [Test, Description("Verify POST request for Posts")]
        public void VerifyPOST()
        {
            string payload = @"{ 
                                    ""userid"":""Test123"",
                                    ""id"":""101"",
                                    ""title"":""Test Title"",
                                    ""body"":""Test Body""
                              }";
            
            var helper = new Helper<Post>();
            var response = helper.POSTData("posts/", payload);

            Assert.That(response.userId, Is.EqualTo("Test123"), "Userid is not correct.");
            Assert.That(response.id, Is.EqualTo("101"), "Id is not correct.");
            Assert.That(response.title, Is.EqualTo("Test Title"), "Title is not correct.");
            Assert.That(response.body, Is.EqualTo("Test Body"), "Body is not correct.");

        }
        
        [Test, Description("Verify PUT request for Posts/{postid}")]
        public void VerifyPUT()
        {
            string payload = @"{ 
                                    ""userid"":""Test1234"",                                    
                                    ""title"":""Test Title"",
                                    ""body"":""Test Body""
                              }";

            var helper = new Helper<Post>();
            var response = helper.PUTData("posts/1", payload);

            Assert.That(response.userId, Is.EqualTo("Test1234"), "Userid is not correct.");            
            Assert.That(response.title, Is.EqualTo("Test Title"), "Title is not correct.");
            Assert.That(response.body, Is.EqualTo("Test Body"), "Body is not correct.");

        }

        [Test, Description("Verify DELETE request for Posts")]
        public void VerifyDELETE()
        {            
            var helper = new Helper<Post>();
            var response = helper.DELETEData("posts/20");
            if (response.StatusCode == HttpStatusCode.OK)
                Assert.Pass();
            else
            {
                Assert.Fail();
            }
            
        }

        [Test, Description("Verify GET request for Comments")]
        public void VerifyCommentGET()
        {
            var helper = new Helper<Comment>();
            var response = helper.Comment_GETData("comments?postId=4");

            Assert.That(response[0].postid, Is.EqualTo("4"), "PostId is not correct.");
            Assert.That(response[0].id, Is.EqualTo("16"), "ID is not correct.");
            Assert.That(response[0].name, Is.EqualTo("perferendis temporibus delectus optio ea eum ratione dolorum"), "Name is not correct.");
            Assert.That(response[0].email, Is.EqualTo("Christine@ayana.info"), "Email is not correct.");
            Assert.That(response[0].body, Is.EqualTo("iste ut laborum aliquid velit facere itaque\nquo ut soluta dicta voluptate\nerror tempore aut et\nsequi reiciendis dignissimos expedita consequuntur libero sed fugiat facilis"), "Body is not correct.");

        }

        [Test, Description("Verify Post request for Commnets")]
        public void VerifyCommentPOST()
        {
            string payload = @"{ 
                                    ""postId"":""12344"",
                                    ""id"":""10101"",
                                    ""name"":""Nikhil"",
                                    ""email"":""test@test.com"",
                                    ""body"":""Test Body""
                              }";

            var helper = new Helper<Comment>();
            var response = helper.Comment_POSTData("posts/1/comments", payload);

            Assert.That(response.postid, Is.EqualTo("1"), "Userid is not correct.");            
            Assert.That(response.name, Is.EqualTo("Nikhil"), "Id is not correct.");
            Assert.That(response.email, Is.EqualTo("test@test.com"), "Title is not correct.");
            Assert.That(response.body, Is.EqualTo("Test Body"), "Body is not correct.");

        }
        

    }
}