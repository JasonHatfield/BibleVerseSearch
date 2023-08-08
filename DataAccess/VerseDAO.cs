using BibleVerseSearch.Models;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BibleVerseSearch.DataAccess
{
    public class VerseDAO : IVerseDAO
    {
        private string connectionString;

        public VerseDAO(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Verse> GetVerses(string searchTerm, Testament testament)
        {
            List<Verse> verses = new List<Verse>();

            // Connect to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Define the base query
                string query = "SELECT ke.n as Book, ta.c as Chapter, ta.v as VerseNumber, ta.t as Text FROM t_asv ta INNER JOIN key_english ke ON ta.b = ke.b WHERE ta.t LIKE @SearchTerm";

                // Modify the query based on the testament
                if (testament == Testament.Old)
                {
                    query += " AND ta.b <= 39"; // Old Testament books have b <= 39
                }
                else if (testament == Testament.New)
                {
                    query += " AND ta.b > 39"; // New Testament books have b > 39
                }

                // Create a new SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                    // Execute the command and read the results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create a new Verse object for each row
                            Verse verse = new Verse
                            {
                                Book = reader["Book"].ToString(),
                                Chapter = int.Parse(reader["Chapter"].ToString()),
                                VerseNumber = int.Parse(reader["VerseNumber"].ToString()),
                                Text = reader["Text"].ToString(),
                                Testament = testament
                            };

                            // Check if the verse text contains the search term as a whole word
                            if (Regex.IsMatch(verse.Text, @"\b" + Regex.Escape(searchTerm) + @"\b", RegexOptions.IgnoreCase))
                            {
                                // Add the verse to the list
                                verses.Add(verse);
                            }
                        }
                    }
                }
            }

            // Return the list of verses
            return verses;
        }
    }
}
