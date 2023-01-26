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
    public class CertficateManager : ICertficateService
    {
        ICertficateDal _certficateDal;

        public CertficateManager(ICertficateDal certficateDal)
        {
            _certficateDal = certficateDal;
        }
        public void TAdd(Certficate t)
        {
            _certficateDal.Insert(t);
        }

        public void TDelete(Certficate t)
        {
            _certficateDal.Delete(t);
        }

        public void TUpdate(Certficate t)
        {
            _certficateDal.Update(t);
        }

        public List<Certficate> TGetList()
        {
            return _certficateDal.GetList();

        }

        public Certficate TGetByID(int id)
        {
            return _certficateDal.GetById(id);
        }

        public List<Certficate> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }
    }
}
