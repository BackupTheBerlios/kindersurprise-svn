using System.Collections.Generic;
using System;
using System.Linq;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using NHibernate;


namespace KinderSurprise.DAL
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
    }
}
