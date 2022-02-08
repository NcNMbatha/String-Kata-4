namespace KataAttemptFour
{
    public class AttemptFour
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;
            if (CountNegetiveNumbers(numbers) > 0)
            {
                NegetiveNumbersException(ExtractNumbersFromTextInput(numbers));
            }
            return SumOfAllNumbers(numbers);
        }
        public int CountNegetiveNumbers(string numbersToCount)
        {
            return (from number in ExtractNumbersFromTextInput(numbersToCount)
                    where number < 0
                    select number).Count();
        }
        public int SumOfAllNumbers(string numbersToAdd)
        {
            return FilteredArrayOfNumbers(numbersToAdd).Sum();
        }
        public List<int> FilteredArrayOfNumbers(string numbersToFilter)
        {
            return (from number in ExtractNumbersFromTextInput(numbersToFilter)
                    where number <= 1000
                    select number).ToList();
        }
        public List<int> ExtractNumbersFromTextInput(string NumbersToExtract)
        {
            List<int> arrayOfNumbers = new List<int>();
            string[] numbersArray = NumbersToExtract.Split(DelimeterList(NumbersToExtract).ToArray(), StringSplitOptions.None);
            foreach (var number in numbersArray)
            {
                if (int.TryParse(number, out int num))
                {
                    arrayOfNumbers.Add(num);
                }
            }
            return arrayOfNumbers;
        }
        public List<string> DelimeterList(string numbersWithDelimeters)
        {
            List<string> list = new List<string>() { ",", "\n" };
            if (numbersWithDelimeters.StartsWith("//"))
            {
                if (numbersWithDelimeters.Substring(2, 1) == "[")
                    return list.Union(DelimetersInBrackets(numbersWithDelimeters)).ToList();

                var splitOutput = numbersWithDelimeters.Split("\n");
                int index = splitOutput[0].Length;
                list.Add(splitOutput[0].Substring(2, index - 2));
            }
            return list;
        }
        public List<string> DelimetersInBrackets(string numbersWithDelimeters)
        {
            int index = numbersWithDelimeters.LastIndexOf("]");
            string delimeter = numbersWithDelimeters.Substring(3, index - 3).Trim(']');
            return delimeter.Split("][").ToList();
        }
        public Exception NegetiveNumbersException(List<int> arrayOfNumbers)
        {
            string negetives = "Negatives not allowed.";
            foreach (var item in arrayOfNumbers)
            {
                if (item < 0)
                {
                    negetives += "\n" + item;
                }
            }
            throw new Exception(negetives);
        }
    }
}