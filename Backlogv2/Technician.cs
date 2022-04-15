using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class Technician : ITechnician
{
    [JsonProperty]
    public string TechnicianId { get; private set; }

    [JsonProperty]
    public string TechnicianName { get; private set; } 



    ITicket _ticket;
    IList _list;

    public Technician(){
        _list = new List();
        _ticket = new Ticket();
        TechnicianId = string.Empty;
        TechnicianName = string.Empty;
    }

    public void TechId(string Id)
    {
        TechnicianId = Id;
    }
    public void TechName(string name)
    {
        TechnicianName = name;
    }


     public void ViewTechs(IList _list)
    {
        foreach (ITechnician _technician in _list.Techs)
        {
            Console.WriteLine("Technician name: {0} ", _technician.TechnicianName);
            Console.WriteLine("ID number: {0} ", _technician.TechnicianId);
            System.Console.WriteLine("");
        }

        System.Console.WriteLine("Select a technician (by ID number):");
    }

}