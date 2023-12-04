using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Musify.MVC.Models;
using Musify.MVC.Models.ModelViews.SongModelView;
using Musify.MVC.Persistance;
using System.Diagnostics;

namespace Musify.MVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IALLForOne _allForOne;
        private readonly IMapper _mapper;
        public HomeController(//ILogger<HomeController> logger,
            IALLForOne aLLForOne, IMapper mapper)
        {
            //_logger = logger;
            _allForOne = aLLForOne;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var songs = await _allForOne.SongRepository.GetLatestReleased6Songs();

            var entity = _mapper.Map<List<SongViewModel>>(songs);

            //for (var i = 0; i < songs.Count(); ++i)
            //    entity[i].Artist = songs[i].Artists.ToList();

            return View(entity);
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