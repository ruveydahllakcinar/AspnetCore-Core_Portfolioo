using DataAccessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;

namespace DataAccessLayer.EntityFramework
{
    public class EfCertficateDal:GenericRepository<Certficate>,ICertficateDal
    {
        
    }
}