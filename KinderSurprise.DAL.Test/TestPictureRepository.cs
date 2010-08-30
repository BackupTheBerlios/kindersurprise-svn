using System;
using System.Collections.Generic;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
using NUnit.Framework;

namespace KinderSurprise.DAL.Test
{
	[TestFixture]
	public class TestPictureRepository
	{
		[Test]
		public void Test_GetById_IdDoesNotExist_IsFigur()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<PictureDto> pictureDtos = pictureRepository.GetById(0, EType.Figur);
			Assert.AreEqual(0, pictureDtos.Count);
		}

		[Test]
		public void Test_GetById_IdDoesNotExist_IsSerie()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<PictureDto> pictureDtos = pictureRepository.GetById(0, EType.Serie);
			Assert.AreEqual(0, pictureDtos.Count);
		}
		
		[Test]
		public void Test_GetById_IdDoesNotExist_IsInstructions()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<PictureDto> pictureDtos = pictureRepository.GetById(6, EType.Instructions);
			Assert.AreEqual(0, pictureDtos.Count);
		}
		
		[Test]
		public void Test_GetById_IdExistAndIsSerie()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<PictureDto> pictureDtos = pictureRepository.GetById(5, EType.Serie);
			Assert.AreEqual(1, pictureDtos.Count);
			Assert.AreEqual("1.jpg", pictureDtos[0].Path);
			Assert.IsNull(pictureDtos[0].Instructions);
			Assert.IsNull(pictureDtos[0].Figur);
			Assert.IsNotNull(pictureDtos[0].Serie);
		}
		
		[Test]
		public void Test_GetById_IdExistAndIsFigur()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<PictureDto> pictureDtos = pictureRepository.GetById(3, EType.Figur);
			Assert.AreEqual(1, pictureDtos.Count);
			Assert.AreEqual("2.jpg", pictureDtos[0].Path);
			Assert.IsNull(pictureDtos[0].Instructions);
			Assert.IsNotNull(pictureDtos[0].Figur);
			Assert.IsNull(pictureDtos[0].Serie);
			
		}
		
		[Test]
		public void Test_GetById_ExistIsFigurAndHasTwoEntries()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<PictureDto> pictureDtos = pictureRepository.GetById(5, EType.Figur);
			Assert.AreEqual(2, pictureDtos.Count);
			
			Assert.AreEqual("3.jpg", pictureDtos[0].Path);
			Assert.IsNull(pictureDtos[0].Instructions);
			Assert.IsNotNull(pictureDtos[0].Figur);
			Assert.IsNull(pictureDtos[0].Serie);
			
			Assert.AreEqual("4.jpg", pictureDtos[1].Path);
			Assert.IsNull(pictureDtos[1].Instructions);
			Assert.IsNotNull(pictureDtos[1].Figur);
			Assert.IsNull(pictureDtos[1].Serie);
		}
		public void Test_GetById_ExistIsInstructionsAndHasOneEntry()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<PictureDto> pictureDtos = pictureRepository.GetById(2, EType.Instructions);
			Assert.AreEqual(1, pictureDtos.Count);
			
			Assert.AreEqual(6, pictureDtos[0].Id);
			Assert.AreEqual("", pictureDtos[0].Path);
			Assert.IsNotNull(pictureDtos[0].Instructions);
			Assert.IsNull(pictureDtos[0].Figur);
			Assert.IsNull(pictureDtos[0].Serie);
		}
	}
}
