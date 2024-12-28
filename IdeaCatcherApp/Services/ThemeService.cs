using Blazored.LocalStorage;

namespace IdeaCatcherApp.Services;

public class ThemeService
{
    private readonly ILocalStorageService _localStorage;
    public event Action<string>? OnThemeChange;

    public ThemeService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task SetThemeAsync(string theme)
    {
        await _localStorage.SetItemAsync("theme", theme);
        OnThemeChange?.Invoke(theme);
    }

    public async Task<string> GetThemeAsync()
    {
        return await _localStorage.GetItemAsync<string>("theme") ?? "system";
    }
}