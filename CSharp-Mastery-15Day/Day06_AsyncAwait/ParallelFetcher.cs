// ParallelFetcher.cs
// Async/Await and parallel fetching demo
// ParallelFetcher.cs
// Async/Await and parallel fetching demo

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class ParallelFetcher
{
    private readonly HttpClient _httpClient;

    public ParallelFetcher(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task FetchAllAsync()
    {
        var urls = new List<string>
        {
            "https://api.bfsi-core.in/employees/101",
            "https://api.bfsi-core.in/employees/102",
            "https://api.bfsi-core.in/employees/103"
        };

        var fetchTasks = new List<Task<string>>();

        foreach (var url in urls)
        {
            fetchTasks.Add(FetchAsync(url));
        }

        var results = await Task.WhenAll(fetchTasks);

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }

    private async Task<string> FetchAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}