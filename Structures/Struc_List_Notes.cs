using System;
using System.ComponentModel.DataAnnotations;

namespace Notes_App.Strucs
{
    public class Note
    {
        public int ID { get; set; }
        public string Titel { get; set; }

        [DataType(DataType.Date)]
        public DateTime Erstellungsdatum { get; set; }

        [DataType(DataType.Date)]
        public DateTime Abschlussdatum { get; set; }
        public string Text { get; set; }
    }
}