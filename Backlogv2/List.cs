using Newtonsoft.Json;
using Newtonsoft.Json.Linq; 



public class List : IList
{
    public List<ITicket> Tickets { get; set; } = new List<ITicket>();
    public List<ITechnician> Techs { get; set; } = new List<ITechnician>();

    ITicket _ticket;
    ITechnician _technician;



    public void AddResponse(string i, int t)
    {
        var item = Tickets.SingleOrDefault(x => x.ticketNumber == t);
        if (item.AssignedTechnicianId == i)
            System.Console.WriteLine("Add a comment:");
        item.remarks = Console.ReadLine();


        System.Console.WriteLine("Comment added");
        Console.ReadLine();
    }
    public void AssignedTickets(string i)
    {
        Console.Clear();
        System.Console.WriteLine("Assigned tickets");
        System.Console.WriteLine("");
        int count = 0;
        string techSelect = i;

        foreach (ITicket _ticket in Tickets)
        {
            if (_ticket.AssignedTechnicianId == i && _ticket.TicketStatus != "resolved")
            {
                _ticket.ShowDetails();
                count++;
            }
        }

        if (count > 0)
        {
            System.Console.WriteLine("Select ticket number you wish to address:");
            int ticketSelect = Convert.ToInt32(Console.ReadLine());

            ShowSelectedTicket(techSelect, ticketSelect);

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add a response ");
            Console.WriteLine("2. Mark ticket resolved");
            Console.WriteLine("3. Reassign ticket to a technician");
            Console.WriteLine("4. Main menu");

            Console.WriteLine(" ");
            string selection = Console.ReadLine();

            if (selection == "1") // add a response
            {
                AddResponse(techSelect, ticketSelect);

            }

            else if (selection == "2") // mark ticket resolved
            {
                MarkResolved(techSelect, ticketSelect);
                Console.ReadLine();
            }

            else if (selection == "3") // reassign ticket
            {
                ViewTechs();
                string reassign = Console.ReadLine();
                AssignTo(reassign, ticketSelect);
                System.Console.WriteLine("Ticket has been reassigned.");
                Console.ReadLine();
            }

            else // main menu
            {
                return;     // Run();
            }
        }
        else
        {
            System.Console.WriteLine("You have no assigned tickets at this time");
            Console.ReadLine();
        }
    }

     public void AssignTo(string i, int t)
    {
        int count = 0;
        foreach (ITicket _ticket in Tickets)
        {
            if (_ticket.ticketNumber == t)
            {               
                foreach (ITechnician _technician in Techs)
                {                   
                    if (_technician.TechnicianId == i)
                    {
                        _ticket.AssignedTechnicianId = i;
                        _ticket.TicketStatus = "assigned";
                        _ticket.AssignedTechnicianName = _technician.TechnicianName;
                        count++;
                    }
                }
                if (count == 0)
                {
                    System.Console.WriteLine("Invalid ID number");
                }
            }
        }

    }


    public void DeleteTech(string t)  
    {
        System.Console.WriteLine("Are you sure you want to delete this technician?");
        System.Console.WriteLine("1. Yes");
        System.Console.WriteLine("2. No");
        string doubleCheck = Console.ReadLine();
        if (doubleCheck == "yes" || doubleCheck == "1")
        {        
            var item = Techs.SingleOrDefault(x => x.TechnicianId == t);
            foreach (ITicket _ticket in Tickets)
            {
                if (_ticket.AssignedTechnicianId == t && _ticket.TicketStatus != "resolved")
                {
                    _ticket.TicketStatus = "unassigned";
                    _ticket.AssignedTechnicianName ="";
                }
            }
            Techs.Remove(item);
            System.Console.WriteLine("Technician has been deleted.");
            Console.ReadLine();
        }
    }

    public void DeleteTicket(int t)
    {
        System.Console.WriteLine("Are you sure you want to delete this ticket?");
        System.Console.WriteLine("1. Yes");
        System.Console.WriteLine("2. No");
        string doubleCheck = Console.ReadLine();
        if (doubleCheck == "yes" || doubleCheck == "1")
        {                                             
            var item = Tickets.SingleOrDefault(x => x.ticketNumber == t);
            Tickets.Remove(item);
            System.Console.WriteLine("Ticket has been deleted.");
            Console.ReadLine();
        }
    }

    public void MarkResolved(string i, int t)
    {
        var item = Tickets.SingleOrDefault(x => x.ticketNumber == t);
        if (item.AssignedTechnicianId == i)
            System.Console.WriteLine("Ticket has been resolved.");
        item.TicketStatus = "resolved";

        Console.ReadLine();
    }

    public void NewTech()
    {
        _technician = Factory.CreateTechnician();
        System.Console.WriteLine("Create new technician.");
        System.Console.WriteLine("");
        System.Console.WriteLine("Enter technician name:");
        _technician.TechName(Console.ReadLine());
        System.Console.WriteLine("");
        System.Console.WriteLine("Assigned technician ID:");
        Random random = new Random();
        int num = random.Next(10000);
        _technician.TechId(Convert.ToString(num)); 
        System.Console.WriteLine(_technician.TechnicianId);


        Techs.Add(_technician);
        Console.ReadLine();
    }
    
