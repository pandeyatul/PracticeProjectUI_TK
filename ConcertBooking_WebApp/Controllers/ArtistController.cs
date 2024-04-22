using ConcertBooking_Entities;
using ConcertBooking_Repository.Concert_Interfaces;
using ConcertBooking_WebApp.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking_WebApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ArtistController : Controller
    {
        private readonly IArtist _artist;
        private readonly IUtility _utilityl;
        public ArtistController(IArtist artist,IUtility utility)
        {
            _artist = artist;
            _utilityl = utility;
        }

        public async Task<IActionResult> Index()
        {
            var artistdata = await _artist.GetAll();
            List<ArtistViewModel> artistlist = new List<ArtistViewModel>();
            foreach (var item in artistdata)
            {
                var artistinfo = new ArtistViewModel()
                {
                    Id = item.Id,
                    Artist_Name=item.Name,
                    Bio=item.Bio,
                    ImageUrl=item.ImageUrl
                };
                artistlist.Add(artistinfo);
            }
            return View(artistlist);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            if (id > 0)
            {
                var x = _artist.GetById(id);
                var artistinfo = new Artist()
                {

                };
                return View(artistinfo);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Artist artist)
        {
            var artistinfo = new Artist()
            {
                Id=artist.Id,
                Name=artist.Name,
                Bio=artist.Bio,
            };
            if (artist.ImageFile!=null)
            {
                artistinfo.ImageUrl =await _utilityl.SaveImage("ArtistImage",artist?.ImageFile);
            }
            
           await _artist.Save(artistinfo);
            return RedirectToAction("Index", "Artist");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateArtist(int id)
        {
            if (id > 0)
            {
                var x =await _artist.GetById(id);
                var artistinfo = new Artist()
                {
                    Id=x.Id,
                    Name=x.Name,
                    Bio=x.Bio,
                    ImageUrl=x.ImageUrl
                };
                return View(artistinfo);
            }
            return RedirectToAction("Index", "Artist");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateArtist(Artist artist)
        {
                var x = await _artist.GetById(artist.Id);
                x.Id = artist.Id;
                x.Name = artist.Name;
                x.Bio = artist.Bio;
            if (artist.ImageFile!=null)
            {
                x.ImageUrl =await _utilityl.EditImage("ArtistImage",artist.ImageFile,artist?.ImageUrl);

            }
                await _artist.Edit(x);
                return RedirectToAction("Index", "Artist");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                await _artist.RemoveData(id);
                return RedirectToAction("Index", "Artist");
            }
            return RedirectToAction("Index", "Artist");
        }
    }
}
