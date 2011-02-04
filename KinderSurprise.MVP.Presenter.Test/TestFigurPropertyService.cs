using System;
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
            m_MockFigurProperty.Name = new TextBox();
            m_MockFigurProperty.Description = new TextBox();
            m_MockFigurProperty.Price = new TextBox();
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

            Assert.AreEqual(string.Empty, m_MockFigurProperty.Name.Text);
            Assert.AreEqual(string.Empty, m_MockFigurProperty.Description.Text);
            Assert.AreEqual(string.Empty, m_MockFigurProperty.Price.Text);

            ISerieService serieService = new SerieService();
            var serieDto = serieService.GetById(1);

            Assert.AreEqual(serieDto.Id.ToString(), m_MockFigurProperty.ChooseSerie.SelectedItem.Value);
            Assert.AreEqual(serieDto.Name, m_MockFigurProperty.ChooseSerie.SelectedItem.Text);
        }

        [Test]
        public void Test_SetFields_FigurDtoIsNotNull()
        {
            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(m_MockFigurProperty);

            m_MockFigurProperty.Figur = new Figur{ Id = 0, Name = "Test", Description = "Desc", Price = (decimal)11.11, Serie = new Serie { Id = 1 }};

            figurPropertyPresenter.SetFields();

            Assert.AreEqual("Test", m_MockFigurProperty.Name.Text);
            Assert.AreEqual("Desc", m_MockFigurProperty.Description.Text);
            Assert.AreEqual("11.11", m_MockFigurProperty.Price.Text);

            ISerieService serieService = new SerieService();
            var serieDto = serieService.GetById(1);

            Assert.AreEqual(serieDto.Id.ToString(), m_MockFigurProperty.ChooseSerie.SelectedItem.Value);
            Assert.AreEqual(serieDto.Name, m_MockFigurProperty.ChooseSerie.SelectedItem.Text);
        }

        [Test]
        public void Test_SetFieldsEmpty()
        {
            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(m_MockFigurProperty);
            
            figurPropertyPresenter.SetFieldsEmpty();

            Assert.AreEqual(string.Empty, m_MockFigurProperty.Name.Text);
            Assert.AreEqual(string.Empty, m_MockFigurProperty.Description.Text);
            Assert.AreEqual(string.Empty, m_MockFigurProperty.Price.Text);

            ISerieService serieService = new SerieService();
            var serieDto = serieService.GetById(1);

            Assert.AreEqual(serieDto.Id.ToString(), m_MockFigurProperty.ChooseSerie.SelectedItem.Value);
            Assert.AreEqual(serieDto.Name, m_MockFigurProperty.ChooseSerie.SelectedItem.Text);
        }

        [Test]
        public void Test_Update_IfNameIsNotValid()
        {
            m_MockFigurProperty.Figur = new Figur{ Id = 0, Name = string.Empty, Description = "desc", Price = (decimal)100.11, Serie = new Serie {Id = 1}};
            
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
            m_MockFigurProperty.Figur = new Figur{ Id = 0, Name = "test", Description = "desc", Price = (decimal)-10.11, Serie = new Serie { Id = 1 }};

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
            m_MockFigurProperty.Figur = new Figur{ Id = 0, Name = string.Empty, Description = "desc", Price = (decimal)0.111, Serie = new Serie { Id = 1 }};

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
            m_MockFigurProperty.Figur = new Figur{ Id = 0, Name = "name", Description = "desc", Price = (decimal)11.11, Serie = new Serie { Id = 1 }};

            FigurPropertyPresenter figurPropertyService = new FigurPropertyPresenter(m_MockFigurProperty);
            figurPropertyService.SetFields();
            
            Assert.IsTrue(figurPropertyService.Update(m_MockFigurProperty.Figur));

            Assert.IsFalse(m_MockFigurProperty.ErrorMessage.Visible);
            Assert.AreEqual(string.Empty, m_MockFigurProperty.ErrorMessage.Text);

            //Revert saving
            IFigurService figurService = new FigurService();
            var figurs = figurService.GetAll();
            figurService.DeleteById(figurs[figurs.Count - 1].Id);
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
			
			figurService.SaveOrUpdate(new Figur{ Id = 0, Name = "test", Description = "desc", Price = (decimal)14.5, Serie = new Serie { Id = 10 }});
		}
		
		[Test]
		public void Test_Delete_IfFigurDtoIsNotNull_SaveSuccessfulExecuted()
		{
			IFigurService figurService = new FigurService();
			
			figurService.SaveOrUpdate(new Figur{ Id = 0, Name = "test", Description = "desc", Price = (decimal)14.5, Serie = new Serie { Id = 3 }});
			
			var newfigurs = figurService.GetAll();
			
			Assert.AreEqual(10, newfigurs.Count);
			
			var figur = newfigurs.OrderBy(x => x.Id).LastOrDefault();
			
			m_MockFigurProperty.Figur = figur;
			
			FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(m_MockFigurProperty);
			figurPropertyPresenter.Delete(m_MockFigurProperty.Figur);
			
			Assert.AreEqual(9, figurService.GetAll().Count);
		}
    }
}