using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void CommentAdd(Comment comment);
       // void CategoryDelete(Comment cooment);
       // void CategoryUpdate(Comment cooment);
        List<Comment> GetList(int id);
        List<Comment> GetListWithBlog();
        //Comment GetById(int id);
    }
}
