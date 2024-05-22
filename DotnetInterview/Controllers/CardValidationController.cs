using Microsoft.AspNetCore.Mvc;

namespace DotnetInterview;

[Route("api/[controller]")]
[ApiController]
public class CardValidationController
{
    [HttpGet]
    public bool ValidateCreditCard(string cardNumber)
    {
        // Remove any non-digit characters from the card number
        cardNumber = cardNumber.Replace(" ", "").Replace("-", "");

        // Check if the card number is empty or contains non-digit characters
        if (string.IsNullOrEmpty(cardNumber) || !cardNumber.All(char.IsDigit))
        {
            return false;
        }

        // Reverse the card number
        char[] cardNumberArray = cardNumber.ToCharArray();
        Array.Reverse(cardNumberArray);

        int sum = 0;
        for (int i = 0; i < cardNumberArray.Length; i++)
        {
            int digit = int.Parse(cardNumberArray[i].ToString());

            // Double every second digit
            if (i % 2 == 1)
            {
                digit *= 2;

                // If the doubled digit is greater than 9, subtract 9
                if (digit > 9)
                {
                    digit -= 9;
                }
            }

            sum += digit;
        }

        // If the sum is divisible by 10, the card number is valid
        return sum % 10 == 0;
    }
}


