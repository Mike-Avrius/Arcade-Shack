using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }

    public TextMeshProUGUI scoreValue;
    public TextMeshProUGUI timervalue;
    public TextMeshProUGUI ticketsValue;

    public TextMeshProUGUI ticketsText;
    public Button startButton;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    public void TicketsTextStatuc(bool status) => ticketsText.gameObject.SetActive(status);
    public void StartButtonStatuc(bool status) => startButton.gameObject.SetActive(status);
    public void ShowScore(int score) => scoreValue.text = score.ToString();
    public void UpdateTimer(float time) => timervalue.text = time.ToString();
    public void ShowTickets(int tickets) => ticketsValue.text = $"Tickets:     {tickets}";
    
    
}
