using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PerformanceTesterCSS.Entities;
using PerformanceTesterCSS.Helpers;
using PerformanceTesterCSS.ViewModels.Performance;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTesterCSS.Controllers
{
    public class PerformanceController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbCtx _context;

        public PerformanceController(ILogger<HomeController> logger, DbCtx dbCtx)
        {
            _logger = logger;
            _context = dbCtx;
        }

        public async Task<String> PerformFullTestOne()
        {
            //WARM UP
            List<Participation> participations = await _context.Participations.Include(p => p.Season).Include(p => p.User).ToListAsync();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Full test:\n");
            Stopwatch stopwatch = new Stopwatch();

            await SingleTestClassic(stopwatch, stringBuilder);
            await MultiTestClassic(stopwatch, stringBuilder);

            stringBuilder.Append("Finished");

            return stringBuilder.ToString();
        }

        public async Task SingleTestClassic(Stopwatch stopwatch, StringBuilder stringBuilder)
        {
            stopwatch.Start();
            List<ParticipationViewModel> participationViewModels001X = await GetParticipationViewModelsClassic();
            stopwatch.Stop();
            long elapsedPrepare001X = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            stopwatch.Start();
            String html001X = await this.RenderViewAsync<List<ParticipationViewModel>>("ParticipationsIndexClassic", participationViewModels001X);
            stopwatch.Stop();
            long elapsedView001X = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            stringBuilder.Append("Elapsed at classic prepare: " + elapsedPrepare001X + ", at making view: " + elapsedView001X + ", html size: " + html001X.Length + "\n");

        }

        public async Task MultiTestClassic(Stopwatch stopwatch, StringBuilder stringBuilder)
        {
            stopwatch.Start();
            List<ParticipationViewModel> participationViewModels001 = null;
            for (int i = 0; i < 100; i++)
            {
                participationViewModels001 = await GetParticipationViewModelsClassic();
            }
            stopwatch.Stop();
            long elapsedPrepare001 = stopwatch.ElapsedMilliseconds / 100;
            stopwatch.Reset();

            String html001 = null;
            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                html001 = await this.RenderViewAsync<List<ParticipationViewModel>>("ParticipationsIndexClassic", participationViewModels001);
                //html001 = "test";
            }
            stopwatch.Stop();
            long elapsedView001 = stopwatch.ElapsedMilliseconds / 10;
            stopwatch.Reset();

            stringBuilder.Append("Approx elapsed at classic prepare: " + elapsedPrepare001 + ", at making view: " + elapsedView001 + ", html size: " + html001.Length + "\n");
        }

        public async Task SingleTestClassicCPY(Stopwatch stopwatch, StringBuilder stringBuilder)
        {

        }

        public async Task<String> PerformFullTestTwo()
        {
            //WARM UP
            List<User> users = await _context.Users.ToListAsync();
            List<Season> seasons = await _context.Seasons.ToListAsync();
            List<Participation> participations = await _context.Participations.ToListAsync();
            //List<Participation> participations = await _context.Participations.Include(p => p.Season).Include(p => p.User).ToListAsync();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Full test:\n");
            Stopwatch stopwatch = new Stopwatch();

            /*stopwatch.Start();
            IActionResult actionResult001 = await ParticipationsIndexClassic();
            stopwatch.Stop();
            stringBuilder.Append("Elapsed total at classic: " + stopwatch.ElapsedMilliseconds + "\n");
            stopwatch.Reset();*/

            await SingleTestWithSearch(stopwatch, stringBuilder);
            await SingleTestWithDictionarySearch(stopwatch, stringBuilder);
            await SingleTestWithSingleRetrieve(stopwatch, stringBuilder);

            await MultiTestWithSearch(stopwatch, stringBuilder);
            await MultiTestWithDictionarySearch(stopwatch, stringBuilder);
            await MultiTestWithSingleRetrieve(stopwatch, stringBuilder);

            stringBuilder.Append("Finished");

            return stringBuilder.ToString();
        }

        public async Task SingleTestWithSearch(Stopwatch stopwatch, StringBuilder stringBuilder)
        {
            stopwatch.Start();
            List<ParticipationViewModel> participationViewModels002X = await GetParticipationViewModelsWithSearch();
            stopwatch.Stop();
            long elapsedPrepare002X = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            stopwatch.Start();
            String html002X = await this.RenderViewAsync<List<ParticipationViewModel>>("ParticipationsIndexWithSearch", participationViewModels002X);
            stopwatch.Stop();
            long elapsedView002X = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            stringBuilder.Append("Elapsed at prepare at with search: " + elapsedPrepare002X + ", at making view: " + elapsedView002X + ", html size: " + html002X.Length + "\n");
        }

        public async Task SingleTestWithDictionarySearch(Stopwatch stopwatch, StringBuilder stringBuilder)
        {
            stopwatch.Start();
            List<ParticipationViewModel> participationViewModels003X = await GetParticipationViewModelsWithDictionarySearch();
            stopwatch.Stop();
            long elapsedPrepare003X = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            stopwatch.Start();
            String html003X = await this.RenderViewAsync<List<ParticipationViewModel>>("ParticipationsIndexWithDictionarySearch", participationViewModels003X);
            stopwatch.Stop();
            long elapsedView003X = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            stringBuilder.Append("Elapsed at prepare at with dictionary search: " + elapsedPrepare003X + ", at making view: " + elapsedView003X + ", html size: " + html003X.Length + "\n");
        }

        public async Task SingleTestWithSingleRetrieve(Stopwatch stopwatch, StringBuilder stringBuilder)
        {
            stopwatch.Start();
            List<ParticipationViewModel> participationViewModels004X = await GetParticipationViewModelsWithSingleRetrieve();
            stopwatch.Stop();
            long elapsedPrepare004X = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            stopwatch.Start();
            String html004X = await this.RenderViewAsync<List<ParticipationViewModel>>("ParticipationsIndexWithSingleRetrieve", participationViewModels004X);
            stopwatch.Stop();
            long elapsedView004X = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            stringBuilder.Append("Elapsed at prepare at with single retrieve: " + elapsedPrepare004X + ", at making view: " + elapsedView004X + ", html size: " + html004X.Length + "\n");
        }

        public async Task MultiTestWithSearch(Stopwatch stopwatch, StringBuilder stringBuilder)
        {
            stopwatch.Start();
            List<ParticipationViewModel> participationViewModels002 = null;
            for (int i = 0; i < 100; i++)
            {
                participationViewModels002 = await GetParticipationViewModelsWithSearch();
            }
            stopwatch.Stop();
            long elapsedPrepare002 = stopwatch.ElapsedMilliseconds / 100;
            stopwatch.Reset();

            String html002 = null;
            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                html002 = await this.RenderViewAsync<List<ParticipationViewModel>>("ParticipationsIndexWithSearch", participationViewModels002);
                //html002 = "test";
            }
            stopwatch.Stop();
            long elapsedView002 = stopwatch.ElapsedMilliseconds / 10;
            stopwatch.Reset();

            stringBuilder.Append("Approx elapsed at prepare at with search: " + elapsedPrepare002 + ", at making view: " + elapsedView002 + ", html size: " + html002.Length + "\n");
        }

        public async Task MultiTestWithDictionarySearch(Stopwatch stopwatch, StringBuilder stringBuilder)
        {
            stopwatch.Start();
            List<ParticipationViewModel> participationViewModels003 = null;
            for (int i = 0; i < 100; i++)
            {
                participationViewModels003 = await GetParticipationViewModelsWithDictionarySearch();
            }
            stopwatch.Stop();
            long elapsedPrepare003 = stopwatch.ElapsedMilliseconds / 100;
            stopwatch.Reset();

            String html003 = null;
            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                html003 = await this.RenderViewAsync<List<ParticipationViewModel>>("ParticipationsIndexWithDictionarySearch", participationViewModels003);
                //html003 = "test";
            }
            stopwatch.Stop();
            long elapsedView003 = stopwatch.ElapsedMilliseconds / 10;
            stopwatch.Reset();

            stringBuilder.Append("Approx elapsed at prepare at with dictionary search: " + elapsedPrepare003 + ", at making view: " + elapsedView003 + ", html size: " + html003.Length + "\n");
        }

        public async Task MultiTestWithSingleRetrieve(Stopwatch stopwatch, StringBuilder stringBuilder)
        {
            stopwatch.Start();
            List<ParticipationViewModel> participationViewModels004 = null;
            for (int i = 0; i < 100; i++)
            {
                participationViewModels004 = await GetParticipationViewModelsWithSingleRetrieve();
            }
            stopwatch.Stop();
            long elapsedPrepare004 = stopwatch.ElapsedMilliseconds / 100;
            stopwatch.Reset();

            String html004 = null;
            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                html004 = await this.RenderViewAsync<List<ParticipationViewModel>>("ParticipationsIndexWithSingleRetrieve", participationViewModels004);
                //html004 = "test";
            }
            stopwatch.Stop();
            long elapsedView004 = stopwatch.ElapsedMilliseconds / 10;
            stopwatch.Reset();

            stringBuilder.Append("Approx elapsed at prepare at with single retrieve: " + elapsedPrepare004 + ", at making view: " + elapsedView004 + ", html size: " + html004.Length + "\n");
        }

        private async Task<List<ParticipationViewModel>> GetParticipationViewModelsClassic()
        {
            List<Participation> participations = await _context.Participations.Include(p => p.Season).Include(p => p.User).ToListAsync();
            List<ParticipationViewModel> participationViewModels = new List<ParticipationViewModel>();

            foreach (Participation part in participations)
            {
                participationViewModels.Add(new ParticipationViewModel
                {
                    Id = part.Id,
                    User = part.User.Degree + " " + part.User.FirstName + " " + part.User.LastName,
                    Season = part.Season.Name + " " + part.Season.EditionNumber,
                    ConfPart = part.ConferenceParticipation.GetValueOrDefault(),
                    PaperPub = part.PaperPublication.GetValueOrDefault()
                });
            }

            return participationViewModels;
        }

        private async Task<List<ParticipationViewModel>> GetParticipationViewModelsWithSingleRetrieve()
        {
            List<Participation> participations = await _context.Participations.ToListAsync();
            List<ParticipationViewModel> participationViewModels = new List<ParticipationViewModel>();

            foreach (Participation part in participations)
            {
                part.User = _context.Users.Find(part.UserId);
                part.Season = _context.Seasons.Find(part.SeasonId);
                participationViewModels.Add(new ParticipationViewModel
                {
                    Id = part.Id,
                    User = part.User.Degree + " " + part.User.FirstName + " " + part.User.LastName,
                    Season = part.Season.Name + " " + part.Season.EditionNumber,
                    ConfPart = part.ConferenceParticipation.GetValueOrDefault(),
                    PaperPub = part.PaperPublication.GetValueOrDefault()
                });
            }

            return participationViewModels;
        }

        private async Task<List<ParticipationViewModel>> GetParticipationViewModelsWithSearch()
        {
            List<User> users = await _context.Users.ToListAsync();
            List<Season> seasons = await _context.Seasons.ToListAsync();
            List<Participation> participations = await _context.Participations.ToListAsync();
            List<ParticipationViewModel> participationViewModels = new List<ParticipationViewModel>();

            foreach (Participation part in participations)
            {
                part.User = users.FirstOrDefault(p => p.Id == part.UserId);
                part.Season = seasons.FirstOrDefault(p => p.Id == part.SeasonId);
                participationViewModels.Add(new ParticipationViewModel
                {
                    Id = part.Id,
                    User = part.User.Degree + " " + part.User.FirstName + " " + part.User.LastName,
                    Season = part.Season.Name + " " + part.Season.EditionNumber,
                    ConfPart = part.ConferenceParticipation.GetValueOrDefault(),
                    PaperPub = part.PaperPublication.GetValueOrDefault()
                });
            }

            return participationViewModels;
        }

        private async Task<List<ParticipationViewModel>> GetParticipationViewModelsWithDictionarySearch()
        {
            List<User> users = await _context.Users.ToListAsync();
            List<Season> seasons = await _context.Seasons.ToListAsync();
            List<Participation> participations = await _context.Participations.ToListAsync();
            List<ParticipationViewModel> participationViewModels = new List<ParticipationViewModel>();

            Dictionary<Int64, User> usersGrouped = users.GroupBy(p => p.Id).ToDictionary(p => p.Key, p => p.First());
            Dictionary<Int64, Season> seasonsGrouped = seasons.GroupBy(p => p.Id).ToDictionary(p => p.Key, p => p.First());

            foreach (Participation part in participations)
            {
                part.User = usersGrouped[part.UserId];
                part.Season = seasonsGrouped[part.SeasonId];

                participationViewModels.Add(new ParticipationViewModel
                {
                    Id = part.Id,
                    User = part.User.Degree + " " + part.User.FirstName + " " + part.User.LastName,
                    Season = part.Season.Name + " " + part.Season.EditionNumber,
                    ConfPart = part.ConferenceParticipation.GetValueOrDefault(),
                    PaperPub = part.PaperPublication.GetValueOrDefault()
                });
            }

            return participationViewModels;
        }

        public async Task<IActionResult> ParticipationsIndexClassic()
        {
            long elapsedPrepare = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Participation> participations = await _context.Participations.Include(p => p.Season).Include(p => p.User).ToListAsync();
            List<ParticipationViewModel> participationViewModels = new List<ParticipationViewModel>();

            foreach(Participation part in participations)
            {
                participationViewModels.Add(new ParticipationViewModel
                {
                    Id = part.Id,
                    User = part.User.Degree + " " + part.User.FirstName + " " + part.User.LastName,
                    Season = part.Season.Name + " " + part.Season.EditionNumber,
                    ConfPart = part.ConferenceParticipation.GetValueOrDefault(),
                    PaperPub = part.PaperPublication.GetValueOrDefault()
                });
            }

            stopwatch.Stop();
            elapsedPrepare = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            ViewData["Info"] = "Elapsed at preparing: " + elapsedPrepare + "<br>";
            stopwatch.Start();
            ViewData["Stopwatch"] = stopwatch;

            return View(participationViewModels);
        }

        public async Task<IActionResult> ParticipationsIndexWithSingleRetrieve()
        {
            long elapsedPrepare = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Participation> participations = await _context.Participations.ToListAsync();
            List<ParticipationViewModel> participationViewModels = new List<ParticipationViewModel>();

            foreach (Participation part in participations)
            {
                part.User = _context.Users.Find(part.UserId);
                part.Season = _context.Seasons.Find(part.SeasonId);
                participationViewModels.Add(new ParticipationViewModel
                {
                    Id = part.Id,
                    User = part.User.Degree + " " + part.User.FirstName + " " + part.User.LastName,
                    Season = part.Season.Name + " " + part.Season.EditionNumber,
                    ConfPart = part.ConferenceParticipation.GetValueOrDefault(),
                    PaperPub = part.PaperPublication.GetValueOrDefault()
                });
            }

            stopwatch.Stop();
            elapsedPrepare = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            ViewData["Info"] = "Elapsed at preparing: " + elapsedPrepare + "<br>";
            stopwatch.Start();
            ViewData["Stopwatch"] = stopwatch;

            return View(participationViewModels);
        }

        public async Task<IActionResult> ParticipationsIndexWithSearch()
        {
            long elapsedPrepare = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<User> users = await _context.Users.ToListAsync();
            List<Season> seasons = await _context.Seasons.ToListAsync();
            List<Participation> participations = await _context.Participations.ToListAsync();
            List<ParticipationViewModel> participationViewModels = new List<ParticipationViewModel>();

            foreach (Participation part in participations)
            {
                part.User = users.FirstOrDefault(p => p.Id == part.UserId);
                part.Season = seasons.FirstOrDefault(p => p.Id == part.SeasonId);
                participationViewModels.Add(new ParticipationViewModel
                {
                    Id = part.Id,
                    User = part.User.Degree + " " + part.User.FirstName + " " + part.User.LastName,
                    Season = part.Season.Name + " " + part.Season.EditionNumber,
                    ConfPart = part.ConferenceParticipation.GetValueOrDefault(),
                    PaperPub = part.PaperPublication.GetValueOrDefault()
                });
            }

            stopwatch.Stop();
            elapsedPrepare = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            ViewData["Info"] = "Elapsed at preparing: " + elapsedPrepare + "<br>";
            stopwatch.Start();
            ViewData["Stopwatch"] = stopwatch;

            return View(participationViewModels);
        }

        public async Task<IActionResult> ParticipationsIndexWithDictionarySearch()
        {
            long elapsedPrepare = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<User> users = await _context.Users.ToListAsync();
            List<Season> seasons = await _context.Seasons.ToListAsync();
            List<Participation> participations = await _context.Participations.ToListAsync();
            List<ParticipationViewModel> participationViewModels = new List<ParticipationViewModel>();

            Dictionary<Int64, User> usersGrouped = users.GroupBy(p => p.Id).ToDictionary(p => p.Key, p => p.First());
            Dictionary<Int64, Season> seasonsGrouped = seasons.GroupBy(p => p.Id).ToDictionary(p => p.Key, p => p.First());

            foreach (Participation part in participations)
            {
                part.User = usersGrouped[part.UserId];
                part.Season = seasonsGrouped[part.SeasonId];

                participationViewModels.Add(new ParticipationViewModel
                {
                    Id = part.Id,
                    User = part.User.Degree + " " + part.User.FirstName + " " + part.User.LastName,
                    Season = part.Season.Name + " " + part.Season.EditionNumber,
                    ConfPart = part.ConferenceParticipation.GetValueOrDefault(),
                    PaperPub = part.PaperPublication.GetValueOrDefault()
                });
            }

            stopwatch.Stop();
            elapsedPrepare = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            ViewData["Info"] = "Elapsed at preparing: " + elapsedPrepare + "<br>";
            stopwatch.Start();
            ViewData["Stopwatch"] = stopwatch;

            return View(participationViewModels);
        }
    }
}
