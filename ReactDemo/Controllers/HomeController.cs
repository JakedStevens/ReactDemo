using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReactDemo.Controllers
{
	public class HomeController : Controller
	{
		private readonly ReactDemoDbContext _dbContext;

		public HomeController(ReactDemoDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public ViewResult Index()
		{
			return View();
		}

		[Route("comments")]
		[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
		public async Task<ActionResult> Comments()
		{
			List<Comment> comments = await _dbContext.Comment.ToListAsync();
			return Json(comments);
		}

		[Route("comments/add")]
		[HttpPost]
		public async Task<ActionResult> AddComment(Comment comment)
		{
			comment.CreatedOn = DateTime.Now;
			_dbContext.Add(comment);
			await _dbContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		//public async Task<ViewResult> Edit(int? id)
		//{
		//	if (id == null)
		//	{
		//		return View("../Shared/NotFound");
		//	}

		//	var blogPost = await _dbContext.BlogPost.FindAsync(id);
		//	if (blogPost == null)
		//	{
		//		return View("../Shared/NotFound");
		//	}
		//	return View(blogPost);
		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Edit([Bind("PostId,PostTitle,PostContent,PostCategory,PostDate,PostImageURL")] BlogPost blogPost)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		try
		//		{
		//			_dbContext.Update(blogPost);
		//			await _dbContext.SaveChangesAsync();
		//		}
		//		catch (DbUpdateConcurrencyException)
		//		{
		//			if (!BlogPostExists(blogPost.PostId))
		//			{
		//				return View("../Shared/NotFound");
		//			}
		//			else
		//			{
		//				throw;
		//			}
		//		}
		//		return RedirectToAction(nameof(AllPosts));
		//	}
		//	return View("Index");
		//}

		//// GET: BlogPosts/Delete/{id}
		//public async Task<ViewResult> Delete(int? id)
		//{
		//	if (id == null)
		//	{
		//		return View("../Shared/NotFound");
		//	}

		//	var blogPost = await _dbContext.BlogPost
		//		.FirstOrDefaultAsync(m => m.PostId == id);
		//	if (blogPost == null)
		//	{
		//		return View("../Shared/NotFound");
		//	}

		//	return View(blogPost);
		//}

		//// POST: BlogPosts/Delete/{id}
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public async Task<RedirectToActionResult> DeleteConfirmed(int id)
		//{
		//	var blogPost = await _dbContext.BlogPost.FindAsync(id);
		//	_dbContext.BlogPost.Remove(blogPost);
		//	await _dbContext.SaveChangesAsync();
		//	return RedirectToAction(nameof(AllPosts));
		//}
	}
}
