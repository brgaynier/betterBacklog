public interface IList
{
    
    List<ITicket> Tickets { get; set; }
    List<ITechnician> Techs { get; set; }

    void AddResponse(string i, int t);
 //   void AddTech(ITechnician technician);
    void AssignedTickets(string i);
    void AssignTo(string i, int t);
    void DeleteTech(string t);
    void DeleteTicket(int t);
    void LoadTechnicianData();
    void LoadTicketData();
    void MarkResolved(string i, int t);
    void NewTech();
    void NewTicket();
    void SaveTechnicianData();
    void SaveTicketData();
    void ShowSelectedTicket(string i, int t);
    int TicketNumber(int count);
    void UpdateTechId(string t);
    void UpdateTechName(string t);
    string UpdateTicketEmail(int t);
    string UpdateTicketUserName(int t);
    void ViewTechs();
    void ViewUnassignedTickets();

}