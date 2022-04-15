using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Ticket : ITicket
{

    [JsonProperty]
    public string UserName { get; private set; }
    public string email { get; set; }
    
    public string issue { get; set; }

    public string priority { get; set; }

    public int ticketNumber { get; set; }  

    public string remarks { get; set; }

    public string AssignedTechnicianId { get; set; }

    public string TicketStatus { get; set; } = "";
   // public int TicketStatus { get; set; }   // 0 = unassigned, 1 = assigned, 2 = resolved

    public string AssignedTechnicianName { get; set; }
    public Ticket(){}



    public void ShowDetails()
    {
        Console.WriteLine("Ticket Number: {0}", ticketNumber);
        Console.WriteLine("Name: {0}", UserName);
        Console.WriteLine("Email: {0}", email);
        Console.WriteLine("Issue: {0}", issue);
        Console.WriteLine("Priority: {0}", priority);
        Console.WriteLine("Remarks: {0}", remarks);
        Console.WriteLine("Assigned to: {0}", AssignedTechnicianName);
        Console.WriteLine(" ");
    }

    public void UpdateUserName(string name)
    {
        UserName = name;
    }


   public void ViewTickets(IList _list)
    {
        Console.Clear();
        System.Console.WriteLine("Viewing open tickets");

        Console.WriteLine("");

        foreach (ITicket _ticket in _list.Tickets)
        {
            if (_ticket.TicketStatus != "resolved")
            {
                _ticket.ShowDetails();
            }
        }
    }


    public void ViewResolvedTickets(IList _list)
    {
        Console.Clear();
        System.Console.WriteLine("Viewing resolved tickets");
        System.Console.WriteLine("");

        foreach (ITicket _ticket in _list.Tickets)
        {
            if (_ticket.TicketStatus == "resolved")
            {
                _ticket.ShowDetails();
            }
        }
    }

  

}