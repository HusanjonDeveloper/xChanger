using Microsoft.AspNetCore.Mvc;

namespace xChanger.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class HomeController : ControllerBase
	{
		[HttpGet]
		public string Get() => "xChanger: ";
	}
}