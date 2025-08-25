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
       UiManager.Instance.ShowTickets(tickets);
    }

    public void ReStoreScore()
    {
        playerScore = 0;
        UiManager.Instance.ShowScore(playerScore);
    }
    
    public void ScoreChanged()
    {
        playerScore += regularScore;
        Debug.Log(playerScore);
        UiManager.Instance.ShowScore(playerScore);
    }
}
