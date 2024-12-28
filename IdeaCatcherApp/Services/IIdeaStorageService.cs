using IdeaCatcherApp.Models;

namespace IdeaCatcherApp.Services
{
    public interface IIdeaStorageService
    {
        Task<List<IdeaFolder>> GetFoldersAsync();
        Task SaveFoldersAsync(List<IdeaFolder> folders);
    }
}