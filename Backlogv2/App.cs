using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class App
{
    ITechnician _technician;
    ITicket _ticket;
    IMenu _menu;
    IList _list;


    public App (ITechnician technician, IMenu menu, ITicket ticket, IList list)
    {   
         _technician = technician;
         _ticket = ticket;
         _menu = menu;
         _list = list;
    }

    public void Run()
    {
        _list.LoadTicketData();
        _list.LoadTechnicianData();
        RunMainMenu();
    }
    public void RunMainMenu()
    {
        _menu.MainMenu();
        string selection = Console.ReadLine();

        if (selection == "1") // User
        {
            RunUser();
        }
            
        else if ( selection == "2") // Technician
        {
            RunTechnician();
        }

        else if (selection == "3") // Exit
        {
            _list.SaveTicketData();
            _list.SaveTechnicianData();

            System.Console.WriteLine("Good-bye!");
            }
            
            else
            {
                Console.WriteLine("Invalid selection");
                RunMainMenu();
            }
        }

    public void RunUser()
    {

        _menu.UserMenu();
        string selection = Console.ReadLine();

        if (selection == "1") // create ticket
        { 
             _list.NewTicket();                                                
            RunUser();
        }
        else if (selection == "2") // view open tickets
        {
            _ticket.ViewTickets(_list);
            Console.ReadLine();
            RunUser();
        }
        else if (selection == "3") // View resolved tickets
        {
            _ticket.ViewResolvedTickets(_list);
            Console.ReadLine();
            RunUser();
        }
        else if (selection == "4") //Settings
        {
             Console.Clear();
            _ticket.ViewTickets(_list);

            System.Console.WriteLine("");
            System.Console.WriteLine("Select a Ticket");
            int ticketSelect = Convert.ToInt32(Console.ReadLine());
            _menu.TicketSettings();

            string update = Console.ReadLine();
            if (update == "1")
            {
                _list.UpdateTicketUserName(ticketSelect);
            }

            else if (update == "2")
            {
                _list.UpdateTicketEmail(ticketSelect); 
            }   
            else if ( update == "3") 
            {
                _list.DeleteTicket(ticketSelect);
            }

            RunUser();
        }
        else //Main Menu
        {
            RunMainMenu();
        }
    }

    public void RunTechnician()
    {
        Console.Clear();
        if (_list.Techs.Count() == 0 )
        {                  
            _list.NewTech();
        }

        _menu.TechMenu();
        string selection = Console.ReadLine();

        if (selection == "1") // select technician
        {
            Console.Clear();
            _technician.ViewTechs(_list);

            string techSelect = Console.ReadLine(); 
            _list.AssignedTickets(techSelect);
            RunTechnician();

        }

        else if (selection == "2") //view unassigned
        {    
            _list.ViewUnassignedTickets();
            RunTechnician();
        }

        else if (selection == "3") //create new tech
        {       
            Console.Clear();    
            _list.NewTech();
            RunTechnician();
        }

        else if (selection == "4") // settings
        {
            Console.Clear();
            _technician.ViewTechs(_list);

            string techSelect = Console.ReadLine();
            _menu.SettingsMenu();

            string update = Console.ReadLine();
            if (update == "1") 
            {
                _list.UpdateTechName(techSelect);
            }

            else if (update == "2")
            {
                _list.UpdateTechId(techSelect); 
            }   
            
            else if ( update == "3")
            {
                _list.DeleteTech(techSelect);                   
            }

            RunTechnician();
        }

        else  //main menu
        {
            RunMainMenu();
        }


    }


}


