using DataAccessLayer.Abstract;
using DataAccessLayer.Repesitory;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public List<Announcement> GetListByFilter(Expression<Func<Announcement, bool>> filter)
        {
            return GetByFilter(filter);
        }
    }
}
