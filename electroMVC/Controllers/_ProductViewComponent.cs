using electroMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using electroMVC.Models;

namespace electroMVC.Controllers
{
	[ViewComponent(Name = "_Product")]
	public class _ProductViewComponent : ViewComponent
	{
		private readonly electroMVCContext _context;

		public _ProductViewComponent(electroMVCContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var _product = _context.Product.ToList();
			return View("_Product", _product);
		}
	}
}
