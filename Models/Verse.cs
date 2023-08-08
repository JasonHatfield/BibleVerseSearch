namespace BibleVerseSearch.Models
{
    public enum Testament
    {
        Old,
        New,
        Both
    }

    public class Verse
    {
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int VerseNumber { get; set; }
        public string Text { get; set; }
        public Testament Testament { get; set; }
    }
}
