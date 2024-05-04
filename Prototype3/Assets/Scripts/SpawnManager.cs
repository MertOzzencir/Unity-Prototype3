using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject boxPrefab;
    private PlayerController playerController;
    public Vector3 spawnPosition;
    private float startDelayTime = 2;
    private float delayTime = 2.5f;
    void Start()
    {
        InvokeRepeating("SpawnObscales", startDelayTime, delayTime);
        playerController = FindObjectOfType<PlayerController>();
    }

    void SpawnObscales()
    {
        if(!playerController.gameOver)
        {
            Instantiate(boxPrefab, spawnPosition, boxPrefab.transform.rotation);

        }

    }
}
