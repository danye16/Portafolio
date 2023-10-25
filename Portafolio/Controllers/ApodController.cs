using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Portafolio.Models;


namespace Portafolio.Controllers
{
	public class ApodController : Controller
	{
		private static readonly HttpClient httpClient = new HttpClient();

		public async Task<ActionResult> Index()
		{
			var response = await httpClient.GetStringAsync("https://api.nasa.gov/planetary/apod?api_key=CQhM7Q1MVfOVLN9kiMFQMVVwcSiwnEXLHLXT30qr");
			var apodResponse = JsonConvert.DeserializeObject<ApodResponse>(response);

			return View(apodResponse);
		}
	}
}
