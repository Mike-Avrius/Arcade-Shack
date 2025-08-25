using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public delegate void OnBeaverTouched();
public class TapBiver : MonoBehaviour
{
    public event OnBeaverTouched BeaverWasToched;
    [FormerlySerializedAs("scoreManger")] public ScoreAndTicketsManger scoreAndTicketsManger;


    private void Start()
    {
        scoreAndTicketsManger = FindFirstObjectByType<ScoreAndTicketsManger>();
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 screenPos = Mouse.current.position.ReadValue();
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            CheckTouch(worldPos);
        }
#else
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Vector2 screenPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            CheckTouch(worldPos);
        }
#endif
    }

    void CheckTouch(Vector2 worldPos)
    {
        Collider2D hit = Physics2D.OverlapPoint(worldPos);
        if (hit != null && hit.CompareTag("Biver"))
        {
            BeaverWasToched?.Invoke();
        }
    }
}