using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    float secondsToSpawn = 1f;

    void Start()
    {
        StartCoroutine(EnemySpawner());
        StartCoroutine(Timer());
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            Instantiate(enemyPrefab, new Vector3(30f, UnityEngine.Random.Range(-7.5f, 10f), 0f), Quaternion.identity);
            yield return new WaitForSeconds(secondsToSpawn);
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(10f);
            secondsToSpawn = secondsToSpawn / 1.1f;
        }
    }
}
