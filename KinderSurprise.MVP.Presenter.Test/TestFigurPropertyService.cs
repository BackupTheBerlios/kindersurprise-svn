using System;
using System.Web.UI.WebControls;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
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
			m_MockFigurProperty.FigurDto = null;
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

            m_MockFigurProperty.FigurDto = null;

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

            m_MockFigurProperty.FigurDto = new FigurDto(0, "Test", "Desc", (decimal)11.11, new Serie { SerieId = 1 });

            figurPropertyPresenter.SetFields();

            Assert.AreEqual("Test", m_MockFigurProperty.FigurName.Text);
            Assert.AreEqual("Desc", m_MockFigurProperty.FigurDescription.Text);
            Assert.AreEqual("11,11", m_MockFigurProperty.FigurPrice.Text);

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
            m_MockFigurProperty.FigurDto = new FigurDto(0, string.Empty, "desc", (decimal)100.11, new Serie {SerieId = 1} );
            
            FigurPropertyPresenter figurPropertyService = new FigurPropertyPresenter(m_MockFigurProperty);
            figurPropertyService.SetFields();
            
            Assert.IsFalse(figurPropertyService.Update(m_MockFigurProperty.FigurDto));

            Assert.IsTrue(m_MockFigurProperty.ErrorMessage.Visible);
            string expected = "Bitte geben Sie einen Namen für die Figur ein!" + Environment.NewLine;
            Assert.AreEqual(expected, m_MockFigurProperty.ErrorMessage.Text);
        }

        [Test]
        public void Test_Update_IfPriceIsNotValid()
        {
            m_MockFigurProperty.FigurDto = new FigurDto(0, "test", "desc", (decimal)-10.11, new Serie { SerieId = 1 });

            FigurPropertyPresenter figurPropertyService = new FigurPropertyPresenter(m_MockFigurProperty);
            figurPropertyService.SetFields();

            Assert.IsFalse(figurPropertyService.Update(m_MockFigurProperty.FigurDto));

            Assert.IsTrue(m_MockFigurProperty.ErrorMessage.Visible);
            string expected = "Bitte geben Sie einen gültigen Preis ein!" + Environment.NewLine;
            Assert.AreEqual(expected, m_MockFigurProperty.ErrorMessage.Text);
        }

        [Test]
        public void Test_Update_IfNameAndPriceAreNotValid()
        {
            m_MockFigurProperty.FigurDto = new FigurDto(0, string.Empty, "desc", (decimal)0.111, new Serie { SerieId = 1 });

            FigurPropertyPresenter figurPropertyService = new FigurPropertyPresenter(m_MockFigurProperty);
            figurPropertyService.SetFields();

            Assert.IsFalse(figurPropertyService.Update(m_MockFigurProperty.FigurDto));

            string expected = "Bitte geben Sie einen Namen für die Figur ein!" + Environment.NewLine + "Bitte geben Sie einen gültigen Preis ein!" + Environment.NewLine;

            Assert.IsTrue(m_MockFigurProperty.ErrorMessage.Visible);
            Assert.AreEqual(expected, m_MockFigurProperty.ErrorMessage.Text);
        }

        [Test]
        public void Test_Update_IfNameAndPriceAreValid()
        {
            m_MockFigurProperty.FigurDto = new FigurDto(0, "name", "desc", (decimal)11.11, new Serie { SerieId = 1 });

            FigurPropertyPresenter figurPropertyService = new FigurPropertyPresenter(m_MockFigurProperty);
            figurPropertyService.SetFields();
            
            Assert.IsTrue(figurPropertyService.Update(m_MockFigurProperty.FigurDto));

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
            m_MockFigurProperty.FigurDto = null;

            IFigurService figurService = new FigurService();

            var figurDtos = figurService.GetAll();

            FigurPropertyPresenter figurPropertyPresenter = new FigurPropertyPresenter(m_MockFigurProperty);
            figurPropertyPresenter.Delete(m_MockFigurProperty.FigurDto);

            Assert.AreEqual(figurDtos.Count, figurService.GetAll().Count);
        }
    }
}