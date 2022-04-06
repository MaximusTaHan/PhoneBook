using Microsoft.EntityFrameworkCore;
using PhoneBook;

internal class PhoneBookController
{
    internal static List<Contact> GetContacts()
    {
        var context = new PhoneBookContext();
        var allContacts = context.PhoneBook.ToList();

        return allContacts;
    }

    internal static void CreateContact(Contact newContact)
    {
        using (var context = new PhoneBookContext())
        {
            context.PhoneBook.Add(newContact);
            context.SaveChanges();
        }
    }

    internal static void UpdateContact(string newName, string newNumber, Contact foundContact)
    {
        using (var context = new PhoneBookContext())
        {
            var contact = context.PhoneBook.First(c => c.Name == foundContact.Name);
            contact.Name = newName;
            contact.PhoneNumber = newNumber;
            context.SaveChanges();
        }
    }

    internal static void DeleteContact(Contact foundContact)
    {
        using(var context = new PhoneBookContext())
        {
            var contact = context.PhoneBook.First(c => c.Name == foundContact.Name);
            context.PhoneBook.Remove(contact);

            context.SaveChanges();
        }
    }
}