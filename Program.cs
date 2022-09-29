// DATA MANAGEMENT - Jordan Antonio
// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-6-0
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable disable
Console.Clear();

string jsonString = 

// DATA
List<User> users = new List<User>();
users.Add()

List<Char> valChars = new List<Char>();
valChars.Add(new Char("1", "2", "4"));
valChars.Add(new Char("1s", "2s", "4fsd"));
valChars.Add(new Char("1d", "2sda", "4f"));

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
        string json = JsonSerializer.Serialize(users);
        File.WriteAllText("path.json", json);
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

    } else if (option == "2") {
        Console.WriteLine("FILTER DATA");
        Console.WriteLine("1. Filter by Name");
        Console.WriteLine("2. Filter by Artist");
        Console.WriteLine("3. Filter by Genre");
        Console.WriteLine("4. Back");
        string filterOption = Console.ReadLine();

    } else if (option == "3") {
 
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

class Char {
	public string Name { get; set; }
	public string Role { get; set; }
	public string Genre { get; set; }

	public Char(string name, string role, string genre) {
		this.Name = name;
		this.Role = role;
		this.Genre = genre;
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
