namespace KataAttemptFour
{
    public class AttemptFour
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            NegetiveNumbersException(ExtractNumbersFromTextInput(numbers));
            return SumOfAllNumbers(numbers);
        }

        public int SumOfAllNumbers(string numbersToAdd)
        {
            int biggestAllowedNumber = 1000;
            return (from number in ExtractNumbersFromTextInput(numbersToAdd)
                    where number <= biggestAllowedNumber select number).Sum();
        }

        public List<int> ExtractNumbersFromTextInput(string NumbersToExtract)
        {
            int isInteger = 0;
            string[] numbersArray = NumbersToExtract.Split(DelimeterList(NumbersToExtract).ToArray(), StringSplitOptions.None);
            return numbersArray.Where(x => int.TryParse(x, out isInteger)).Select(x => isInteger).ToList();
        }

        public List<string> DelimeterList(string numbersWithDelimeters)
        {
            List<string> delimeterList = new List<string>() { ",", "\n" };
            if (numbersWithDelimeters.StartsWith("//"))
            {
                if (numbersWithDelimeters.Substring(2, 1) == "[")
                    return delimeterList.Union(DelimetersInBrackets(numbersWithDelimeters)).ToList();

                var numbersWithDelimetersSplit = numbersWithDelimeters.Split("\n");
                int firstHalfLength = numbersWithDelimetersSplit[0].Length;
                delimeterList.Add(numbersWithDelimetersSplit[0].Substring(2, firstHalfLength - 2));
            }
            return delimeterList;
        }

        public List<string> DelimetersInBrackets(string numbersWithDelimeters)
        {
            int indexOfClosingSqureBracket = numbersWithDelimeters.LastIndexOf("]");
            string delimeter = numbersWithDelimeters.Substring(3, indexOfClosingSqureBracket - 3).Trim(']');
            return delimeter.Split("][").ToList();
        }

        public void NegetiveNumbersException(List<int> arrayOfNumbers)
        {
            int count = 0;
            string negetives = "Negetives not allowed.";
            foreach (var item in arrayOfNumbers)
            {
                if (item < 0)
                {
                    negetives += "\n" + item;
                    count++;
                }
            }
            if (count > 0)
            {
                throw new Exception(negetives);
            }
        }
    }
}