using Microsoft.AspNetCore.Mvc;

namespace CodeDemo14112023.Areas.Admin.Controllers
{
	public class BaseController : Controller
	{
		protected void SetAlert(string msg, string type)
		{
			TempData["AlertMessage"] = msg;
			if (type == "success")
			{
				TempData["Type"] = "alert-success";
			}
			if (type == "warning")
			{
				TempData["Type"] = "alert-warning";
			}
			if (type == "error")
			{
				TempData["Type"] = "alert-danger";
			}
		}
	}
}
