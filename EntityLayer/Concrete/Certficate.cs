using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer.Concrete
{
    public class Certficate
    {
        [Key]
        public int CertficateId { get; set; }
        public string CompanyName { get; set; }        
        public string Title { get; set; }
        public string Links { get; set; }
    }
}