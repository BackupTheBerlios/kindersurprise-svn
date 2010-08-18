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

        private class MockFigurProperty : IFigurPropertyPresenter
        {
            private Button m_NewFigurButton = new Button();
            private Button m_SaveButton = new Button();
            private Button m_DeleteButton = new Button();
            private Button m_CancelButton = new Button();
            private Label m_ErrorMessage = new Label();
            private TextBox m_FigurName = new TextBox();
            private TextBox m_FigurDescription = new TextBox();
            private TextBox m_FigurPrice = new TextBox();
            private DropDownList m_ChooseSerie = new DropDownList();
            private FigurDto m_FigurDto;

            public Button NewFigurButton
            {
                get { return m_NewFigurButton; }
                set { m_NewFigurButton = value; }
            }

            public Button SaveButton
            {
                get { return m_SaveButton; }
                set { m_SaveButton = value; }
            }

            public Button DeleteButton
            {
                get { return m_DeleteButton; }
                set { m_DeleteButton = value; }
            }

            public Button CancelButton
            {
                get { return m_CancelButton; }
                set { m_CancelButton = value; }
            }

            public TextBox FigurName
            {
                get { return m_FigurName; }
                set { m_FigurName = value; }
            }

            public TextBox FigurDescription
            {
                get { return m_FigurDescription; }
                set { m_FigurDescription = value; }
            }

            public TextBox FigurPrice
            {
                get { return m_FigurPrice; }
                set { m_FigurPrice = value; }
            }

            public DropDownList ChooseSerie
            {
                get { return m_ChooseSerie; }
                set { m_ChooseSerie = value; }
            }

            public Label ErrorMessage
            {
                get { return m_ErrorMessage; }
                set { m_ErrorMessage = value; }
            }

            public FigurDto FigurDto
            {
                get { return m_FigurDto; }
                set { m_FigurDto = value; }
            }
        }

        private MockFigurProperty m_MockFigurProperty;

        [SetUp]
        public void Setup()
        {
            m_MockFigurProperty = new MockFigurProperty();
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
