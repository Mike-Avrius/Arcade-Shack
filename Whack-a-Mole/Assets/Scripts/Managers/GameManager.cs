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
        UiManager.Instance.StartButtonStatuc(false);
        UiManager.Instance.TicketsTextStatuc(false);
        scoreAndTicketsManger.ReStoreScore();
    }
    public void StopGeneration()
    {
        gameTimer.startToCount = false;  
        biverGenerator.StopAndReset(); 
        biverGenerator.startGeneration = false;
        UiManager.Instance.StartButtonStatuc(true);
        UiManager.Instance.TicketsTextStatuc(true);
    }
}
