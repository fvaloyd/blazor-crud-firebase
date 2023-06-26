using Blazored.LocalStorage;

namespace Client;

public class TodoService
{
    private readonly ILocalStorageService _localStorageService;

    public TodoService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<List<Todo>> GetAsync()
    {
        var todos = await _localStorageService.GetItemAsync<Todo[]>("todos");
        return todos is null
            ? new List<Todo>()
            : todos.ToList();
    }

    public async Task SaveAsync(List<Todo> todos)
    {
        await _localStorageService.SetItemAsync("todos", todos);
    }
}

public class Todo
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public bool IsComplete { get; set; } = false;
    public Todo()
    {
        
    }

    public Todo(string title)
    {
        Title = title;
    }
}
