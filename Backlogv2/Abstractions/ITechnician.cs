public interface ITechnician
{    
    string TechnicianId { get; }
    string TechnicianName { get; } 
 
    void TechId(string Id);
    void TechName(string name);
    void ViewTechs(IList list);
}
