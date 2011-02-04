using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;
using NUnit.Framework;
using StructureMap;

namespace KinderSurprise.MVP.Model.Test
{
	[TestFixture()]
	public class TestPictureService
	{
		[Test()]
		public void Test_GetSizeOfNoObjectFound()
		{
			ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
			var serie = serieService.GetById(4);
			PictureService pictureService = new PictureService(serie.Id, EType.Serie);
			Assert.AreEqual(0, pictureService.GetSize());
		}
		
		[Test]
		public void Test_GetSizeOfValidPictures()
		{
			ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
			var serie = serieService.GetById(5);
			PictureService pictureService = new PictureService(serie.Id, EType.Serie);
			Assert.AreEqual(1, pictureService.GetSize());
		}
		
		[Test]
		public void Test_GetPictures_NoMatches()
		{
			ISerieService serieService = ObjectFactory.GetInstance<ISerieService>();
			var serie = serieService.GetById(4);
			PictureService pictureService = new PictureService(serie.Id, EType.Serie);
			Assert.AreEqual(0, pictureService.GetPictures().Count);
		}
		
		[Test]
		public void Test_GetPictures_FoundSome()
		{
			IFigurService figurService = ObjectFactory.GetInstance<IFigurService>();
			var figur = figurService.GetById(5);
			PictureService pictureService = new PictureService(figur.Id, EType.Figur);
			Assert.AreEqual(2, pictureService.GetPictures().Count);
			
		}
	}
}
