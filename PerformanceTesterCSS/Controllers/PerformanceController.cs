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
using PerformanceTesterCSS.Helpers;

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

        public async Task<String> PerformFullTest()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Full test:\n");
            Stopwatch stopwatch = new Stopwatch();

            /*stopwatch.Start();
            IActionResult actionResult001 = await ParticipationsIndexClassic();
            stopwatch.Stop();
            stringBuilder.Append("Elapsed total at classic: " + stopwatch.ElapsedMilliseconds + "\n");
            stopwatch.Reset();*/

            stopwatch.Start();
            List<ParticipationViewModel> participationViewModels002 = await GetParticipationViewModelsWithSearch();
            String html002 = await this.RenderViewAsync<List<ParticipationViewModel>>("ParticipationsIndexWithSearch", participationViewModels002);
            stringBuilder.Append("Elapsed total at with search: " + stopwatch.ElapsedMilliseconds + " html size " + html002.Length + "\n");
            stopwatch.Reset();

            stopwatch.Start();
            List<ParticipationViewModel> participationViewModels003 = await GetParticipationViewModelsWithDictionarySearch();
            String html003 = await this.RenderViewAsync<List<ParticipationViewModel>>("ParticipationsIndexWithDictionarySearch", participationViewModels003);
            stopwatch.Stop();
            stringBuilder.Append("Elapsed total at with search: " + stopwatch.ElapsedMilliseconds + " html size " + html003.Length + "\n");
            stopwatch.Reset();

            stringBuilder.Append("Finished");

            return stringBuilder.ToString();
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
