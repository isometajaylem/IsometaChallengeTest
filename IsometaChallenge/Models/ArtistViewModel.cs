using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IsometaChallenge.Models
{
    public class ArtistViewModel
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Instrument { get; set; }
        [Display(Name = "Record Label")]
        public string RecordLabel { get; set; }
    }
}