namespace discountassessment4
{
    using System;

    public class Candy
    {
        // Properties
        public string Flavour { get; set; }
        public int Quantity { get; set; }
        public int PricePerPiece { get; set; }
        public double TotalPrice { get; set; }

        // Method to validate the candy flavour
        public bool ValidateCandyFlavour()
        {
            return Flavour.Equals("Strawberry", StringComparison.OrdinalIgnoreCase) ||
                   Flavour.Equals("Lemon", StringComparison.OrdinalIgnoreCase) ||
                   Flavour.Equals("Mint", StringComparison.OrdinalIgnoreCase);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a new Candy object
            Candy candy = new Candy();

            // Get candy details from the user
            Console.Write("Enter the candy flavour: ");
            candy.Flavour = Console.ReadLine();

            Console.Write("Enter the quantity: ");
            candy.Quantity = int.Parse(Console.ReadLine());

            Console.Write("Enter the price per piece: ");
            candy.PricePerPiece = int.Parse(Console.ReadLine());

            // Calculate the discounted price
            Candy discountedCandy = CalculateDiscountedPrice(candy);

            // Display the results
            Console.WriteLine($"Flavour: {discountedCandy.Flavour}");
            Console.WriteLine($"Quantity: {discountedCandy.Quantity}");
            Console.WriteLine($"Price Per Piece: {discountedCandy.PricePerPiece}");
            Console.WriteLine($"Total Price after discount: {discountedCandy.TotalPrice}");
        }

        public static Candy CalculateDiscountedPrice(Candy candy)
        {
            // Calculate total price
            candy.TotalPrice = candy.Quantity * candy.PricePerPiece;

            // Determine the discount percentage based on the flavour
            double discountPercentage = 0;

            switch (candy.Flavour.ToLower())
            {
                case "strawberry":
                    discountPercentage = 15;
                    break;
                case "lemon":
                    discountPercentage = 10;
                    break;
                case "mint":
                    discountPercentage = 5;
                    break;
                default:
                    Console.WriteLine("No discount available for this flavour.");
                    return candy; // No discount, return the original candy
            }

            // Apply discount
            candy.TotalPrice -= (candy.TotalPrice * discountPercentage / 100);

            return candy; // Return the candy object with the discounted price
        }
    }

}
