using Glossary.Models.Glossary;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Glossary.Controllers
{
    [Route("definitions")]
    [ApiController]
    [EnableCors]
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
