namespace p4cs
{
    class Coursework
    {
        static bool IsTrinary(string input)
        {
            foreach (char digit in input)
            {
                if (digit != '0' && digit != '1' && digit != '2')
                {
                    return false;
                }
            }
            return true;
        }

        static int ConvertToDecimal(string trinaryInput)
        {
            int decimalResult = 0;
            for (int i = trinaryInput.Length - 1, power = 0; i >= 0; i--, power++)
            {
                int digit = trinaryInput[i] - '0';

                decimalResult += digit * (int)Math.Pow(3, power);
            }
            return decimalResult;
        }

        static void AddKeyValuePair(Dictionary<string, List<string>> dictionary)
        {
            Console.WriteLine("Enter form (1-10)");
            if (int.TryParse(Console.ReadLine(), out int key) && key >= 1 && key <= 10)
            {
                string stringValue = key.ToString();
                Console.Write("Enter student ");
                string value = Console.ReadLine();
                if (!dictionary.ContainsKey(stringValue))
                {
                    dictionary[stringValue] = new List<string> { value };
                }

                else
                {
                    dictionary[stringValue].Add(value);
                }
                Console.WriteLine("Student added successfuly");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine("Invalid form, try again");
                Console.ReadLine();
            }
        }

        static void SortValuesAlphabetically(Dictionary<string, List<string>> dictionary)
        {
            foreach (var kvp in dictionary)
            {
                kvp.Value.Sort();
            }

        }

        static void DisplayStudents(Dictionary<string, List<string>> dictionary)
        {
            foreach (var kvp in dictionary)
            {
                Console.Write($"In form {kvp.Key}, there are: ");
                Console.WriteLine(string.Join(", ", kvp.Value));
            }

            if (dictionary.Count == 0)
            {
                Console.WriteLine("Add students to forms first.");
                Console.ReadLine();
            }

        }

        static void DisplayValuesForForm(Dictionary<string, List<string>> dictionary, string form)
        {
            if (dictionary.ContainsKey(form))
            {
                Console.WriteLine($"Students in form {form} are: {string.Join(", ", dictionary[form])}");
                Console.ReadLine();
            }

            else
            {
                Console.WriteLine($"There are no students in form {form}.");
                Console.ReadLine();
            }
        }

        static bool IsValidISBN10(string isbn)
        {
            isbn = isbn.Replace("-", "");
            if (isbn.Length != 10)
            {
                return false;
            }

            if (!IsNumeric(isbn.Substring(0, 9)))
            {
                return false;
            }

            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += ((10 - i) * (isbn[i] - '0'));
            }
            int checkDigit = isbn[9] == 'X' ? 10 : (isbn[9] - '0');
            return (sum + checkDigit) % 11 == 0;
        }

        static bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        //tests

        //trinary converter:

        //input: 1, expected result: 1, actual result: 1
        //input: 2, expected result: 2, actual result: 2
        //input: 10,expected result: 3, actual result: 3
        //input: 112,expected result: 14, actual result: 14
        //input: 10,expected result: 3, actual result: 3
        //input: 1122000120,expected result: 1122000120, actual result: 1122000120
        //input: 7,expected result: error, actual result: error

        //school roster

        //input: 2, Aimee expected input: form 2: Aimee, actual result: form 2: Aimee
        //input: 2, Blair, 2, James, 2, Paul, 2, expected result: form 2: Blair, James, Paul, actual result: form 2: Blair, James, Paul
        //input: 3, Chelsea, 7, Logan, :expected result: Form 3: Chelsea, form 7: Logan
        //input: 4, Jennifer, 4, Kareem, 4, Chris, 3, Claire, expected result : form 3: Claire, form 4: Jennifer, Chris, form 6: Kareem actual result: form 3: Claire, form 4: Jennifer, Chris, form 6: Kareem

        //isbn verifier

        //input: 3-598-21508-8, expected result: Valid, actual result: Valid
        //input: 3-598-21507-X, expected result: Valid, actual result: Valid
        //input: 3-598-21508-9, expected result: Invalid, actual result: Invalid
        //input: 3-598-21507-A, expected result: Invalid, actual result: Invalid
        //input: 3-598-2X507-9, expected result: Invalid, actual result: Invalid

