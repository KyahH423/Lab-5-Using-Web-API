/*       
 *--------------------------------------------------------------------
 * 	   File name: Program.cs
 * 	Project name: Lab5_Web_API
 *--------------------------------------------------------------------
 * Author’s name and email:	 Kyah Hanson - hansonkm@etsu.edu				
 *          Course-Section:  CSCI-2910-800
 *           Creation Date:	 10/5/2023		
 * -------------------------------------------------------------------
 */
using Lab5_Web_API;
using Newtonsoft.Json;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to our Supernatural Character Database!");
        bool run = true;
        while (run == true)
        {
            await CharacterCall();
            Console.WriteLine("Would you like to search for another character? Please enter 'Y' for 'Yes' or 'N' for 'No':");
            string input = Console.ReadLine().ToLower();
            while (input != "y" && input != "n")
            {
                Console.WriteLine("Error: Invalid Input\nPlease enter 'Y' or 'N':");
                input = Console.ReadLine().ToLower();
            }
            if (input == "n")
            {
                run = false;
            }
            else
            {
                run = true;
            }

        }
    }

    // Gets character data from API
    public static async Task CharacterCall()
    {
        // sending our request to https://supernatural-quotes-api.cyclic.app/characters

        // create a HttpClient object to use to send the request
        var client = new HttpClient();

        // Prompts user to search by name or actor and checks until input is valid
        Console.WriteLine("Would you like to search by the character's name or actor:");
        string userInput = Console.ReadLine().ToLower();
        while (userInput != "actor" && userInput != "name")
        {
            Console.WriteLine("Error: Invalid Input\nPlease enter 'name' or 'actor' to continue:");
            userInput = Console.ReadLine();
        }
        string searchBy = "";
        if (userInput == "actor")
        {
            searchBy = "actor";
        }
        else
        {
            searchBy = "name";
        }

        // Prompts user for name or actor of character based on previous input
        Console.WriteLine($"Now please enter the {searchBy} you would like to search for:");
        userInput = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(userInput) == true || string.IsNullOrEmpty(userInput) == true || userInput.Length < 3)
        {
            Console.WriteLine($"Please enter an {searchBy}");
            userInput = Console.ReadLine();
        }

        // Receive a response and store it in a variable
        // use 'await' when accessing an async method / resource
        HttpResponseMessage response = await client.GetAsync($"https://supernatural-quotes-api.cyclic.app/characters?size=1105&{searchBy}={userInput}");
        string json = await response.Content.ReadAsStringAsync();
        CharacterMeta d = JsonConvert.DeserializeObject<CharacterMeta>(json);

        // Checks to see if the key has empty values
        while (d.data.Count == 0)
        {
            Console.WriteLine("Error: Invalid Input\nThat value does not exist within our database, please try again:");
            userInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userInput) == true || string.IsNullOrEmpty(userInput) == true || userInput.Length < 3)
            {
                Console.WriteLine($"Please enter an {searchBy}");
                userInput = Console.ReadLine();
            }
            response = await client.GetAsync($"https://supernatural-quotes-api.cyclic.app/characters?size=1105&{searchBy}={userInput}");
            json = await response.Content.ReadAsStringAsync();
            d = JsonConvert.DeserializeObject<CharacterMeta>(json);
        }

        // Provides user with list of responses available based on input
        List<Character> list = new List<Character>();
        list = d.data.ToList();
        int counter = 1;
        Console.WriteLine("Here is all of the characters we have associated with your input:");
        Console.WriteLine("-----------------------------------------------------------------");
        foreach (var item in list)
        {
            Console.WriteLine($"{counter}. {item.Name}");
            counter++;
        }

        // Allows user to select specific character to see more information
        Console.WriteLine("Please enter the number associated with the character that you would like to view more information for:");
        userInput = Console.ReadLine();
        while ((int.TryParse(userInput, out int id) == false) || Convert.ToInt32(userInput) <= 0 || Convert.ToInt32(userInput) > list.Count())
        {
            Console.WriteLine("Error: Invalid Input\nPlease enter one of the numbers associate with the character you would like to view more information for:");
            userInput = Console.ReadLine();
        }

        int characterNum = Convert.ToInt32(userInput);
        Console.Clear();
        Console.WriteLine(list[characterNum - 1]);
        Console.WriteLine("Press enter to return to the main screen");
        Console.ReadLine();
        Console.Clear() ;
    }
}
