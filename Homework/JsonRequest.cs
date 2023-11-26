namespace Homework;

public class JsonRequest {
    private readonly HttpClient _httpClient;
    private readonly string _url;

    public JsonRequest(string url) {
        _httpClient = new HttpClient();
        _url = url;
    }

    public async Task<string> GetJsonAsync() {
        try {
            HttpResponseMessage response = await _httpClient.GetAsync(_url);
            response.EnsureSuccessStatusCode(); // Throw an exception if the request was not successful
            string json = await response.Content.ReadAsStringAsync();
            return json;
        }
        catch (HttpRequestException e) {
            Console.WriteLine("Error occurred during the request: " + e.Message);
            return null;
        }
    }
}