using System.Transactions;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            string userInput;
            do
            {
                calculator.Calculate();

                Console.WriteLine("Do you want to calculate more? [y/n]");
                userInput = Console.ReadLine().ToLower();
                while (userInput != "y" && userInput != "n")
                {
                    Console.WriteLine("Invalid input. Use \'y\' for yes, \'n\' for no");
                    userInput = Console.ReadLine().ToLower();
                }
            }
            while (userInput == "y");
        }
    }

    public class Calculator
    {
        private float _num1 = 0f;
        private float _num2 = 0f;
        private float _result = 0f;

        public void Calculate()
        {
            GetNumbers();

            while (true)
            {
                Console.WriteLine("Enter a provided symbol to calculate the result:");
                Console.WriteLine("+ , -, /, *");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "+" || userInput == "-" || userInput == "/" || userInput == "*")
                {
                    switch (userInput)
                    {
                        case "+":
                            _result = _num1 + _num1;
                            break;
                        case "-":
                            _result = _num1 - _num2;
                            break;
                        case "/":
                            if (_num2 != 0)
                            {
                                _result = _num1 / _num2;
                            }
                            else
                            {
                                Console.WriteLine("Cannot divide by zero.");
                                return;
                            }
                            break;
                        case "*":
                            _result = _num1 * _num2;
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;

                    }
                    Console.WriteLine($"The result is: {_num1}{userInput}{_num2} = {_result}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }

        }



        private void GetNumbers()
        {
            while (true)
            {
                Console.WriteLine("Enter the first number:");
                string userInput1 = Console.ReadLine();
                if (float.TryParse(userInput1, out _num1) && !string.IsNullOrEmpty(userInput1))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            while (true)
            {
                Console.WriteLine("Enter the second number:");
                string userInput2 = Console.ReadLine();
                if (float.TryParse(userInput2, out _num2) && !string.IsNullOrEmpty(userInput2))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
