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
   
    public List<string> Subject { get; set; }

    // Cover-URL generieren
    public string CoverUrl => Cover_I != null ? $"https://covers.openlibrary.org/b/id/{Cover_I}-M.jpg" : null;
}
