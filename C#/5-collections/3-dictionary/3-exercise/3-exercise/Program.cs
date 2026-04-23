
string inputOption, contactName, contactPhoneNumber, inputSearch, contactToDelete, contactToEdit, optionEdit;
Dictionary <string, string> contacts = new Dictionary<string, string>();

do
{
    Console.WriteLine("\n=== MENU ===" +
                      "\n1. Add contact." +
                      "\n2. Show all contacts." +
                      "\n3. Search contact." +
                      "\n4. Edit contact." +
                      "\n5. Delete contact. " +
                      "\n6. Exit. ");
    Console.Write("Enter an option: ");
    inputOption = Console.ReadLine().Trim();

    switch (inputOption)
    {
        case "1":
            Console.Write("Enter the name: ");
            contactName = Console.ReadLine().Trim().ToUpper();
            if (string.IsNullOrEmpty(contactName)) { Console.WriteLine("*** Name can not be empty ***"); break; }
            else if (contacts.ContainsKey(contactName)) { Console.WriteLine("*** This contact name already exists ***"); break; }

            Console.Write("Enter the phone number: ");
            contactPhoneNumber = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(contactPhoneNumber) || contactPhoneNumber.Length != 10) { Console.WriteLine("*** Phone number can't be empty and must have ten digits ***"); break; }

            contacts.Add(contactName, contactPhoneNumber);

            Console.WriteLine("--- Contact was added successfully ---");
            break;

        case "2":
            if (contacts.Count == 0) { Console.WriteLine("-- You don't have any contact --"); break; }

            Console.WriteLine(new string('-', 39));
            Console.WriteLine("| {0, -20} | {1, -12} |", "Full Name", "Phone Number");
            Console.WriteLine(new string('-', 39));

            foreach (var contact in contacts)
            {
                Console.WriteLine("| {0, -20} | {1, -12} |", contact.Key, contact.Value);
                Console.WriteLine(new string('-', 39));
            }
            break;

        case "3":
            Console.Write("Enter the name or phone number: ");
            inputSearch = Console.ReadLine().Trim().ToUpper();
            if (string.IsNullOrEmpty (inputSearch)) { Console.WriteLine("*** Please type a valid data ***"); break; };
            bool flag = false;

            foreach (var contact in contacts)
            {
                if (contact.Key == inputSearch || contact.Value == inputSearch) {
                    Console.WriteLine(new string('-', 39));
                    Console.WriteLine("| {0, -20} | {1, -12} |", "Full Name", "Phone Number");
                    Console.WriteLine(new string('-', 39));
                    Console.WriteLine("| {0, -20} | {1, -12} |", contact.Key, contact.Value);
                    Console.WriteLine(new string('-', 39));
                    flag = true;
                }
            }

            if (!flag) { Console.WriteLine($"-- There is no contact with this name {inputSearch} or phone number --"); break; }
            break;

        case "4":
            Console.Write("Enter contact name: ");
            contactToEdit = Console.ReadLine().Trim().ToUpper();
            if (string.IsNullOrEmpty(contactToEdit)) { Console.WriteLine("*** The name can not be empty ***"); break; }

            if (!contacts.ContainsKey(contactToEdit)) { Console.WriteLine($"-- There is no contact with this name {contactToEdit} --"); break; }

            Console.WriteLine(new string('-', 39));
            Console.WriteLine("| {0, -20} | {1, -12} |", "Full Name", "Phone Number");
            Console.WriteLine(new string('-', 39));
            Console.WriteLine("| {0, -20} | {1, -12} |", contactToEdit, contacts[contactToEdit]);
            Console.WriteLine(new string('-', 39));

            Console.Write("what do you want to edit? (name - phone number): ");
            optionEdit = Console.ReadLine().Trim().ToUpper();

            switch (optionEdit)
            {
                case "NAME":
                    Console.Write("Enter the new name: ");
                    contactName = Console.ReadLine().Trim().ToUpper();
                    if (string.IsNullOrEmpty(contactName)) { Console.WriteLine("*** The name can't be empty ***"); break; }

                    string copyPhoneNumber = contacts[contactToEdit];
                    contacts.Remove(contactToEdit);
                    contacts.Add(contactName, copyPhoneNumber);
                    Console.WriteLine("--- Contact updated ---");
                    break;

                case "PHONE NUMBER" or "PHONENUMBER":
                    Console.Write("Enter the new phone number: ");
                    contactPhoneNumber = Console.ReadLine().Trim().ToUpper();
                    if (string.IsNullOrEmpty(contactPhoneNumber) || contactPhoneNumber.Length != 10) { Console.WriteLine("*** The phone number can't be empty and must have 10 digits ***"); break; }

                    contacts[contactToEdit] = contactPhoneNumber;
                    Console.WriteLine("--- Contact updated ---");
                    break;

                default: Console.WriteLine("*** Invalid option ***"); break;
            }
            break;

        case "5":
            Console.Write("Enter the contact name: ");
            contactToDelete = Console.ReadLine().Trim().ToUpper();
            if (string.IsNullOrEmpty(contactToDelete)) { Console.WriteLine("*** The name can not be empty ***"); break; }

            if (!contacts.ContainsKey(contactToDelete)) { Console.WriteLine($"-- There is no contact with this name {contactToDelete} --"); break; }

            contacts.Remove(contactToDelete);
            Console.WriteLine("-- Contact deleted successfully");
            break;

        case "6": Console.WriteLine("Exiting... "); break;

        case "cls" or "clear": Console.Clear(); break;

        default: Console.WriteLine("*** Invalid option ***"); break;
    }
} while (inputOption != "6");

Console.ReadKey();

// Miss add validation to phone number (only numbers)
