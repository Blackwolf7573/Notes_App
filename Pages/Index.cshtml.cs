using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Notes_App.Data;
using Notes_App.Strucs;
using System.Data.SQLite;
using System.Globalization;
using Notes_App.Functions;
using Notes_App.Global;

namespace Notes_App.Pages
{
    public class IndexModel : PageModel
    {
        public IList<Note> Notelist = new List<Note>();        

        public async Task OnGet()
        {
            //Database
            Variables.f_Database = new Database();

            Variables.f_Database.create_Database_connection();

            //Get data from Database
            SQLiteDataReader sqlite_datareader = Variables.f_Database.Database_read("SELECT * FROM Notes order by Titel");
            while (sqlite_datareader.Read())
            {
                Note tmpNote = new Note(); ;
                tmpNote.ID = sqlite_datareader.GetInt32(0);
                tmpNote.Titel = sqlite_datareader.GetString(1);
                var cultureInfo = new CultureInfo("de-DE");
                DateTime dateTime = DateTime.Parse(sqlite_datareader.GetString(2), cultureInfo, DateTimeStyles.NoCurrentDateDefault);
                tmpNote.Erstellungsdatum = dateTime;
                dateTime = DateTime.Parse(sqlite_datareader.GetString(3), cultureInfo, DateTimeStyles.NoCurrentDateDefault);
                tmpNote.Abschlussdatum = dateTime;
                tmpNote.Text = sqlite_datareader.GetString(4);

                Notelist.Add(tmpNote);
            }
            sqlite_datareader.Close();
        }
    }
}

