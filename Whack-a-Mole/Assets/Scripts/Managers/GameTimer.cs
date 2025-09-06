using System;
using UnityEngine;


public class GameTimer : MonoBehaviour
{
    public GameManager gameManager;
    public StageManager stageManager;
    public ScoreAndTicketsManger scoreAndTicketsManger;
   
    [SerializeField] private float _RoundTime = 60;
    public float timeForTest = 10;

    public bool startToCount = false;


    private void Start()
    {
        if (WhackAMoleUiManager.Instance == null)
            Debug.LogError("UiManager.Instance is null!");
    }

    private void Update()
    {
        if (startToCount)
        {
            Timer(); 
        }
        
    }
    private void Timer()
    {
        if (_RoundTime > 0)
        {
            _RoundTime -= Time.deltaTime;
            int displayedTime = Mathf.CeilToInt(_RoundTime);
            WhackAMoleUiManager.Instance.UpdateTimer(displayedTime);
        }
        else
        {
            _RoundTime = 0;
            gameManager.StopGeneration();
            WhackAMoleUiManager.Instance.UpdateTimer(0);
            scoreAndTicketsManger.CalculateTickets();
            Debug.Log("Game finished");
        }
        PhaseChecking();
    }

    private void PhaseChecking()
    {
        if (_RoundTime >= 40)
            stageManager.ChangeStage(0);
       else if (_RoundTime >= 20 && _RoundTime < 45)
           stageManager.ChangeStage(1);
        if (_RoundTime >= 10 && _RoundTime < 20)
            stageManager.ChangeStage(2);
        if (_RoundTime >= 0 && _RoundTime < 10)
            stageManager.ChangeStage(3);
    }
    
    public void ResetTimer()
    {
        _RoundTime = timeForTest; 
        startToCount = false;
        WhackAMoleUiManager.Instance.UpdateTimer(0);
    }

    
}
