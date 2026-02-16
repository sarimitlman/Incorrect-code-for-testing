using BL.Api;
using BL.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class BLAIService : IBLAI
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public BLAIService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> GetResponseFromAI(string prompt)
    {
        var requestBody = new
        {
            prompt = prompt
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        var apiUrl = _configuration["AI:ApiUrl"]; // כתובת ה-API שלך
        var apiKey = _configuration["AI:ApiKey"]; // אם נדרש מפתח גישה

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var response = await _httpClient.PostAsync(apiUrl, content);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Failed to get response from AI");

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<AIResponse>(json);

        // מחזיר את הטקסט מהתשובה שהתקבלה
        return result?.Choices?.FirstOrDefault()?.Text ?? "No response";
    }
}
