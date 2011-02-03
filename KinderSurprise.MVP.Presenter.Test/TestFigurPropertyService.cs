using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.MVP.Presenter.Interfaces;
using NUnit.Framework;

namespace KinderSurprise.MVP.Presenter.Test
{
    [TestFixture]
    public class TestFigurPropertyService
    {
        #region MockObjectWithInitializationAndDispose

        private IFigurPropertyPresenter m_MockFigurProperty;

        [SetUp]
        public void Setup()
        {
            Moq.Mock<IFigurPropertyPresenter> mockFigurPropertyPresenter = new Moq.Mock<IFigurPropertyPresenter>();
			mockFigurPropertyPresenter.SetupAllProperties();
			m_MockFigurProperty = mockFigurPropertyPresenter.Object;
			m_MockFigurProperty.NewFigurButton = new Button();
            m_MockFigurProperty.SaveButton = new Button();
            m_MockFigurProperty.DeleteButton = new Button();
            m_MockFigurProperty.CancelButton = new Button();
            m_MockFigurProperty.ErrorMessage = new Label();
            m_MockFigurProperty.FigurName = new TextBox();
            m_MockFigurProperty.FigurDescription = new TextBox();
            m_MockFigurProperty.FigurPrice = new TextBox();
            m_MockFigurProperty.ChooseSerie = new DropDownList();
			m_MockFigurProperty.Figur = null;
        }

        [TearDown]
        public void Teardown()
        {
            m_MockFigurProperty = null;
        }

        #endregion

        [Test]
        public void Test_SetToEditMode()
        {
            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(m_MockFigurProperty); 

            figurPropertyPresenter.SetToViewMode();

            Assert.IsTrue(m_MockFigurProperty.NewFigurButton.Visible);
            Assert.IsTrue(m_MockFigurProperty.SaveButton.Visible);
            Assert.IsTrue(m_MockFigurProperty.DeleteButton.Visible);
            Assert.IsFalse(m_MockFigurProperty.CancelButton.Visible);
        }

        [Test]
        public void Test_SetToViewMode()
        {
            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(m_MockFigurProperty);

            figurPropertyPresenter.SetToEditMode();

            Assert.IsFalse(m_MockFigurProperty.NewFigurButton.Visible);
            Assert.IsTrue(m_MockFigurProperty.SaveButton.Visible);
            Assert.IsFalse(m_MockFigurProperty.DeleteButton.Visible);
            Assert.IsTrue(m_MockFigurProperty.CancelButton.Visible);
        }

        [Test]
        public void Test_SetFields_FigurDtoIsNull()
        {
            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(m_MockFigurProperty);

            m_MockFigurProperty.Figur = null;

            figurPropertyPresenter.SetFields();

            Assert.AreEqual(string.Empty, m_MockFigurProperty.FigurName.Text);
            Assert.AreEqual(string.Empty, m_MockFigurProperty.FigurDescription.Text);
            Assert.AreEqual(string.Empty, m_MockFigurProperty.FigurPrice.Text);

            ISerieService serieService = new SerieService();
            var serieDto = serieService.GetById(1);

            Assert.AreEqual(serieDto.SerieId.ToString(), m_MockFigurProperty.ChooseSerie.SelectedItem.Value);
            Assert.AreEqual(serieDto.SerieName, m_MockFigurProperty.ChooseSerie.SelectedItem.Text);
        }

        [Test]
        public void Test_SetFields_FigurDtoIsNotNull()
        {
            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(m_MockFigurProperty);

            m_MockFigurProperty.Figur = new Figur{ FigurId = 0, FigurName = "Test", Description = "Desc", Price = (decimal)11.11, Serie = new Serie { SerieId = 1 }};

            figurPropertyPresenter.SetFields();

            Assert.AreEqual("Test", m_MockFigurProperty.FigurName.Text);
            Assert.AreEqual("Desc", m_MockFigurProperty.FigurDescription.Text);
            Assert.AreEqual("11.11", m_MockFigurProperty.FigurPrice.Text);

            ISerieService serieService = new SerieService();
            var serieDto = serieService.GetById(1);

            Assert.AreEqual(serieDto.SerieId.ToString(), m_MockFigurProperty.ChooseSerie.SelectedItem.Value);
            Assert.AreEqual(serieDto.SerieName, m_MockFigurProperty.ChooseSerie.SelectedItem.Text);
        }

        [Test]
        public void Test_SetFieldsEmpty()
        {
            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(m_MockFigurProperty);
            
            figurPropertyPresenter.SetFieldsEmpty();

            Assert.AreEqual(string.Empty, m_MockFigurProperty.FigurName.Text);
            Assert.AreEqual(string.Empty, m_MockFigurProperty.FigurDescription.Text);
            Assert.AreEqual(string.Empty, m_MockFigurProperty.FigurPrice.Text);

            ISerieService serieService = new SerieService();
            var serieDto = serieService.GetById(1);

            Assert.AreEqual(serieDto.SerieId.ToString(), m_MockFigurProperty.ChooseSerie.SelectedItem.Value);
            Assert.AreEqual(serieDto.SerieName, m_MockFigurProperty.ChooseSerie.SelectedItem.Text);
        }

