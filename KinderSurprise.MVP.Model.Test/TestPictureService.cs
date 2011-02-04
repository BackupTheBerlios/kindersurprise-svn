using KinderSurprise.Model;
using NUnit.Framework;

namespace KinderSurprise.MVP.Model.Test
{
	[TestFixture()]
	public class TestPictureService
	{
		[Test()]
		public void Test_GetSizeOfNoObjectFound()
		{
			SerieService serieService = new SerieService();
			var serieDto = serieService.GetById(4);
			PictureService pictureService = new PictureService(serieDto.Id, EType.Serie);
			Assert.AreEqual(0, pictureService.GetSize());
		}
		
		[Test]
		public void Test_GetSizeOfValidPictures()
		{
			SerieService serieService = new SerieService();
			var serieDto = serieService.GetById(5);
			PictureService pictureService = new PictureService(serieDto.Id, EType.Serie);
			Assert.AreEqual(1, pictureService.GetSize());
		}
		
		[Test]
		public void Test_GetPictures_NoMatches()
		{
			SerieService serieService = new SerieService();
			var serieDto = serieService.GetById(4);
			PictureService pictureService = new PictureService(serieDto.Id, EType.Serie);
			Assert.AreEqual(0, pictureService.GetPictures().Count);
		}
		
		[Test]
		public void Test_GetPictures_FoundSome()
		{
			FigurService figurService = new FigurService();
			var figurDto = figurService.GetById(5);
			PictureService pictureService = new PictureService(figurDto.Id, EType.Figur);
			Assert.AreEqual(2, pictureService.GetPictures().Count);
			
		}
	}
}
