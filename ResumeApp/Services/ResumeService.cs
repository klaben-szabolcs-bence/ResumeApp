using System.Net.Http.Json;
using System.Text.Json;
using ResumeApp.Models;

namespace ResumeApp.Services;

public class ResumeService
{
    private readonly HttpClient _http;
    private ResumeModel? _resumeData;
    private DateTime? _lastCommitDate;

    public ResumeService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ResumeModel?> GetResumeDataAsync()
    {
        if (_resumeData == null)
        {
            _resumeData = await _http.GetFromJsonAsync<ResumeModel>("data/resume.json");
        }
        return _resumeData;
    }

    public async Task<DateTime?> GetLastCommitDateAsync()
    {
        if (_lastCommitDate != null) return _lastCommitDate;

        try
        {
            var resumeData = await GetResumeDataAsync();
            if (resumeData?.Basics.Repository == null) return null;

            // Extract owner and repo from https://github.com/owner/repo
            var uri = new Uri(resumeData.Basics.Repository);
            var pathParts = uri.AbsolutePath.Trim('/').Split('/');
            if (pathParts.Length < 2) return null;

            var owner = pathParts[0];
            var repo = pathParts[1];

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/repos/{owner}/{repo}/commits");
            request.Headers.Add("User-Agent", "ResumeApp-Blazor");

            var response = await _http.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                var firstCommit = doc.RootElement[0];
                var dateStr = firstCommit.GetProperty("commit").GetProperty("committer").GetProperty("date").GetString();
                if (DateTime.TryParse(dateStr, out var date))
                {
                    _lastCommitDate = date;
                }
            }
        }
        catch
        {
            // Silently fail or log as needed
        }

        return _lastCommitDate;
    }
}
