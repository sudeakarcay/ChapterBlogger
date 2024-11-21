using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;

// Generated from Custom Template.

namespace MVCProject.Controllers
{
    public class PostsController : MvcController
    {
        // Service injections:
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public PostsController(
			IPostService postService
            , IUserService userService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _postService = postService;
            _userService = userService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Posts
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _postService.Query().ToList();
            return View(list);
        }

        // GET: Posts/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _postService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["UserId"] = new SelectList(_userService.Query().ToList(), "Record.Id", "Name");
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostModel post)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _postService.Create(post.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = post.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(post);
        }

        // GET: Posts/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _postService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Posts/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PostModel post)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _postService.Update(post.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = post.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(post);
        }

        // GET: Posts/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _postService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Posts/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _postService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
