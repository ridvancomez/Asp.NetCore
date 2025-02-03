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
    public class ToDoListManager : IToDoListService
    {
        IToDoListDal toDoList;
        public ToDoListManager(IToDoListDal toDoList)
        {
            this.toDoList = toDoList;
        }

        public void TAdd(ToDoList entity)
        {
            toDoList.Insert(entity);
        }

        public void TDelete(ToDoList entity)
        {
            toDoList.Delete(entity);
        }

        public ToDoList TGetById(int id)
        {
            return toDoList.GetById(id);
        }

        public List<ToDoList> TGetList()
        {
            return toDoList.GetList();
        }

        public List<ToDoList> TGetListByFilter(Expression<Func<ToDoList, bool>> filter)
        {
            return toDoList.GetByFilter(filter);
        }

        public void TUpdate(ToDoList entity)
        {
            toDoList.Update(entity);
        }
    }
}
