namespace KinderSurprise.MVP.Model
{
    public class ValidationHandling
    {
        public bool IsValidString(string stringToTest)
        {
            if (string.IsNullOrEmpty(stringToTest))
                return false;

            return stringToTest.Trim() != string.Empty;
        }

        public bool IsValidYear(string yearToTest)
        {
            if (!IsValidString(yearToTest))
                return false;
            
            int year;
            
            if (!int.TryParse(yearToTest, out year))
                return false;

            return year >= 1900 && year <= 9999;
        }

        public bool IsValidPrice(string priceToTest)
        {
            if (!IsValidString(priceToTest))
                return false;

            int posOfPoint = -1;
            int iBeforePoint;
            const char splitter = ',';

            if(priceToTest.Contains(splitter.ToString()))
            {
                posOfPoint = priceToTest.IndexOf(splitter) + 1;
                string sAfterPoint = priceToTest.Substring(posOfPoint, priceToTest.Length - posOfPoint);
                if (sAfterPoint.Length > 2)
                    return false;
                int iAfterPoint;
                if (!int.TryParse(sAfterPoint, out iAfterPoint))
                    return false;
            }

            if(posOfPoint == -1)
            {
                if (!int.TryParse(priceToTest, out iBeforePoint))
                    return false;
            }
            else
            {
                if (!int.TryParse(priceToTest.Substring(0, posOfPoint-1), out iBeforePoint))
                    return false;
            }
            if (iBeforePoint < 0)
                return false;
            
            return true;
        }
    }
}
