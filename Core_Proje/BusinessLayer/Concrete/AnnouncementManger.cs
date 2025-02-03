using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManger : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;
        public AnnouncementManger(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }
        public void TAdd(Announcement entity)
        {
            _announcementDal.Insert(entity);
        }

        public void TDelete(Announcement entity)
        {
            _announcementDal.Delete(entity);
        }

        public Announcement TGetById(int id)
        {
            return _announcementDal.GetById(id);
        }

        public List<Announcement> TGetList()
        {
            return _announcementDal.GetList();
        }

        public List<Announcement> TGetListByFilter(Expression<Func<Announcement, bool>> filter)
        {
            return _announcementDal.GetByFilter(filter);
        }

        public void TUpdate(Announcement entity)
        {
            _announcementDal.Update(entity);
        }
    }
}
