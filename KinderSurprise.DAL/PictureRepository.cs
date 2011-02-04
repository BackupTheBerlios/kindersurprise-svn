using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using NHibernate;
using NHibernate.LambdaExtensions;

namespace KinderSurprise.DAL
{
	public class PictureRepository : IPictureRepository
	{
		public List<Picture> GetById(int id, EType type)
		{
			using (ISession session = SessionBase.OpenSession())
			{
				ICriteria crit = session.CreateCriteria(typeof(Picture));
				if(type.Equals(EType.Figur))
				{
					crit.Add<Picture>(exp => exp.Fk_Figur_Id.Id == id);
				}
				if(type.Equals(EType.Serie))
				{
					crit.Add<Picture>(exp => exp.Fk_Serie_Id.Id == id);
				}
				if(type.Equals(EType.Instructions))
				{
					crit.Add<Picture>(exp => exp.Fk_Instructions_Id.Id== id);
				}
				
				return crit.List().Cast<Picture>().ToList();
			}
		}
	}
}
