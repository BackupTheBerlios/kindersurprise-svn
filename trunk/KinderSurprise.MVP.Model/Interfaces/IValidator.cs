namespace KinderSurprise.MVP.Model
{
	public interface IValidator
	{
		bool IsValidString(string stringToTest);
		bool IsValidYear(string yearToTest);
		bool IsValidPrice(string priceToTest);
	}
}

