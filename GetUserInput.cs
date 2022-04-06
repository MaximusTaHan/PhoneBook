using PhoneBook;

internal class GetUserInput
{
    internal void MainMenu()
    {
        bool closeApp = false;

        while(closeApp == false)
        {
            Console.WriteLine("\n\nWelcome to your Phone Book\n\n");
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("Type 0 to Close Application.");
            Console.WriteLine("Type 1 to View all Contacts.");
            Console.WriteLine("Type 2 to Create new Contact.");
            Console.WriteLine("Type 3 to Delete a Contact.");
            Console.WriteLine("Type 4 to Update a Contact.");

            string commandInput = Console.ReadLine();

            while(string.IsNullOrEmpty(commandInput))
            {
                Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                commandInput = Console.ReadLine();
            }

            switch(commandInput)
            {
                case "0":
                    closeApp = true;
                    Environment.Exit(0);
                    break;
                case "1":
                    ProcessGet();
                    break;
                case "2":
                    ProcessCreate();
                    break;
                case "3":
                    ProcessDelete();
                    break;
                case "4":
                    ProcessUpdate();
                    break;
            }
        }
    }

    private void ProcessDelete()
    {
        var allContacts = ProcessGet();
        bool found = false;
        var foundContact = new Contact();

        //segment is very similar to ProcessUpdate could probably make a helper method
        Console.WriteLine("\nWhich Contact would you like to Delete? (Or press 0 to return to Main Menu).");
        string input = Console.ReadLine();
        if (input == "0")
            MainMenu();

        foreach (Contact contact in allContacts)
        {
            if (input == contact.Name)
            {
                found = true;
                foundContact = contact;
            }
        }
        if (!found)
        {
            Console.WriteLine("\nNo such Contact exists.\nPress any key to try again (Or press 0 to return to Main Menu).");
            string option = Console.ReadLine();

            if (option == "0")
            {
                MainMenu();
            }
            else
            {
                ProcessDelete();
            }
        }

        PhoneBookController.DeleteContact(foundContact);
    }

    private void ProcessUpdate()
    {
        var allContacts = ProcessGet();
        bool found = false;
        var foundContact = new Contact();

        Console.WriteLine("\nWhich Contact would you like to Update? (Or press 0 to return to Main Menu).");
        string input = Console.ReadLine();
        if (input == "0")
            MainMenu();

        foreach(Contact contact in allContacts)
        {
            if(input == contact.Name)
            {
                found = true;
                foundContact = contact;
            }
        }

        if(!found)
        {
            Console.WriteLine("\nNo such Contact exists.\nPress any key to try again (Or press 0 to return to Main Menu).");
            string option = Console.ReadLine();

            if(option == "0")
            {
                MainMenu();
            }
            else
            {
                ProcessUpdate();
            }
        }

        UpdateMenu(foundContact);
    }

    private void UpdateMenu(Contact foundContact)
    {
        Console.WriteLine("\nPress 1 to update Name.\nPress 2 to update Number.\nPress 3 to update Both.\nPress 0 to return to Main Menu (Or any key to return to Update)");
        string input = Console.ReadLine();
        string newName = foundContact.Name;
        string newNumber = foundContact.PhoneNumber;

        switch (input)
        {
            case "0":
                MainMenu();
                break;
            case "1":
                newName = GetName();
                PhoneBookController.UpdateContact(newName, newNumber, foundContact);
                break;
            case "2":
                newNumber = GetNumber();
                PhoneBookController.UpdateContact(newName, newNumber, foundContact);
                break;
            case "3":
                newName = GetName();
                newNumber = GetNumber();
                PhoneBookController.UpdateContact(newName, newNumber, foundContact);
                break;
            default:
                ProcessUpdate();
                break;
        }
    }

    private void ProcessCreate()
    {
        var newContact = new Contact()
        {
            Name = GetName(),
            PhoneNumber = GetNumber()
        };

        PhoneBookController.CreateContact(newContact);
    }

    private string GetNumber()
    {
        string newNumber;
        Console.WriteLine("Enter a Number for the new Contact:");
        Console.Write("Number: ");
        newNumber = Console.ReadLine();

        Console.WriteLine($"You chose: {newNumber}. \nPress 1 to confirm.\nPress any key to Write a new Number (press 0 to return to Main Menu)");

        string check = Console.ReadLine();

        if (check == "1")
            return newNumber;

        else if (check == "0")
            MainMenu();

        else
            GetNumber();

        return newNumber;
    }

    private string GetName()
    {
        string newName;
        Console.WriteLine("Enter a Name for the Contact:");
        Console.Write("Name: ");
        newName = Console.ReadLine();

        Console.WriteLine($"You chose: {newName}. \nPress 1 to confirm.\nPress any key to Write a new Name (press 0 to return to Main Menu)");

        string check = Console.ReadLine();

        if (check == "1")
            return newName;

        else if (check == "0")
            MainMenu();

        else
            GetName();

        return newName;
    }

    private List<Contact> ProcessGet()
    {
        var allContacts = PhoneBookController.GetContacts();

        ContactVisualizer.ShowContacts(allContacts);

        return allContacts;
    }
}