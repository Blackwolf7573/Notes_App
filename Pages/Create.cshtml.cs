using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Notes_App.Data;
using Notes_App.Strucs;
using Notes_App.Functions;
using Notes_App.Global;

namespace Notes_App.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Note Note { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() //Insert Data in Database
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Insert data in Database
            string query = "INSERT INTO Notes";
            query += " (Id, Titel, Erstellungsdatum, Abschlussdatum, Text)";
            query += String.Format(" VALUES (NULL, '{0}', '{1}', '{2}', '{3}');"
                , Note.Titel, Note.Erstellungsdatum.ToString(), Note.Abschlussdatum.ToString(), Note.Text);
            Variables.f_Database.Database_insert(query);

            return RedirectToPage("./Index");
        }
        
    }
}
