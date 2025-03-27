using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

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