﻿using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDAL : IRepositoryBase<Category>
    {
        List<Category> GetNavbarCategories();
        List<Category> GetFeaturedCategories();
    }
}
