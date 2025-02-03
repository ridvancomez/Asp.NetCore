using EntityLayer.Concrate;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repesitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfSkillDal : GenericRepository<Skill>, ISkillDal
    {
    }
}
