using Glossary.Models.Glossary;

namespace Glossary.Repositories
{
    public class TermRepository : ApplicationRepository
    {
        public TermRepository()
        {
            
        }

        public List<Term> GetAllTerms()
        {
            return dbGlossary.Terms.Where(t => t.Name != null).OrderBy(t => t.Name).ToList();
        }

        public List<Term> GetTermsBySearch(string name)
        {
            return GetAllTerms().FindAll(t => t.Name != null && t.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Term? GetTermById(int id)
        {
            return dbGlossary.Terms.FirstOrDefault(t => t.Id == id);
        }

        public Term CreateTerm(Term t)
        {
            dbGlossary.Terms.Add(t);
            dbGlossary.SaveChanges();
            return t;
        }

        public Term UpdateTerm(Term t)
        {
            Term? updated = GetTermById(t.Id);
            if (updated != null)
            {
                updated.Name = t.Name;
                dbGlossary.SaveChanges();
            }
            return t;
        }

        public void DeleteTermById(int term_id)
        {
            Term? deleted = GetTermById(term_id);

            if (deleted != null)
            {
                dbGlossary.Terms.Remove(deleted);
                dbGlossary.SaveChanges();
            }
        }
    }
}