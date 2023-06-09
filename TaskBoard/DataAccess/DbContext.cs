using LiteDB;
using TaskBoard.Models;

namespace TaskBoard.DataAccess;

public class DbContext
{
    private readonly ILiteCollection<TaskData> _tasks;

    public DbContext(ILiteDatabase db) =>
        _tasks = db.GetCollection<TaskData>();

    public List<TaskData> List() =>
        _tasks.FindAll().ToList();

    public TaskData Get(Guid id) =>
        _tasks.FindById(id);

    public void Insert(TaskData task) =>
        task.Id = _tasks.Insert(task);

    public void Update(TaskData task) =>
        _tasks.Update(task);

    public void Delete(Guid id) =>
        _tasks.Delete(id);
}