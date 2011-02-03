using System;
using System.Collections.Generic;
using KinderSurprise.Model;
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
			List<Picture> pictures = pictureRepository.GetById(0, EType.Figur);
			Assert.AreEqual(0, pictures.Count);
		}

		[Test]
		public void Test_GetById_IdDoesNotExist_IsSerie()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<Picture> pictures = pictureRepository.GetById(0, EType.Serie);
			Assert.AreEqual(0, pictures.Count);
		}
		
		[Test]
		public void Test_GetById_IdDoesNotExist_IsInstructions()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<Picture> pictures = pictureRepository.GetById(6, EType.Instructions);
			Assert.AreEqual(0, pictures.Count);
		}
		
		[Test]
		public void Test_GetById_IdExistAndIsSerie()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<Picture> pictures = pictureRepository.GetById(5, EType.Serie);
			Assert.AreEqual(1, pictures.Count);
			Assert.AreEqual("1.jpg", pictures[0].Path);
			Assert.IsNull(pictures[0].Fk_Instructions_Id);
			Assert.IsNull(pictures[0].Fk_Figur_Id);
			Assert.IsNotNull(pictures[0].Fk_Serie_Id);
		}
		
		[Test]
		public void Test_GetById_IdExistAndIsFigur()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<Picture> pictures = pictureRepository.GetById(3, EType.Figur);
			Assert.AreEqual(1, pictures.Count);
			Assert.AreEqual("2.jpg", pictures[0].Path);
			Assert.IsNull(pictures[0].Fk_Instructions_Id);
			Assert.IsNotNull(pictures[0].Fk_Figur_Id);
			Assert.IsNull(pictures[0].Fk_Serie_Id);
			
		}
		
		[Test]
		public void Test_GetById_ExistIsFigurAndHasTwoEntries()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<Picture> pictures = pictureRepository.GetById(5, EType.Figur);
			Assert.AreEqual(2, pictures.Count);
			
			Assert.AreEqual("3.jpg", pictures[0].Path);
			Assert.IsNull(pictures[0].Fk_Instructions_Id);
			Assert.IsNotNull(pictures[0].Fk_Figur_Id);
			Assert.IsNull(pictures[0].Fk_Serie_Id);
			
			Assert.AreEqual("4.jpg", pictures[1].Path);
			Assert.IsNull(pictures[1].Fk_Instructions_Id);
			Assert.IsNotNull(pictures[1].Fk_Figur_Id);
			Assert.IsNull(pictures[1].Fk_Serie_Id);
		}
		public void Test_GetById_ExistIsInstructionsAndHasOneEntry()
		{
			IPictureRepository pictureRepository = new PictureRepository();
			List<Picture> pictures = pictureRepository.GetById(2, EType.Instructions);
			Assert.AreEqual(1, pictures.Count);
			
			Assert.AreEqual(6, pictures[0].Id);
			Assert.AreEqual("", pictures[0].Path);
			Assert.IsNotNull(pictures[0].Fk_Instructions_Id);
			Assert.IsNull(pictures[0].Fk_Figur_Id);
			Assert.IsNull(pictures[0].Fk_Serie_Id);
		}
	}
}
