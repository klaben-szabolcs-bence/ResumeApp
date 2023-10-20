using Microsoft.JSInterop;
namespace ResumeApp.Services;
public class BrowserModeService
{
    private readonly IJSRuntime _jsRuntime;
    public BrowserModeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    public async Task SetDarkModeAsync(bool darkMode)
    {
        await _jsRuntime.InvokeVoidAsync("ui", "mode", darkMode ? "dark" : "light");
    }

    public async Task<bool> GetDarkModeAsync()
    {
        return await _jsRuntime.InvokeAsync<string>("ui", "mode") == "dark";
    }

    public async Task<bool> GetDarkModePreferenceAsync()
    {
        return await _jsRuntime.InvokeAsync<bool>("IsDarkMode");
    }

    public async Task ToggleDarkModeAsync()
    {
        await SetDarkModeAsync(!await GetDarkModeAsync());
    }
}