using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IBlogService :IGenericService<Blog>
    {
        List<Blog> GetBlogByID(int id);
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogListByWriter(int id);
        List<Blog> GetLast3Blog();

    }
}
