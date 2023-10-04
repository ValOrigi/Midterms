using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float timer = 0f;
    public float maxTimer;
    public Transform[] teleport; 
    public GameObject[] prefab;

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (timer <= maxTimer)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            int teleportNum = Random.Range(0, 3);
            int prefabNum = Random.Range(0, 3);
            Instantiate(prefab[prefabNum], teleport[teleportNum].position, teleport[teleportNum].rotation);
        }
    }
}
