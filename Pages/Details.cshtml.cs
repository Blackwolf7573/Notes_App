using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Notes_App.Data;
using Notes_App.Strucs;
using Notes_App.Global;
using System.Data.SQLite;
using System.Globalization;

namespace Notes_App.Pages
{
    public class DetailsModel : PageModel
    {
        public Note Note { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            //Get data from Database
            SQLiteDataReader sqlite_datareader = Variables.f_Database.Database_read(String.Format("SELECT * FROM Notes where Id = '{0}';", id));
            sqlite_datareader.Read();

            Note tmpNote = new Note(); ;
            tmpNote.ID = sqlite_datareader.GetInt32(0);
            tmpNote.Titel = sqlite_datareader.GetString(1);
            var cultureInfo = new CultureInfo("de-DE");
            DateTime dateTime = DateTime.Parse(sqlite_datareader.GetString(2), cultureInfo, DateTimeStyles.NoCurrentDateDefault);
            tmpNote.Erstellungsdatum = dateTime;
            dateTime = DateTime.Parse(sqlite_datareader.GetString(3), cultureInfo, DateTimeStyles.NoCurrentDateDefault);
            tmpNote.Abschlussdatum = dateTime;
            tmpNote.Text = sqlite_datareader.GetString(4);

            Note = tmpNote;

            sqlite_datareader.Close();

            return Page();
        }
    }
}
