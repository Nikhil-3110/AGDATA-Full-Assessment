using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAutomationProject.Model
{
    public class Comment
    {
        public string postid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }

    }
}
