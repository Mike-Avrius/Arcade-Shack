using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public bool[] stages = { true, false, false, false };
    public int currentStage;

    private void Start()
    {
        currentStage = GetCurrentStage();
    }
    

    public void ChangeStage(int s)
    {
        if (s >= stages.Length)
        {
            Debug.Log("Stage Can't be changed");
        }

        for (int i = 0; i < stages.Length; i++)
        {
            if (i == s)
            {
                stages[s] = true;  
                Debug.Log("Stage changed!");
            }
            else
            {
                stages[i] = false;
            }
        }
        currentStage = s;
    }
    
    public int GetCurrentStage()
    {
        for (int i = 0; i < stages.Length; i++)
        {
            if (stages[i])
            {
                return i;
            }
        }

        return -1; 
    }
}
