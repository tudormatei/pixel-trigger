using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyObjectsSpawner : MonoBehaviour
{
    public GameObject pointsPrefab;

    public GameObject shieldPrefab;

    private void Start()
    {
        StartCoroutine(SpawnPoints());
        StartCoroutine(SpawnShields());
    }

    private void Update()
    {

    }

    IEnumerator SpawnPoints()
    {
        while (true)
        {
            Instantiate(pointsPrefab, new Vector3(30f, UnityEngine.Random.Range(-7.5f, 10f), 0f), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator SpawnShields()
    {
        while (true)
        {
            Instantiate(shieldPrefab, new Vector3(25f, UnityEngine.Random.Range(-7.5f, 10f), 0f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(20f, 25f));
        }
    }
}
