using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Model;
using NHibernate;

namespace KinderSurprise.DAL
{
	public class PictureRepository : IPictureRepository
	{
		public List<Picture> GetById(int id, EType type)
		{
			using (ISession session = RepositoryBase.OpenSession())
			{
				ICriteria crit = session.CreateCriteria(typeof(Picture));
				if(type.Equals(EType.Figur))
				{
					crit.Add(NHibernate.Criterion.Expression.Eq("Fk_Figur_Id.FigurId", id));
				}
				if(type.Equals(EType.Serie))
				{
					crit.Add(NHibernate.Criterion.Expression.Eq("Fk_Serie_Id.SerieId", id));
				}
				if(type.Equals(EType.Instructions))
				{
					crit.Add(NHibernate.Criterion.Expression.Eq("Fk_Instructions_Id.Id", id));
				}
				
				return crit.List().Cast<Picture>().ToList();
			}
		}
	}
}
