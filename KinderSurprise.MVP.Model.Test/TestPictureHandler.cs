using System;
using System.Collections.Generic;
using KinderSurprise.DTO;
using NUnit.Framework;

namespace KinderSurprise.MVP.Model.Test
{
	[TestFixture()]
	public class TestPictureHandler
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void Test_LoadPictures_NotACorrectPath()
		{
			PictureService pictureService = new PictureService(2, EType.Instructions);
			List<PictureDto> pictureDtos = pictureService.GetPictures();
			
			Assert.AreEqual(1, pictureService.GetSize());
				
			PictureHandler pictureHandler = new PictureHandler(pictureDtos);
			pictureHandler.LoadPictures();
		}
		
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void Test_LoadPictures_NoPictureChosen()
		{
			PictureService pictureService = new PictureService(10, EType.Instructions);
			List<PictureDto> pictureDtos = pictureService.GetPictures();
			
			Assert.AreEqual(0, pictureService.GetSize());
				
			PictureHandler pictureHandler = new PictureHandler(pictureDtos);
			pictureHandler.LoadPictures();
		}
		
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void Test_SavePicturesToGlobalFolder()
		{
			PictureService pictureService = new PictureService(2, EType.Instructions);
			List<PictureDto> pictureDtos = pictureService.GetPictures();
			
			Assert.AreEqual(1, pictureService.GetSize());
				
			PictureHandler pictureHandler = new PictureHandler(pictureDtos);
			pictureHandler.SavePictures();
		}
	}
}
