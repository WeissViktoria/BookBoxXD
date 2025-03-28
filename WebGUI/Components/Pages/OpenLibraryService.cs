using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Json;


public class OpenLibraryService
{
    private readonly HttpClient _httpClient;
    private const string API_URL = "https://openlibrary.org/search.json?q=";

    public OpenLibraryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Book>> SearchBooks(string query)
    {
        var response = await _httpClient.GetFromJsonAsync<OpenLibraryResponse>($"{API_URL}{query}");
        return response?.Docs ?? new List<Book>();
    }
    
    
    public async Task<List<Book>> GetAllBooks()
    {
        var response = await _httpClient.GetFromJsonAsync<OpenLibraryResponse>($"{API_URL}{"ab"}");
        return response?.Docs ?? new List<Book>();
    }
   public async Task<Book> GetBookById(int bookId)
       {
           // Angenommene URL für die Open Library API. Ersetzen Sie dies durch die tatsächliche URL Ihrer API
           var response = await _httpClient.GetAsync($"https://openlibrary.org/api/books/{bookId}");
   
           if (response.IsSuccessStatusCode)
           {
               var book = await response.Content.ReadFromJsonAsync<Book>(); // Oder verwenden Sie Ihre eigene Methode zum Deserialisieren
               return book;
           }
           else
           {
               return null;
           }
       }


}

// Models
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

    // Cover-URL generieren
    public string CoverUrl => Cover_I != null ? $"https://covers.openlibrary.org/b/id/{Cover_I}-M.jpg" : null;
}