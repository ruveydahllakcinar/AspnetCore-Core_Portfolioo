using DataAccessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFeatureService : IGenericService<Feature>
    {
        void Delete(Feature t);
        Feature GetById(int id);
        List<Feature> GetList();
        void Insert(Feature t);
        void Update(Feature t);
    }
}