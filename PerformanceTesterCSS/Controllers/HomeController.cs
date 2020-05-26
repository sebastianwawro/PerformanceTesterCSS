using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PerformanceTesterCSS.Entities;
using PerformanceTesterCSS.Helpers;
using PerformanceTesterCSS.Models;

namespace PerformanceTesterCSS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbCtx _context;

        public HomeController(ILogger<HomeController> logger, DbCtx dbCtx)
        {
            _logger = logger;
            _context = dbCtx;
        }

        public IActionResult Index()
        {
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

        public String PasswordCheck()
        {
            List<User> users = _context.Users.ToList();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Checking users:\n");
            
            foreach(User user in users)
            {
                Boolean check = CryptHelper.CheckPassword("P@ss1234", user.Password);
                stringBuilder.Append("User " + user.Username + " password: " + (check ? "same" : "not same") + "\n");
            }

            stringBuilder.Append("Finished");

            return stringBuilder.ToString();

        }

        public String DatabaseReadabilityCheck()
        {
            List<User> users = _context.Users.ToList();
            List<ConfigurationRecord> configurationRecords = _context.ConfigurationRecords.ToList();
            List<DocumentFile> documentFiles = _context.DocumentFiles.ToList();
            List<FailedJob> failedJobs = _context.FailedJobs.ToList();
            List<ImageInfo> imageInfos = _context.ImageInfos.ToList();
            List<InAppMessage> inAppMessages = _context.InAppMessages.ToList();
            List<LogRecord> logRecords = _context.LogRecords.ToList();
            List<Migration> migrations = _context.Migrations.ToList();
            List<NewsMessage> newsMessages = _context.NewsMessages.ToList();
            List<Paper> papers = _context.Papers.ToList();
            List<PaperVersion> paperVersions = _context.PaperVersions.ToList();
            List<Participation> participations = _context.Participations.ToList();
            List<PasswordReset> passwordResets = _context.PasswordResets.ToList();
            List<Presence> presences = _context.Presences.ToList();
            List<ReferralRecord> referralRecords = _context.ReferralRecords.ToList();
            List<Review> reviews = _context.Reviews.ToList();
            List<Season> seasons = _context.Seasons.ToList();
            List<ShoutboxMessage> shoutboxMessages = _context.ShoutboxMessages.ToList();
            List<UserAdminPrivileges> userAdminPrivileges = _context.UserAdminPrivileges.ToList();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Records count:\n");
            stringBuilder.Append("Users: " + users.Count + "\n");
            stringBuilder.Append("ConfigurationRecords: " + configurationRecords.Count + "\n");
            stringBuilder.Append("DocumentFiles: " + documentFiles.Count + "\n");
            stringBuilder.Append("FailedJobs: " + failedJobs.Count + "\n");
            stringBuilder.Append("ImageInfos: " + imageInfos.Count + "\n");
            stringBuilder.Append("InAppMessages: " + inAppMessages.Count + "\n");
            stringBuilder.Append("LogRecords: " + logRecords.Count + "\n");
            stringBuilder.Append("Migrations: " + migrations.Count + "\n");
            stringBuilder.Append("NewsMessages: " + newsMessages.Count + "\n");
            stringBuilder.Append("Papers: " + papers.Count + "\n");
            stringBuilder.Append("PaperVersions: " + paperVersions.Count + "\n");
            stringBuilder.Append("Participations: " + participations.Count + "\n");
            stringBuilder.Append("PasswordResets: " + passwordResets.Count + "\n");
            stringBuilder.Append("Presences: " + presences.Count + "\n");
            stringBuilder.Append("ReferralRecords: " + referralRecords.Count + "\n");
            stringBuilder.Append("Reviews: " + reviews.Count + "\n");
            stringBuilder.Append("Seasons: " + seasons.Count + "\n");
            stringBuilder.Append("ShoutboxMessages: " + shoutboxMessages.Count + "\n");
            stringBuilder.Append("UserAdminPrivileges: " + userAdminPrivileges.Count + "\n");
            stringBuilder.Append("Finished");

            return stringBuilder.ToString();

        }
    }
}
