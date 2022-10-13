// DATA MANAGEMENT - Jordan Antonio

using System.Text.Json;
#nullable disable
Console.Clear();

// DATA
string accountsFile = $"json/accounts.json";
string dataFile = $"json/agents.json";

string accountsString = File.ReadAllText(accountsFile);
string dataString = File.ReadAllText(dataFile);

List<User> users = JsonSerializer.Deserialize<List<User>>(accountsString)!;
List<Char> characters = JsonSerializer.Deserialize<List<Char>>(dataString)!;

bool loginLoop = true;
bool mainLoop = false;
int currentUserIndex = 0;

while (loginLoop) {
    login();
}

// DATA MANAGEMENT PAGE
while (mainLoop) {
    Console.WriteLine("\nMAIN MENU\n1. Display All Data\n2. Display Filtered Data\n3. Sort Data\n4. Add New Favourites\n5. Remove Favourites\n6. Display Favourites\n7. Logout\n8. Exit\n");
    string option = Console.ReadLine();

    // DISPLAY ALL DATA
    if (option == "1") {
        for (int n = 0; n < characters.Count; n++) {
            Console.WriteLine(characters[n].getAllData());
        }
    // FILTER DATA
    } else if (option == "2") {
        Console.WriteLine("\nFILTER DATA\n1. Search a Name\n2. Filter by Role\n3. Filter by Origin\n4. Back\n");
        string filterOption = Console.ReadLine();
        
        // Filter Selection
        if (filterOption == "1") {
            Console.Write("Please Enter a Name: ");
            string searchFilter = Console.ReadLine();
            linearSearchPrint(characters, searchFilter, "Name");
        } else if (filterOption == "2") {
            Console.Write("Please Enter a Role: ");
            string searchFilter = Console.ReadLine();
            linearSearchPrint(characters, searchFilter, "Role");
        } else if (filterOption == "3") {
            Console.Write("Please Enter a Origin: ");
            string searchFilter = Console.ReadLine();
            linearSearchPrint(characters, searchFilter, "Origin");
        } else if (filterOption == "4") {
        } else {
            Console.WriteLine("Invalid Option");
        }
    // SORT DATA
    } else if (option == "3") {
        Console.WriteLine("\nSORT DATA\n1. Sort Names\n2. Sort Roles\n3. Sort Origin\n4. Back\n");
        Console.Write("Select an Option (1-4): ");
        string sortOption = Console.ReadLine();

        if (sortOption == "1") {
            selectionSort(characters, "Name");
            Console.WriteLine("\nSorted Data by Name\n");
        } else if (sortOption == "2") {
            selectionSort(characters, "Role");
            Console.WriteLine("\nSorted Data by Role\n");
        } else if (sortOption == "3") {
            selectionSort(characters, "Origin");
            Console.WriteLine("\nSorted Data by Origin\n");
        } else if (sortOption == "4"){
        } else {
            Console.WriteLine("Invalid Option");
        }
    // FAVOURITE DATA
    } else if (option == "4") {
        Console.WriteLine("Please enter the name of the character you would like to favourite");
        string enteredName = Console.ReadLine();
        int nameIndex = linearSearch(characters, enteredName);
        if (nameIndex == -1) {
            Console.WriteLine("Name not Found");
        } else {
            int indexFavourite = linearSearch(users[currentUserIndex].Favourites, enteredName);
            if (indexFavourite == -1) {
                users[currentUserIndex].Favourites.Add(characters[nameIndex]);
                Console.WriteLine($"{characters[nameIndex].Name} has been added to favourites");
                // Save all account data
                string json = JsonSerializer.Serialize(users);
                File.WriteAllText(accountsFile, json);    
            } else {
                Console.WriteLine($"{characters[nameIndex].Name} is already favourited");
            }
        }
    // UNFAVOURITE DATA
    } else if (option == "5") {
        Console.WriteLine("Please enter the name of the character you would like to remove from favourites");
        string enteredName = Console.ReadLine();
        int nameIndex = linearSearch(users[currentUserIndex].Favourites, enteredName);
        if (nameIndex == -1) {
            Console.WriteLine("Name is not favourited");
        } else {
            users[currentUserIndex].Favourites.RemoveAt(nameIndex);
            Console.WriteLine($"{characters[nameIndex].Name} has been successfully unfavourited");
            // Save all account data
            string json = JsonSerializer.Serialize(users);
            File.WriteAllText(accountsFile, json);            
        }
    // DISPLAY FAVOURITE DATA
    } else if (option == "6") {
        for (int n = 0; n < users[currentUserIndex].Favourites.Count; n++) {
            Console.WriteLine(users[currentUserIndex].Favourites[n].getAllData());
        }
    // LOGOUT
    } else if (option == "7") {
        mainLoop = false;
        loginLoop = true;
        while (loginLoop) {
            login();
        }
    // EXIT
    } else if (option == "8") {
        Console.WriteLine("Goodbye!");
        mainLoop = false;
    } else {
        Console.WriteLine("INVALID OPTION\n");
    }
}

