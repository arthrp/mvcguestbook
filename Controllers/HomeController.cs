using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcGuestBook.Dto;
using MvcGuestBook.Models;
using MvcGuestBook.Repository;

namespace MvcGuestBook.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly PostsRepository _postsRepository;

    public HomeController(ILogger<HomeController> logger, PostsRepository postsRepository)
    {
        _logger = logger;
        _postsRepository = postsRepository;
    
        //TODO: Remove
        if (_postsRepository.GetAll().Count == 0)
        {
            _postsRepository.Insert(new PostDto(){ Id = Guid.NewGuid(), PosterName = "John Doe", Text = "Hello"});
        }
    }

    public IActionResult Index()
    {
        var posts = _postsRepository.GetAll();
        return View("Index", new GuestbookModel(){ Posts = posts });
    }

    [HttpPost]
    public IActionResult AddPost(PostDto post)
    {
        post.Id = Guid.NewGuid();
        _postsRepository.Insert(post);

        return Index();
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
