using Glossary.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Glossary.Controllers.Api
{
    public class CommonController : ControllerBase
    {
        protected TermRepository tr = new TermRepository();
        protected DefinitionRepository dr = new DefinitionRepository();

        public string GetRequestBodyText()
        {
            string ret = "";

            using (var bodyStream = new StreamReader(HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                ret = bodyStream.ReadToEndAsync().Result;
            }

            return ret;
        }
    }
}
