using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Date { get; set; }        
    }
}