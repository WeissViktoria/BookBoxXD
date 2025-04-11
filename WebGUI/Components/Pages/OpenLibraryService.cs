using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;


public class OpenLibraryService
{
    private readonly HttpClient _httpClient;
    private const string API_URL = "https://openlibrary.org/search.json?q=";
    private const string BOOK_API_URL = "https://openlibrary.org/api/books?bibkeys=OLID:";

    public OpenLibraryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Sucht nach Büchern anhand einer Abfrage (z.B. Titel oder Autor)
    public async Task<List<Book>> SearchBooks(string query)
    {
        var response = await _httpClient.GetFromJsonAsync<OpenLibraryResponse>($"{API_URL}{query}");
        return response?.Docs ?? new List<Book>();
    }

    public async Task<Book> GetBookByCoverId(int coverId)
    {
        var response = await GetAllBooks(); // oder SearchBooks("random") etc.
        return response.FirstOrDefault(b => b.Cover_I == coverId);
    }


    // Lädt eine zufällige Auswahl an Büchern
    public async Task<List<Book>> GetAllBooks()
    {
        var response = await _httpClient.GetFromJsonAsync<OpenLibraryResponse>($"{API_URL}random");
        return response?.Docs ?? new List<Book>();
    }
    
    public async Task<Book> GetBookDetailsByKey(string key)
    {
        var response = await _httpClient.GetFromJsonAsync<Dictionary<string, object>>($"https://openlibrary.org{key}.json");

        if (response != null)
        {
            var book = new Book
            {
                Title = response.GetValueOrDefault("title")?.ToString(),

                Author_Name = response.GetValueOrDefault("authors") is List<object> authors && authors != null
                    ? authors.Select(a => ((Dictionary<string, object>)a).GetValueOrDefault("name")?.ToString()).ToList()
                    : new List<string>(),

                First_Sentence = response.GetValueOrDefault("first_sentence")?.ToString(),
            
                Publisher = response.GetValueOrDefault("publishers") is List<object> publishers && publishers != null
                    ? publishers.FirstOrDefault()?.ToString()
                    : null,

                First_Publish_Year = Convert.ToInt32(response.GetValueOrDefault("first_publish_year") ?? 0),
            
                Subject = response.GetValueOrDefault("subject") is List<object> subject && subject != null
                    ? subject.Select(s => s.ToString()).ToList()
                    : new List<string>(),

                Number_of_Pages = Convert.ToInt32(response.GetValueOrDefault("number_of_pages") ?? 0),
            
                ISBN = response.GetValueOrDefault("isbn") is List<object> isbn && isbn != null
                    ? isbn.Select(i => i.ToString()).ToList()
                    : new List<string>(),

                // Fetching language information
                Language = response.GetValueOrDefault("languages") is List<object> languages && languages != null
                    ? languages.Select(l => l.ToString()).ToList()
                    : new List<string>()
            };

            return book;
        }

        return null;
    }


    
}

public class OpenLibraryResponse
{
    public List<Book> Docs { get; set; }
}
public class Book
{
    public string Title { get; set; }
    public List<string> Author_Name { get; set; }
    public string First_Sentence { get; set; }
    public int? Cover_I { get; set; }
    public List<string> ISBN { get; set; }
    
    public string Publisher { get; set; } // Publisher hinzufügen
    public int First_Publish_Year { get; set; } // Veröffentlichungsdatum hinzufügen
    public int? Number_of_Pages { get; set; } // Seitenanzahl hinzufügen
    public List<string> Language { get; set; }
    public List<string> Subject { get; set; }

    // Cover-URL generieren
    public string CoverUrl => Cover_I != null ? $"https://covers.openlibrary.org/b/id/{Cover_I}-M.jpg" : null;
}
