using System;
using UnityEngine;

public class ScoreAndTicketsManger : MonoBehaviour
{
    [SerializeField] private int playerScore = 0;
    private int regularScore = 100;
    private int tickets = 0;

    

    public void CalculateTickets()
    { 
       tickets = playerScore / 100;
       TicketsContainer.AddTickets(tickets);
       WhackAMoleUiManager.Instance.ShowTickets(tickets);
    }

    public void ReStoreScore()
    {
        playerScore = 0;
        WhackAMoleUiManager.Instance.ShowScore(playerScore);
    }
    
    public void ScoreChanged()
    {
        playerScore += regularScore;
        Debug.Log(playerScore);
        WhackAMoleUiManager.Instance.ShowScore(playerScore);
    }
}
