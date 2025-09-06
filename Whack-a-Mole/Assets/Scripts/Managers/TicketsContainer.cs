using UnityEngine;

public static class TicketsContainer
{
    private static string saveTicketsKey = "Tickets";

    private static void SetTickets(int n)
    {
        PlayerPrefs.SetInt(saveTicketsKey, n);
        PlayerPrefs.Save();
    }
    
    public static int GetTickets()
    {
        return PlayerPrefs.GetInt(saveTicketsKey, 0); 
    }
    
    public static void ClearTickets()
    {
        PlayerPrefs.DeleteKey(saveTicketsKey);
    }
    
    public static void AddTickets(int tickets)
    {
        int current = GetTickets();
        SetTickets(current + tickets);
    }

    public static void SubtractTickets(int tickets)
    {
        int current = GetTickets();
        SetTickets(Mathf.Max(0, current - tickets));
    }
}
