
public class Menu : IMenu
{

    public void MainMenu()
    {
        Console.WriteLine("Main menu");
        Console.WriteLine(" ");
        Console.WriteLine("Who is using this system?");
        Console.WriteLine("1. User");
        Console.WriteLine("2. Technician");
        Console.WriteLine("3. Exit");
        Console.WriteLine(" ");
    }

    public void UserMenu()
    {
        Console.Clear();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Create a ticket");
        Console.WriteLine("2. View open tickets");
        Console.WriteLine("3. View resolved tickets");
        Console.WriteLine("4. Settings");
        Console.WriteLine("5. Main menu");
        Console.WriteLine(" ");
    }

    public void TechMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Select a technician");
        Console.WriteLine("2. View un-assigned open tickets");
        Console.WriteLine("3. Add new technician");
        Console.WriteLine("4. Settings");
        Console.WriteLine("5. Main menu");
        Console.WriteLine(" ");
    }


    public void TicketMenu()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Add a response ");
        Console.WriteLine("2. Mark ticket resolved");
        Console.WriteLine("3. Reassign ticket to a technician");
        Console.WriteLine("4. Main menu");
        
        Console.WriteLine(" ");
    }

    public void TicketSettings()
    {
        Console.WriteLine("");
        System.Console.WriteLine("1. Update UserName");
        System.Console.WriteLine("2. Update Email");
        System.Console.WriteLine("3. Delete Ticket");
        System.Console.WriteLine("4. Return");
    }

    public void SettingsMenu()
    {
        Console.WriteLine("");
        System.Console.WriteLine("1. Update Technican Name");
        System.Console.WriteLine("2. Update Technican ID");
        System.Console.WriteLine("3. Delete Technician");
        System.Console.WriteLine("4. Return");
    }


}