using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BiverGenerator biverGenerator;
    public GameTimer gameTimer;
    public ScoreAndTicketsManger scoreAndTicketsManger;

    public void StartGeneration()
    {
        gameTimer.ResetTimer();
        gameTimer.startToCount = true;  
        biverGenerator.startGeneration = true;
        WhackAMoleUiManager.Instance.StartButtonStatuc(false);
        WhackAMoleUiManager.Instance.TicketsTextStatuc(false);
        scoreAndTicketsManger.ReStoreScore();
    }
    public void StopGeneration()
    {
        gameTimer.startToCount = false;  
        biverGenerator.StopAndReset(); 
        biverGenerator.startGeneration = false;
        WhackAMoleUiManager.Instance.StartButtonStatuc(true);
        WhackAMoleUiManager.Instance.TicketsTextStatuc(true);
    }
}
