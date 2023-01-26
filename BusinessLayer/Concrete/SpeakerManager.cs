using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SpeakerManager : ISpeakerService
    {
        ISpeakerDal _speakerDal;

        public SpeakerManager(ISpeakerDal speakerDal)
        {
            _speakerDal = speakerDal;
        }

        public void TAdd(Speaker t)
        {
            _speakerDal.Insert(t);
        }

        public void TDelete(Speaker t)
        {
            _speakerDal.Delete(t);
        }

        public Speaker TGetByID(int id)
        {
           return _speakerDal.GetById(id);
        }

        public List<Speaker> TGetList()
        {
           return _speakerDal.GetList();
        }

        public List<Speaker> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Speaker t)
        {
            _speakerDal.Update(t);
        }
    }
}
