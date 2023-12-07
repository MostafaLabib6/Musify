using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Musify.MVC.Infrastructure.MailService;
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
        private readonly IEmailService _emailService;
        public HomeController(//ILogger<HomeController> logger,
            IALLForOne aLLForOne, IMapper mapper, IEmailService emailService)
        {
            //_logger = logger;
            _allForOne = aLLForOne;
            _mapper = mapper;
            _emailService = emailService;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var songs = await _allForOne.SongRepository.GetLatestReleased6Songs();

            var entity = _mapper.Map<List<SongViewModel>>(songs);

            //var email = new Email
            //{
            //    Body="Lege-Cy Released new Album with 3 Songs... Huary up to Listen",
            //    Subject ="The Latest Released Songs Now Available",
            //    To="mostafa.ashraf500030@gmail.com",
            //};
            //await _emailService.SendEmail(email);



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