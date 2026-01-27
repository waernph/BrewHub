using BrewHub_App.Models;
using BrewHub_App.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BrewHub.Data.DTO;
using System.Text.Json;
using PostDTO = BrewHub_App.Models.PostDTO;

namespace BrewHub_App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AllPosts()
        {
            string url = "http://localhost:5217/api/post/all";
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(url);
            var data = await result.Content.ReadFromJsonAsync<List<PostDTO>>();


            return View(data);
        }
        public async Task<IActionResult> NewPost(string title, string body, int categoryId)
        {
            string url = "http://localhost:5217/api/category/newPost";
            HttpClient client = new HttpClient();
            var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "postTitle", title },
                    { "postBody", body },
                    { "categoryId", categoryId.ToString() }
                })
            });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