    public void NewTicket()
    {
        Console.Clear();
        _ticket = Factory.CreateTicket();
        Console.WriteLine("Enter name");
        _ticket.UpdateUserName(Console.ReadLine());
        Console.WriteLine("Enter email");
        _ticket.email= Console.ReadLine();
        Console.WriteLine("What is your issue:");
        _ticket.issue= Console.ReadLine();
        Console.WriteLine("On a scale of 1 to 5, how urgent?");
        _ticket.priority= Console.ReadLine();

        int num = TicketNumber(1);
        _ticket.ticketNumber= num;
        _ticket.TicketStatus = "unassigned";

        Tickets.Add(_ticket);
        System.Console.WriteLine("Ticket created.");
        Console.ReadLine();
    }

    public void ViewTechs()
    {
        foreach (ITechnician _technician in Techs)
        {
            Console.WriteLine("Technician name: {0} ", _technician.TechnicianName);
            Console.WriteLine("ID number: {0} ", _technician.TechnicianId);
            System.Console.WriteLine("");
        }

        System.Console.WriteLine("Select a technician (by ID number):");
    }

    public void ViewUnassignedTickets()
       {
        Console.Clear();
        int count = 0;

        foreach (ITicket _ticket in Tickets)
        {
            if (_ticket.TicketStatus == "unassigned")
            {
                _ticket.ShowDetails();
                count++;
            }
        }
        if (count > 0)
        {
            System.Console.WriteLine("Would you like to assign a ticket?"); 
            string selection = Console.ReadLine();
            if (selection == "yes" || selection == "Yes" || selection == "1")
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("Select a ticket to assign:");
                int ticketSelect = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("");
                ViewTechs();
                string techSelect = Console.ReadLine();
                AssignTo(techSelect, ticketSelect);
                Console.ReadLine();
            }
        }
        else
        {
            System.Console.WriteLine("There are no unassigned tickets at this time. ");
            Console.ReadLine();
        }
    }


    public void ShowSelectedTicket(string i, int t)
    {
        Console.Clear();

        var item = Tickets.SingleOrDefault(x => x.ticketNumber == t);
        if (item.AssignedTechnicianId == i)
            item.ShowDetails();
    }


    public int TicketNumber(int count)
    {
        foreach (ITicket _ticket in Tickets)
        {
            if (_ticket.ticketNumber == count)
            {
                count++;
            }
        }

        int num = count;
        return num;
    }

    public void UpdateTechName(string t)
    {
        string name = "";
        foreach (ITechnician _technician in Techs)
        {
            if (_technician.TechnicianId == t)
            {
                System.Console.WriteLine("Enter new name");
                _technician.TechName(Console.ReadLine());

                name = _technician.TechnicianName;
                foreach (ITicket _ticket in Tickets)
                {
                    if (_ticket.AssignedTechnicianId == t)
                    {
                        _ticket.AssignedTechnicianName = name;
                    }
                }
                Console.ReadLine();                
            }
        }       

    }

    public void UpdateTechId(string t)
    {
       foreach ( ITechnician _technician in Techs)
       {
           if (_technician.TechnicianId == t)
           {
                System.Console.WriteLine("Enter new ID");
                _technician.TechId(Console.ReadLine());

                string newId = _technician.TechnicianId;

                foreach (ITicket _ticket in Tickets)
                {
                    if (_ticket.AssignedTechnicianId == t)
                    {
                        _ticket.AssignedTechnicianId = newId;
                    }
                }
           }
            Console.ReadLine();
       }
    }

    public string UpdateTicketUserName(int t)
    {

        var item = Tickets.SingleOrDefault(x => x.ticketNumber == t);
        System.Console.WriteLine("Enter new name");
        
        item.UpdateUserName(Console.ReadLine());

        string name = item.UserName;

        return name;
    }

    public string UpdateTicketEmail(int t)
    {

        var item = Tickets.SingleOrDefault(x => x.ticketNumber == t);
        System.Console.WriteLine("Enter new email");
        item.email = Console.ReadLine();

        string email = item.email;

        return email;
    }


    public void LoadTicketData()
    { 
        string filePath= "data.save";
        DataSerializer dataSerializer = new DataSerializer();
        List<Ticket>? loadedTickets = dataSerializer.JsonDeserialize(typeof(List<Ticket>), filePath) as List<Ticket>;        
        Tickets = new List<ITicket>();
        Tickets.AddRange(loadedTickets ?? new List<Ticket>());  
     }

    public void SaveTicketData()
    {
        string filePath= "data.save";
        DataSerializer dataSerializer = new DataSerializer();
        dataSerializer.JsonSerialize(Tickets, filePath);
        System.Console.WriteLine("Ticket data saved.");

    }    

     public void LoadTechnicianData()
    { 
        string filePath= "techData.save";
        DataSerializer dataSerializer = new DataSerializer();
        List<Technician>? loadedTechnicians = dataSerializer.JsonDeserialize(typeof(List<Technician>), filePath) as List<Technician>;        
        Techs = new List<ITechnician>();
        Techs.AddRange(loadedTechnicians ?? new List<Technician>());  

    }

    public void SaveTechnicianData()
    {
        string filePath= "techData.save";
        DataSerializer dataSerializer = new DataSerializer();
        if(Techs == null)
            Techs = new List<ITechnician>();
        dataSerializer.JsonSerialize(Techs, filePath);   
        
        System.Console.WriteLine("Technician data saved.");

    }
            // figure out which fields we can make private

}