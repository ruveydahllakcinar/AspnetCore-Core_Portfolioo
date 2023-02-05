using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer.Concrete
{
    public class Speaker
    {
        [Key]
        public int SpeakerId { get; set; }
        public string Title { get; set; }        
        public string Subject { get; set; }        
        public DateTime Date { get; set; }
        public string SpeakerImage { get; set; }
    }
}