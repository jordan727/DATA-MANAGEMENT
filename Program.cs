// DATA MANAGEMENT - Jordan Antonio
// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-6-0
using System.Text.Json;
// using System.Text.Json.Serialization;
#nullable disable
Console.Clear();

// DATA
string accountsFile = $"json/accounts.json";
string dataFile = $"json/data.json";

string accountsString = File.ReadAllText(accountsFile);
string dataString = File.ReadAllText(dataFile);

List<User> users = JsonSerializer.Deserialize<List<User>>(accountsString)!;
List<Char> characters = JsonSerializer.Deserialize<List<Char>>(dataString)!;

bool loginLoop = true;
bool mainLoop = false;

while (loginLoop) {
    login();
}

void login() {
    Console.WriteLine("WELCOME");
    Console.WriteLine("1. Login");
    Console.WriteLine("2. Create New Account");
    Console.WriteLine("3. Exit");
    string accountOption = Console.ReadLine();

    if (accountOption == "1") {
        Console.WriteLine("LOGIN");
        Console.Write("Enter Username: ");
        string enteredUsername = Console.ReadLine();
        Console.Write("\nEnter Password: ");
        string enteredPassword = Console.ReadLine();
        for (int n = 0; n < users.Count; n++) {
            if (users[n].Username == enteredUsername && users[n].Password == enteredPassword) {
                Console.WriteLine("\nSuccessfully Logged in");
                loginLoop = false;
                mainLoop = true;
                return;
            }
        }
        Console.WriteLine("\nInvalid Login Credentials\n");

    } else if (accountOption == "2") {
        Console.WriteLine("CREATE ACCOUNT");
        Console.Write("Enter Username: ");
        string newUsername = Console.ReadLine();
        Console.Write("\nEnter Password: ");
        string newPassword = Console.ReadLine();
        users.Add(new User(newUsername, newPassword));
        Console.WriteLine("Account Successfully Created");
        // Save all account data
        string json = JsonSerializer.Serialize(users);
        File.WriteAllText(accountsFile, json);
    } else if (accountOption == "3") {
        loginLoop = false;
    } else {
        Console.WriteLine("INVALID ANSWER\n");
    }
}

// Welcome
while (mainLoop) {
    Console.WriteLine("\nMAIN MENU");
    Console.WriteLine("1. Display All Data");
    Console.WriteLine("2. Display Filtered Data");
    Console.WriteLine("3. Sort Data");
    Console.WriteLine("4. Add New Favourites");
    Console.WriteLine("5. Remove Favourites");
    Console.WriteLine("6. Display Favourites");
    Console.WriteLine("7. Logout");
    Console.WriteLine("8. Exit\n");
    string option = Console.ReadLine();

    if (option == "1") {
        for (int n = 0; n < characters.Count; n++) {
            Console.WriteLine($"Name: {characters[n].Name} | Role: {characters[n].Role} | Origin: {characters[n].Origin}");
        }
    } else if (option == "2") {
        Console.WriteLine("FILTER DATA");
        Console.WriteLine("1. Search a Name");
        Console.WriteLine("2. Filter by Role");
        Console.WriteLine("3. Filter by Origin");
        Console.WriteLine("4. Back");
        string filterOption = Console.ReadLine();
        
        if (filterOption == "1") {
            Console.WriteLine("Please Enter a Name");
            string enteredName = Console.ReadLine();
            int searchIndex = linearSearch(characters, enteredName);
            if (searchIndex == -1) {
                Console.WriteLine("Name not found");
            } else {
                Console.WriteLine($"\nName: {characters[searchIndex].Name} | Role: {characters[searchIndex].Role} | Origin: {characters[searchIndex].Origin}");
            }
        } else if (filterOption == "2") {
            Console.WriteLine("Select Role to Search");
            Console.WriteLine("1. Duelist");
            Console.WriteLine("2. Initiator");
            Console.WriteLine("3. Controller");
            Console.WriteLine("4. Sentinel");
            string roleOption = Console.ReadLine();
            
        } else if (filterOption == "3") {

        } else if (filterOption == "4") {

        } else {
            Console.WriteLine("Invalid Option");
        }

    } else if (option == "3") {
        Console.WriteLine("SORT DATA");
        Console.WriteLine("1. Sort Names");
        Console.WriteLine("2. Sort Roles");
        Console.WriteLine("3. Sort Origin");
        string sortOption = Console.ReadLine();
        selectionSort(characters, sortOption);
    } else if (option == "4") {
 
    } else if (option == "5") {
    
    } else if (option == "6") {

    } else if (option == "7") {
        mainLoop = false;
        loginLoop = true;
        while (loginLoop) {
            login();
        }
    } else if (option == "8") {
        mainLoop = false;
    } else {
        Console.WriteLine("INVALID ANSWER\n");
    }
}

int linearSearch(List<Char> aList, string item) {
    for (int n = 0; n < aList.Count; n++) {
        if (aList[n].Name.ToLower() == item.ToLower()) {
            return n;
        }
    }
    return -1;
}

static void selectionSort(List<Char> aList, string type) {
    List<Char> sortedList = aList;
    int min;
    Char temp;
    for (int n = 0; n < aList.Count; n++) {
        min = n;
        for (int i = min; i < aList.Count; i++) {
                if (string.Compare(aList[min].Name, aList[i].Name, true) > 0) {
                    min = i;
                }
        }
        temp = aList[n];
        aList[n] = aList[min];
        aList[min] = temp;
    }
}


class Char {
	public string Name { get; set; }
	public string Role { get; set; }
	public string Origin { get; set; }

	public Char(string name, string role, string origin) {
		this.Name = name;
		this.Role = role;
		this.Origin = origin;
	}
}

class User {
	public string Username { get; set; }
	public string Password { get; set; }
	public List<Char> Favourites { get; set; }

	public User(string username, string password) {
		this.Username = username;
		this.Password = password;
		this.Favourites = new List<Char>();
	}
}
