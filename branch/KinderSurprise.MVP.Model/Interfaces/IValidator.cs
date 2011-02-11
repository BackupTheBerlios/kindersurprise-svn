namespace KinderSurprise.MVP.Model.Interfaces
{
	public interface IValidator
	{
		bool IsValidString(string stringToTest);
		bool IsValidYear(string yearToTest);
		bool IsValidPrice(string priceToTest);
	}
}

