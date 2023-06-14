using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskBoard.DataAccess;
using TaskBoard.Models;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace TaskBoard.Pages;

public class TaskModel : PageModel
{
    private readonly IDbContext _db;

    [BindProperty]
    public Guid Id { get; set; }

    [BindProperty]
    public TaskProgress Progress { get; set; }

    [Required]
    [BindProperty]
    public string? Name { get; set; }

    [Required]
    [BindProperty]
    public string? Description { get; set; }

    [BindProperty]
    public DateTime ToBeDone { get; set; }

    [BindProperty]
    public bool IsNew { get; set; }

    public TaskModel(IDbContext db) =>
        _db = db;

    public void OnGet(Guid? id)
    {
        if (id == null)
        {
            Id = Guid.NewGuid();
            ToBeDone = DateTime.Now.AddDays(1);
            IsNew = true;
            return;
        }

        var task = _db.Get(id.Value);
        Id = task.Id;
        Progress = task.Progress;
        Name = task.Name;
        Description = task.Description;
        ToBeDone = task.ToBeDone;
        IsNew = false;
    }

    public IActionResult OnPostCreate() =>
        SaveTask(_db.Insert);

    public IActionResult OnPostSave() =>
        SaveTask(_db.Update);

    private IActionResult SaveTask(Action<TaskData> action)
    {
        action(new TaskData
        {
            Id = Id,
            Progress = Progress,
            Name = Name,
            Description = Description,
            ToBeDone = ToBeDone
        });
        return RedirectToPage("/Index");
    }
}