using Glossary.Models.Glossary;
using Glossary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Text;

namespace Glossary.Controllers.Api
{
    public class TermBodyModel
    {
        public int id;
        public string name { get; set; }
        public string definition {  get; set; }
        public TermBodyModel() 
        {
            name = "";
            definition = "";
        }
    }

    [Route("api/terms")]
    [ApiController]
    public class TermController : CommonController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            bool successful = true;
            string message = "";
            List<Term> result = tr.GetAllTerms();

            return Content(JsonConvert.SerializeObject(new { successful, message, result }));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            bool successful = true;
            string message = "";
            Term? result = tr.GetTermById(id);

            return Content(JsonConvert.SerializeObject(new { successful, message, result }));
        }

        [HttpPost]
        public IActionResult Create()
        {
            bool successful = true;
            string message = "created";
            Term result = new Term();

            string bodyText = GetRequestBodyText();
            TermBodyModel? term = JsonConvert.DeserializeObject<TermBodyModel>(bodyText);

            if (term != null)
            {
                result.Name = term.name;
                result = tr.CreateTerm(result);

                if (term.definition != null)
                {
                    Definition definition = new Definition();
                    definition.Description = term.definition;
                    result.Definition = dr.CreateDefinition(result.Id, definition);
                }
            }

            return Content(JsonConvert.SerializeObject(new { successful, message, result }));
        }

        [HttpPut]
        public IActionResult Update() 
        {
            bool successful = true;
            string message = "updated";
            Term result = new Term();

            string bodyText = GetRequestBodyText();
            TermBodyModel? term = JsonConvert.DeserializeObject<TermBodyModel>(bodyText);

            if (term != null)
            {
                result.Id = term.id;
                result.Name = term.name;
                result = tr.UpdateTerm(result);

                if (term.definition != null)
                {
                    Definition definition = new Definition();
                    definition.Description = term.definition;
                    result.Definition = dr.UpdateDefinitionByTermId(term.id, definition);
                }
            }

            return Content(JsonConvert.SerializeObject(new { successful, message, result }));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool successful = true;
            string message = "deleted";

            dr.DeleteDefinitionByTermId(id);
            tr.DeleteTermById(id);

            return Content(JsonConvert.SerializeObject(new { successful, message }));
        }
    }
}
