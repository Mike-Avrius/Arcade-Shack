using System.Collections;
using UnityEngine;

public class Biver : MonoBehaviour
{
    private StageManager stageManager;
    public float lifeTime = 5f;

    private void Start()
    {
        stageManager = FindFirstObjectByType<StageManager>();
        StartCoroutine(DelayedDeath());
    }

    private IEnumerator DelayedDeath()
    {
        yield return null;

        float actualLifeTime = GetLifeTimeFromStage();
        
        Debug.Log($"[Biver] CurrentStage: {stageManager.currentStage}, LifeTime: {actualLifeTime}");

        yield return new WaitForSeconds(actualLifeTime);

        Destroy(gameObject);
    }

    private float GetLifeTimeFromStage()
    {
        switch (stageManager.currentStage)
        {
            case 0: return 1.9f;
            case 1: return 1.4f;
            case 2: return 1.1f;
            case 3: return 0.9f;
            default: return 5f;
        }
    }

    public void BiverDeath()
    {
        Destroy(gameObject);
    }
}