// FUNCTIONS

// LOGIN PAGE FUNCTION - (USE FUNCTION TO RETURN TO PAGE AFTER SELECTING LOGOUT)
void login() {
    Console.WriteLine("WELCOME\n1. Login\n2. Create New Account\n3. Exit\n");
    string accountOption = Console.ReadLine();
    // LOGIN
    if (accountOption == "1") {
        Console.WriteLine("LOGIN");
        Console.Write("Enter Username: ");
        string enteredUsername = Console.ReadLine();
        Console.Write("Enter Password: ");
        string enteredPassword = Console.ReadLine();
        for (int n = 0; n < users.Count; n++) {
            if (users[n].Username == enteredUsername && users[n].Password == enteredPassword) {
                Console.WriteLine("\nSuccessfully Logged in");
                currentUserIndex = n;
                loginLoop = false;
                mainLoop = true;
                return;
            }
        }
        Console.WriteLine("\nInvalid Login Credentials\n");
    // CREATE ACCOUNT
    } else if (accountOption == "2") {
        Console.WriteLine("CREATE ACCOUNT");
        Console.Write("Enter Username: ");
        string newUsername = Console.ReadLine();
        for (int i = 0; i < users.Count; i++) {
            if (users[i].Username == newUsername) {
                Console.WriteLine("Username is already taken");
                return;
            }
        }
        Console.Write("\nEnter Password: ");
        string newPassword = Console.ReadLine();
        users.Add(new User(newUsername, newPassword));
        Console.WriteLine("Account Successfully Created");
        // Save all account data
        string json = JsonSerializer.Serialize(users);
        File.WriteAllText(accountsFile, json);
    // EXIT
    } else if (accountOption == "3") {
        Console.WriteLine("Goodbye!");
        loginLoop = false;
    } else {
        Console.WriteLine("INVALID OPTION\n");
    }
}

// Search through a list and print out all data in the list that matches the entered item
static void linearSearchPrint(List<Char> aList, string item, string type) {
    int i = 0;
    for (int n = 0; n < aList.Count; n++) {
        if (type == "Name") {
            if (aList[n].Name.ToLower() == item.ToLower()) {
                Console.WriteLine(aList[n].getAllData());
                i++;
            }
        } else if (type == "Role") {
            if (aList[n].Role.ToLower() == item.ToLower()) {
                Console.WriteLine(aList[n].getAllData());
                i++;
            }
        } else if (type == "Origin") {
            if (aList[n].Origin.ToLower() == item.ToLower()) {
                Console.WriteLine(aList[n].getAllData());
                i++;
            }
        }
    }
    if (i == 0) {
        Console.WriteLine("\nEntered Item Not Found");
    }
}

// Search through a list for an item and return index of item
int linearSearch(List<Char> aList, string item) {
    for (int n = 0; n < aList.Count; n++) {
        if (aList[n].Name.ToLower() == item.ToLower()) {
            return n;
        }        
    }
    return -1;
}

// Sort a list by a property of the Char Class
static void selectionSort(List<Char> aList, string type) {
    List<Char> sortedList = aList;
    int min;
    Char temp;
    for (int n = 0; n < aList.Count; n++) {
        min = n;
        for (int i = min; i < aList.Count; i++) {
            if (type == "Name") {
                    if (string.Compare(aList[min].Name, aList[i].Name, true) > 0) {
                    min = i;
                }
            } else if (type == "Role") {
                    if (string.Compare(aList[min].Role, aList[i].Role, true) > 0) {
                    min = i;
                }
            } else if (type == "Origin") {
                    if (string.Compare(aList[min].Origin, aList[i].Origin, true) > 0) {
                    min = i;
                }
            }

        }
        temp = aList[n];
        aList[n] = aList[min];
        aList[min] = temp;
    }
}

// CLASSES
class Char {
	public string Name { get; set; }
	public string Role { get; set; }
	public string Origin { get; set; }

    public string getAllData() {
        return $"Name: {Name} | Role: {Role} | Origin: {Origin}";
    }
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