        public static void Main(string[] args)
        {
            var running = true;
            while (running)
            {
                Console.WriteLine("Choose one of the following options:\n----------------------------\na)Trinary Converter.\nb)School Roster.\nc)ISBN Verifier.\nq)End the program.");
                string menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "a":
                        Console.WriteLine("Welcome to the trinary converter");
                        var trinaryConverter = true;
                        while (trinaryConverter)
                        {
                            Console.Write("----------------------------\nEnter a trinary number: ");
                            string trinaryInput = Console.ReadLine();

                            if (IsTrinary(trinaryInput))
                            {
                                int decimalResult = ConvertToDecimal(trinaryInput);
                                Console.WriteLine($"Decimal equivalent: {decimalResult}");
                            }

                            else
                            {
                                Console.WriteLine("Invalid trinary number entered.");
                            }

                            var invalidInputTC = true;

                            while (invalidInputTC)
                            {
                                Console.WriteLine("Would you like to convert another number?\na) Yes\nb) No");
                                string trinaryConverterLoop = Console.ReadLine();

                                switch (trinaryConverterLoop)
                                {
                                    case "a":
                                        trinaryConverter = true;
                                        invalidInputTC = false;
                                        break;
                                    case "b":
                                        trinaryConverter = false;
                                        invalidInputTC = false;
                                        break;
                                    default:
                                        Console.WriteLine("Enter a valid input");
                                        break;
                                }
                            }
                        }
                        break;
                    case "b":
                        Dictionary<string, List<string>> students = new Dictionary<string, List<string>>();
                        var schoolRoster = true;
                        while (schoolRoster)
                        {
                            Console.WriteLine("Select an option\n----------------------------\na) Add students to roster\nb) List all students listed in a form\nc) See all forms\nq) Go back to main menu");
                            string schoolRosterOption = Console.ReadLine();
                            switch (schoolRosterOption)
                            {
                                case "a":
                                    var addStudents = true;
                                    while (addStudents)
                                    {
                                        AddKeyValuePair(students);
                                        var invalidInputAddStudents = true;
                                        while (invalidInputAddStudents)
                                        {
                                            Console.WriteLine("Would you like to add more students?\na) Yes\nb) No");
                                            string addStudentsLoop = Console.ReadLine();
                                            switch (addStudentsLoop)
                                            {

                                                case "a":
                                                    addStudents = true;
                                                    invalidInputAddStudents = false;
                                                    break;
                                                case "b":
                                                    addStudents = false;
                                                    invalidInputAddStudents = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("Enter a valid input");
                                                    break;
                                            }
                                        }
                                    }
                                    break;
                                case "b":
                                    SortValuesAlphabetically(students);
                                    Console.WriteLine("Which form would you like to look at?");
                                    string key = Console.ReadLine();
                                    DisplayValuesForForm(students, key);
                                    break;
                                case "c":
                                    SortValuesAlphabetically(students);
                                    DisplayStudents(students);
                                    break;
                                case "q":
                                    schoolRoster = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid input");
                                    Console.ReadLine();
                                    break;
                            }
                        }
                        break;
                    case "c":
                        var isbnVerifier = true;

                        while (isbnVerifier)
                        {
                            Console.Write("Enter ISBN-10: ");
                            string isbn = Console.ReadLine();
                            if (IsValidISBN10(isbn))
                            {
                                Console.WriteLine("Valid ISBN-10.");
                                Console.ReadLine();
                            }

                            else
                            {
                                Console.WriteLine("Invalid ISBN-10.");
                                Console.ReadLine();
                            }

                            var invalidInputIsbn = true;

                            while (invalidInputIsbn)
                            {
                                Console.WriteLine("Would you like to enter another ISBN?\na) Yes\nb) No");
                                string isbnLoop = Console.ReadLine();

                                switch (isbnLoop)
                                {
                                    case "a":
                                        isbnVerifier = true;
                                        invalidInputIsbn = false;
                                        break;
                                    case "b":
                                        isbnVerifier = false;
                                        invalidInputIsbn = false;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input, try again");
                                        break;
                                }
                            }
                        }
                        break;
                    case "q":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input try again");
                        break;
                }
            }
        }
    }
}