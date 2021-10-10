using EntityFrameworkDataAccessLibrary.DataAccess;
using EntityFrameworkDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EntityFrameworkWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _db;

        public IndexModel(ILogger<IndexModel> logger, PeopleContext db)
        {
            _logger = logger;
            this._db = db;
        }

        public void OnGet()
        {
            LoadSampleDate();

            var people = _db.People
                .Include( p => p.Addresses)
                .Include (p => p.EmailAddresses)
                .ToList();


            //Bad Practice
            var customer2 =
             (from cust in _db.People
              select cust).ToList();

            var customer =
             (from cust in _db.People
              select new
              {
                  cust.Id,
                  cust.FirstName,
                  cust.LastName,
                  cust.Age
              }).ToList();
        }

        public void LoadSampleDate()
        {
            if(_db.People.Count() == 0)
            {
                string file = System.IO.File.ReadAllText("EntityFrameworkTest.json");
                var people = JsonSerializer.Deserialize<List<Person>>(file);
                _db.AddRange(people);
                _db.SaveChanges();
            }
        }
    }
}
