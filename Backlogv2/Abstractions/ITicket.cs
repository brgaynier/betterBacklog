
public interface ITicket
{
    string UserName { get; } 
    string AssignedTechnicianId { get; set; }
    string TicketStatus { get; set; } 
   // int TicketStatus { get; set; }
    string email { get; set;}
    string issue { get; set;}
    string priority { get; set;}
    int ticketNumber { get; set;}
    public string remarks { get; set; } 
    public string AssignedTechnicianName { get; set; }
    void ShowDetails();
    void UpdateUserName(string name);

   void ViewTickets(IList list);
   void ViewResolvedTickets(IList list);

    

}