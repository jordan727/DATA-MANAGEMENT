// DATA MANAGEMENT - Jordan Antonio
#nullable disable
Console.Clear();

// DATA


// bool loginLoop = true;
// while (loginLoop) {
//     Console.WriteLine("LOGIN");
//     Console.WriteLine();
// }

bool mainLoop = true;

// Welcome
while (mainLoop) {
    Console.WriteLine("MAIN MENU");
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
        
    } else if (option == "8") {
        mainLoop = false;
    } else {
        Console.WriteLine("INVALID ANSWER\n");
    }
}

List<User> users = new List<User>();
users.Add(new User("John", "fsd"));

List<Char> valChars = new List<Char>();
valChars.Add(new Char("1", "2", "4"));
valChars.Add(new Char("1s", "2s", "4fsd"));
valChars.Add(new Char("1d", "2sda", "4f"));

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
