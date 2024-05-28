using Glossary.Models.Glossary;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Glossary.Controllers
{
    public class TermBodyModel
    {
        // for interact with frontend
        public int id;
        public string? term { get; set; }
        public string? definition {  get; set; }
        public TermBodyModel() 
        {
            term = "";
            definition = "";
        }
    }

    [Route("terms")]
    [ApiController]
    [EnableCors]
    public class TermController : CommonController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            bool successful = true;
            string message = "";
            List<TermBodyModel> result = new List<TermBodyModel>();

            List<Term> terms = tr.GetAllTerms();
            foreach (Term term in terms)
            {
                term.Definition = dr.GetDefinitionByTermId(term.Id);

                result.Add(new TermBodyModel { 
                    id = term.Id,
                    term = term.Name,
                    definition = term.Definition != null ? term.Definition.Description : ""
                });
            }

            return Content(JsonConvert.SerializeObject(new { successful, message, result }));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            bool successful = true;
            string message = "";
            TermBodyModel result = new TermBodyModel();

            Term? term = tr.GetTermById(id);
            if (term != null)
            {
                term.Definition = dr.GetDefinitionByTermId(id);

                result.id = term.Id;
                result.term = term.Name;
                result.definition = term.Definition != null ?  term.Definition.Description : "";
            }

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
                result.Name = term.term;
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
                result.Name = term.term;
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
