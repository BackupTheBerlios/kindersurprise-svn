﻿using System.Web.UI.WebControls;
using KinderSurprise.Model;

namespace KinderSurprise.MVP.Presenter.Interfaces
{
    public interface ICategoryPropertyPresenter
    {
        Label ErrorLabel { get; set; }
        TextBox NameTextBox { get; set; }
        TextBox DescriptionTextBox { get; set; }
        
        Button NewSerie { get; set; }
        Button NewCategory  { get; set; }
        Button Cancel  { get; set; }
        Button Delete  { get; set; }
        Button Update { get; set; }
        
        Category Category { get; set; }
    }
}
