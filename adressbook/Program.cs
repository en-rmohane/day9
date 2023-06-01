using System;
using System.Collections.Generic;

class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}

class AddressBook
{
    private List<Contact> contacts;

    public AddressBook()
    {
        contacts = new List<Contact>();
    }

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public Contact SearchContact(string name)
    {
        return contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public bool UpdateContact(string name, string phoneNumber, string address)
    {
        Contact contact = SearchContact(name);
        if (contact != null)
        {
            contact.PhoneNumber = phoneNumber;
            contact.Address = address;
            return true;
        }
        return false;
    }

    public bool DeleteContact(string name)
    {
        Contact contact = SearchContact(name);
        if (contact != null)
        {
            contacts.Remove(contact);
            return true;
        }
        return false;
    }
}

class Program
{
    static void Main()
    {
        AddressBook addressBook = new AddressBook();

        while (true)
        {
            Console.WriteLine("\n----- Address Book Menu -----");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Search Contact");
            Console.WriteLine("3. Update Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Quit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter phone number: ");
                    string phoneNumber = Console.ReadLine();
                    Console.Write("Enter address: ");
                    string address = Console.ReadLine();
                    Contact contact = new Contact
                    {
                        Name = name,
                        PhoneNumber = phoneNumber,
                        Address = address
                    };
                    addressBook.AddContact(contact);
                    Console.WriteLine("Contact added.");
                    break;

                case "2":
                    Console.Write("Enter name to search: ");
                    string searchName = Console.ReadLine();
                    Contact foundContact = addressBook.SearchContact(searchName);
                    if (foundContact != null)
                    {
                        Console.WriteLine("Name: " + foundContact.Name);
                        Console.WriteLine("Phone Number: " + foundContact.PhoneNumber);
                        Console.WriteLine("Address: " + foundContact.Address);
                    }
                    else
                    {
                        Console.WriteLine("Contact not found.");
                    }
                    break;

                case "3":
                    Console.Write("Enter name to update: ");
                    string updateName = Console.ReadLine();
                    Contact contactToUpdate = addressBook.SearchContact(updateName);
                    if (contactToUpdate != null)
                    {
                        Console.Write("Enter new phone number: ");
                        string newPhoneNumber = Console.ReadLine();
                        Console.Write("Enter new address: ");
                        string newAddress = Console.ReadLine();
                        if (addressBook.UpdateContact(updateName, newPhoneNumber, newAddress))
                        {
                            Console.WriteLine("Contact updated.");
                        }
                        else
                        {
                            Console.WriteLine("Contact not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Contact not found.");
                    }
                    break;

                case "4":
                    Console.Write("Enter name to delete: ");
                    string deleteName = Console.ReadLine();
                    if (addressBook.DeleteContact(deleteName))
                    {
                        Console.WriteLine("Contact deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Contact not found.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Quitting the program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
