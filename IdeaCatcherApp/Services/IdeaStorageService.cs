using Blazored.LocalStorage;
using IdeaCatcherApp.Models;

namespace IdeaCatcherApp.Services;

public interface IIdeaStorageService
{
    Task<List<IdeaFolder>> GetFoldersAsync();
    Task SaveFoldersAsync(List<IdeaFolder> folders);
}

public class IdeaStorageService : IIdeaStorageService
{
    private readonly ILocalStorageService _localStorage;
    private const string STORAGE_KEY = "idea_folders";

    public IdeaStorageService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<List<IdeaFolder>> GetFoldersAsync()
    {
        try
        {
            var folders = await _localStorage.GetItemAsync<List<IdeaFolder>>(STORAGE_KEY);
            return folders ?? new List<IdeaFolder>();
        }
        catch
        {
            return new List<IdeaFolder>();
        }
    }

    public async Task SaveFoldersAsync(List<IdeaFolder> folders)
    {
        await _localStorage.SetItemAsync(STORAGE_KEY, folders);
    }
}