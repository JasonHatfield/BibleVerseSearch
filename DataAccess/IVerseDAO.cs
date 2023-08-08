using BibleVerseSearch.Models;

namespace BibleVerseSearch.DataAccess
{
    public interface IVerseDAO
    {
        List<Verse> GetVerses(string searchTerm, Testament testament);
    }
}
