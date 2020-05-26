using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PerformanceTesterCSS.Entities;
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
            IActionResult actionResult002 = await ParticipationsIndexWithSearch();
            stopwatch.Stop();
            stringBuilder.Append("Elapsed total at with search: " + stopwatch.ElapsedMilliseconds + "\n");
            stopwatch.Reset();

            stopwatch.Start();
            IActionResult actionResult003 = await ParticipationsIndexWithDictionarySearch();
            stopwatch.Stop();
            stringBuilder.Append("Elapsed total at with search: " + stopwatch.ElapsedMilliseconds + "\n");
            stopwatch.Reset();

            stringBuilder.Append("Finished");

            return stringBuilder.ToString();
        }

        public async Task<IActionResult> ParticipationsIndexClassic()
        {
            long elapsedPrepare = 0;
            long elapsedView = 0;
            long elapsedTotal = 0;
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

            stopwatch.Start();
            ViewResult view = View(participationViewModels);
            stopwatch.Stop();
            elapsedView = stopwatch.ElapsedMilliseconds;

            elapsedTotal = elapsedPrepare + elapsedView;

            ViewData["Info"] = "Time measures:<br>Elapsed at preparing: " + elapsedPrepare + "<br>Elapsed at making view: " + elapsedView + "<br>Elapsed totally: " + elapsedTotal + "<br>";

            return View(participationViewModels);
        }

        public async Task<IActionResult> ParticipationsIndexWithSearch()
        {
            long elapsedPrepare = 0;
            long elapsedView = 0;
            long elapsedTotal = 0;
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

            stopwatch.Start();
            ViewResult view = View(participationViewModels);
            stopwatch.Stop();
            elapsedView = stopwatch.ElapsedMilliseconds;

            elapsedTotal = elapsedPrepare + elapsedView;

            ViewData["Info"] = "Time measures:<br>Elapsed at preparing: " + elapsedPrepare + "<br>Elapsed at making view: " + elapsedView + "<br>Elapsed totally: " + elapsedTotal + "<br>";

            return View(participationViewModels);
        }

        public async Task<IActionResult> ParticipationsIndexWithDictionarySearch()
        {
            long elapsedPrepare = 0;
            long elapsedView = 0;
            long elapsedTotal = 0;
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

            stopwatch.Start();
            ViewResult view = View(participationViewModels);
            stopwatch.Stop();
            elapsedView = stopwatch.ElapsedMilliseconds;

            elapsedTotal = elapsedPrepare + elapsedView;

            ViewData["Info"] = "Time measures:<br>Elapsed at preparing: " + elapsedPrepare + "<br>Elapsed at making view: " + elapsedView + "<br>Elapsed totally: " + elapsedTotal + "<br>";

            return View(participationViewModels);
        }
    }
}
