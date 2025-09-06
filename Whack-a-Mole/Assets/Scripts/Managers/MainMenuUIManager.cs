using System;
using TMPro;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    public TextMeshProUGUI ticketsText;

    private void Start()
    {
        ticketsText.text = TicketsContainer.GetTickets().ToString();
    }
}
