using Blazored.LocalStorage;
using IdeaCatcherApp.Models;

namespace IdeaCatcherApp.Services;

public interface IIdeaStorageService
{
    Task<List<IdeaFolder>> GetFoldersAsync();
    Task<IdeaFolder> CreateFolderAsync(string name);
    Task<IdeaNote> AddNoteToFolderAsync(string folderId, IdeaNote note);
    Task SaveChangesAsync();
}

public class LocalStorageIdeaService : IIdeaStorageService
{
    private readonly ILocalStorageService _localStorage;
    private const string STORAGE_KEY = "ideacatcher_data";

    public LocalStorageIdeaService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<List<IdeaFolder>> GetFoldersAsync()
    {
        return await _localStorage.GetItemAsync<List<IdeaFolder>>(STORAGE_KEY)
            ?? new List<IdeaFolder>();
    }

    public async Task<IdeaFolder> CreateFolderAsync(string name)
    {
        var folders = await GetFoldersAsync();
        var newFolder = new IdeaFolder { Name = name };
        folders.Add(newFolder);
        await _localStorage.SetItemAsync(STORAGE_KEY, folders);
        return newFolder;
    }

    public async Task<IdeaNote> AddNoteToFolderAsync(string folderId, IdeaNote note)
    {
        var folders = await GetFoldersAsync();
        var folder = folders.FirstOrDefault(f => f.Id == folderId);
        if (folder == null) throw new KeyNotFoundException("Folder not found");

        folder.Notes.Add(note);
        await SaveChangesAsync();
        return note;
    }

    public async Task SaveChangesAsync()
    {
        var folders = await GetFoldersAsync();
        await _localStorage.SetItemAsync(STORAGE_KEY, folders);
    }
}