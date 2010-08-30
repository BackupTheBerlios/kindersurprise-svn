using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
using NHibernate;

namespace KinderSurprise.DAL
{
	public class PictureRepository : IPictureRepository
	{
		public List<PictureDto> GetById(int id, EType type)
		{
			using (ISession session = RepositoryBase.OpenSession())
			{
				List<PictureDto> pictureDtos = new List<PictureDto>();
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
				
				var pictureList = crit.List();
				
				foreach (Picture p in pictureList)
				{
					pictureDtos.Add( new PictureDto(p.Id, p.Path,p.Fk_Figur_Id,  p.Fk_Serie_Id, p.Fk_Instructions_Id));
				}
				
				return pictureDtos;
			}
		}
	}
}
