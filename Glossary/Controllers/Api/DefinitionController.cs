using Glossary.Models.Glossary;
using Glossary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Glossary.Controllers.Api
{
    [Route("api/definitions")]
    [ApiController]
    public class DefinitionController : CommonController
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            bool successful = true;
            string message = "";
            Definition? result = dr.GetDefinitionById(id);

            return Content(JsonConvert.SerializeObject(new { successful, message, result }));
        }
    }
}