        [Test]
        public void Test_Update_IfNameIsNotValid()
        {
            m_MockFigurProperty.Figur = new Figur{ FigurId = 0, FigurName = string.Empty, Description = "desc", Price = (decimal)100.11, Serie = new Serie {SerieId = 1}};
            
            FigurPropertyPresenter figurPropertyService = new FigurPropertyPresenter(m_MockFigurProperty);
            figurPropertyService.SetFields();
            
            Assert.IsFalse(figurPropertyService.Update(m_MockFigurProperty.Figur));

            Assert.IsTrue(m_MockFigurProperty.ErrorMessage.Visible);
            string expected = "Bitte geben Sie einen Namen für die Figur ein!" + Environment.NewLine;
            Assert.AreEqual(expected, m_MockFigurProperty.ErrorMessage.Text);
        }

        [Test]
        public void Test_Update_IfPriceIsNotValid()
        {
            m_MockFigurProperty.Figur = new Figur{ FigurId = 0, FigurName = "test", Description = "desc", Price = (decimal)-10.11, Serie = new Serie { SerieId = 1 }};

            FigurPropertyPresenter figurPropertyService = new FigurPropertyPresenter(m_MockFigurProperty);
            figurPropertyService.SetFields();

            Assert.IsFalse(figurPropertyService.Update(m_MockFigurProperty.Figur));

            Assert.IsTrue(m_MockFigurProperty.ErrorMessage.Visible);
            string expected = "Bitte geben Sie einen gültigen Preis ein!" + Environment.NewLine;
            Assert.AreEqual(expected, m_MockFigurProperty.ErrorMessage.Text);
        }

        [Test]
        public void Test_Update_IfNameAndPriceAreNotValid()
        {
            m_MockFigurProperty.Figur = new Figur{ FigurId = 0, FigurName = string.Empty, Description = "desc", Price = (decimal)0.111, Serie = new Serie { SerieId = 1 }};

            FigurPropertyPresenter figurPropertyService = new FigurPropertyPresenter(m_MockFigurProperty);
            figurPropertyService.SetFields();

            Assert.IsFalse(figurPropertyService.Update(m_MockFigurProperty.Figur));

            string expected = "Bitte geben Sie einen Namen für die Figur ein!" + Environment.NewLine + "Bitte geben Sie einen gültigen Preis ein!" + Environment.NewLine;

            Assert.IsTrue(m_MockFigurProperty.ErrorMessage.Visible);
            Assert.AreEqual(expected, m_MockFigurProperty.ErrorMessage.Text);
        }

        [Test]
        public void Test_Update_IfNameAndPriceAreValid()
        {
            m_MockFigurProperty.Figur = new Figur{ FigurId = 0, FigurName = "name", Description = "desc", Price = (decimal)11.11, Serie = new Serie { SerieId = 1 }};

            FigurPropertyPresenter figurPropertyService = new FigurPropertyPresenter(m_MockFigurProperty);
            figurPropertyService.SetFields();
            
            Assert.IsTrue(figurPropertyService.Update(m_MockFigurProperty.Figur));

            Assert.IsFalse(m_MockFigurProperty.ErrorMessage.Visible);
            Assert.AreEqual(string.Empty, m_MockFigurProperty.ErrorMessage.Text);

            //Revert saving
            IFigurService figurService = new FigurService();
            var figurs = figurService.GetAll();
            figurService.DeleteById(figurs[figurs.Count - 1].FigurId);
        }

        [Test]
        public void Test_Delete_IfFigurDtoIsNull()
        {
            m_MockFigurProperty.Figur = null;

            IFigurService figurService = new FigurService();

            var figurDtos = figurService.GetAll();

            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(m_MockFigurProperty);
            figurPropertyPresenter.Delete(m_MockFigurProperty.Figur);

            Assert.AreEqual(figurDtos.Count, figurService.GetAll().Count);
        }
		
		[Test]
		[NUnit.Framework.ExpectedException(typeof(NHibernate.Exceptions.GenericADOException))]
		public void Test_Delete_IfFigurDtoIsNotNull_ForeignKeyDoesNotExist()
		{
			IFigurService figurService = new FigurService();
			
			figurService.SaveOrUpdate(new Figur{ FigurId = 0, FigurName = "test", Description = "desc", Price = (decimal)14.5, Serie = new Serie { SerieId = 10 }});
		}
		
		[Test]
		public void Test_Delete_IfFigurDtoIsNotNull_SaveSuccessfulExecuted()
		{
			IFigurService figurService = new FigurService();
			
			figurService.SaveOrUpdate(new Figur{ FigurId = 0, FigurName = "test", Description = "desc", Price = (decimal)14.5, Serie = new Serie { SerieId = 3 }});
			
			var newfigurDtos = figurService.GetAll();
			
			Assert.AreEqual(10, newfigurDtos.Count);
			
			var figurDto = newfigurDtos.OrderBy(x => x.FigurId).LastOrDefault();
			
			m_MockFigurProperty.Figur = figurDto;
			
			FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(m_MockFigurProperty);
			figurPropertyPresenter.Delete(m_MockFigurProperty.Figur);
			
			Assert.AreEqual(9, figurService.GetAll().Count);
		}
    }
}