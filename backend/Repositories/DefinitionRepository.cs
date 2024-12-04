//using Glossary.Models.Glossary;
using Glossary.Models.GlossaryLite;

namespace Glossary.Repositories
{
    public class DefinitionRepository : ApplicationRepository
    {
        public DefinitionRepository()
        {
            
        }

        public Definition? GetDefinitionById(int id)
        {
            return dbGlossary.Definitions.FirstOrDefault(t => t.Id == id);
        }

        public Definition? GetDefinitionByTermId(int term_id)
        {
            return dbGlossary.Definitions.FirstOrDefault(t => t.TermId == term_id);
        }

        public Definition CreateDefinition(int term_id, Definition d)
        {
            Definition tobeAdded = new Definition();
            //tobeAdded.Term = t;
            tobeAdded.TermId = term_id;
            tobeAdded.Description = d.Description;

            dbGlossary.Definitions.Add(tobeAdded);
            dbGlossary.SaveChanges();
            return tobeAdded;
        }

        public Definition UpdateDefinitionByTermId(int term_id, Definition d)
        {
            Definition? updated = GetDefinitionByTermId(term_id);
            if (updated != null)
            {
                updated.Description = d.Description;
                dbGlossary.SaveChanges();
            }
            return d;
        }

        public void DeleteDefinitionById(int definition_id)
        {
            Definition? deleted = GetDefinitionById(definition_id);

            if (deleted != null)
            {
                dbGlossary.Definitions.Remove(deleted);
                dbGlossary.SaveChanges();
            }
        }

        public void DeleteDefinitionByTermId(int term_id)
        {
            Definition? deleted = GetDefinitionByTermId(term_id);

            if (deleted != null)
            {
                dbGlossary.Definitions.Remove(deleted);
                dbGlossary.SaveChanges();
            }
        }
    }
}