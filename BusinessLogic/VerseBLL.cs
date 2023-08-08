using BibleVerseSearch.Models;
using BibleVerseSearch.DataAccess;

namespace BibleVerseSearch.BusinessLogic
{
    public class VerseBLL
    {
        private IVerseDAO verseDAO;

        public VerseBLL(IVerseDAO verseDAO)
        {
            this.verseDAO = verseDAO;
        }

        public List<Verse> GetVerses(string searchTerm, Testament testament)
        {
            // Use verseDAO to fetch data and apply business rules
            return verseDAO.GetVerses(searchTerm, testament);
        }
    }
}
