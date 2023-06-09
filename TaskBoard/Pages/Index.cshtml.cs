using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskBoard.DataAccess;
using TaskBoard.Models;

namespace TaskBoard.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DbContext _db;

        public List<TaskData>? Tasks { get; private set; }

        public IndexModel(DbContext db) =>
            _db = db;

        public void OnGet() =>
            Tasks = _db.List();

        public IActionResult OnGetDelete(Guid id)
        {
            _db.Delete(id);
            return RedirectToPage();
        }
    }
}