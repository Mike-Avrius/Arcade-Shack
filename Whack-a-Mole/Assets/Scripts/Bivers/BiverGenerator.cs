using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BiverGenerator : MonoBehaviour
{
    public StageManager stageManager;
    public GameObject prefabBeaver;
    [FormerlySerializedAs("scoreManager")] public ScoreAndTicketsManger scoreAndTicketsManager;

    public Transform[] spawnPoints;

    public bool startGeneration = false;
    
    private Coroutine generationCoroutine;

    
    private void Update()
    {
        if (startGeneration && generationCoroutine == null)
        {
            generationCoroutine = StartCoroutine(GenerateLoop());
        }
    }

    private IEnumerator GenerateLoop()
    {
        while (startGeneration)
        {
            GenerateBeaver();
            float waitTime = BeaverGenerationTime();
            yield return new WaitForSeconds(waitTime);
        }

        generationCoroutine = null;
    }

    private float BeaverGenerationTime()
    {
        switch (stageManager.currentStage)
        {
            case 0: return 2.0f;
            case 1: return 1.5f;
            case 2: return 1.2f;
            case 3: return 1.0f;
            default: return 10f;
        }
    }


    public void GenerateBeaver()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];
        
        GameObject newBeaver = Instantiate(prefabBeaver, spawnPoint.position, Quaternion.identity);
        
        TapBiver tap = newBeaver.GetComponent<TapBiver>();
        Biver biver = newBeaver.GetComponent<Biver>();

        if (tap != null && biver != null)
        {
            tap.scoreAndTicketsManger = scoreAndTicketsManager;

            // Подписываем ивент
            tap.BeaverWasToched += biver.BiverDeath;
            tap.BeaverWasToched += scoreAndTicketsManager.ScoreChanged;
        }
    }
    
    public void StopAndReset()
    {
        startGeneration = false;

        if (generationCoroutine != null)
        {
            StopCoroutine(generationCoroutine);
            generationCoroutine = null;
        }
    }

    
}
