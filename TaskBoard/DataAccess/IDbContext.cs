using TaskBoard.Models;

namespace TaskBoard.DataAccess;

public interface IDbContext
{
    List<TaskData> List();
    TaskData Get(Guid id);
    void Insert(TaskData task);
    void Update(TaskData task);
    void Delete(Guid id);
}