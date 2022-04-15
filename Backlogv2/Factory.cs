public static class Factory
{
    public static ITechnician CreateTechnician()
    {
        return new Technician();
    }

    public static ITicket CreateTicket()
    {

        return new Ticket();
    }

}