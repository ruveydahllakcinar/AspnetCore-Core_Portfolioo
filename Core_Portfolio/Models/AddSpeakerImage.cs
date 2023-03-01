using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio.Models
{
    public class AddSpeakerImage
    {
        public int SpeakerId { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string SpeakerUrl { get; set; }
        public DateTime Date { get; set; }
        public IFormFile SpeakerImage { get; set; }
    }
}
