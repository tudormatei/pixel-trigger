using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject pointsPrefab;
    public GameObject enemyPrefab;
    public GameObject shieldPrefab;

    public GameObject tapToStart;

    public GameObject movementInfo;
    public GameObject pointsInfo;
    public GameObject enemyInfo;
    public GameObject shieldInfo;
    public GameObject finishInfo;

    public GameObject player;
    public GameObject playerTrail;

    void Update()
    {
        if (Input.touchCount > 0 && Time.timeScale == 0.00001f)
        {
            StartCoroutine(TutorialStart());
        }
    }

    IEnumerator TutorialStart()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        movementInfo.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        movementInfo.SetActive(false);

        Instantiate(pointsPrefab, new Vector3(25f, 0f, 0f), Quaternion.identity);
        yield return new WaitForSecondsRealtime(0.75f);
        Time.timeScale = 0f;
        pointsInfo.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale = 1f;
        pointsInfo.SetActive(false);

        yield return new WaitForSecondsRealtime(3f);
        Instantiate(enemyPrefab, new Vector3(25f, 0f, 0f), Quaternion.identity);
        yield return new WaitForSecondsRealtime(0.75f);
        Time.timeScale = 0f;
        enemyInfo.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        Time.timeScale = 1f;
        enemyInfo.SetActive(false);

        yield return new WaitForSecondsRealtime(3f);
        Instantiate(shieldPrefab, new Vector3(25f, 0f, 0f), Quaternion.identity);
        yield return new WaitForSecondsRealtime(0.75f);
        Time.timeScale = 0f;
        shieldInfo.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale = 1f;
        shieldInfo.SetActive(false);

        yield return new WaitForSecondsRealtime(1f);
        Instantiate(enemyPrefab, new Vector3(25f, 0f, 0f), Quaternion.identity);
        yield return new WaitForSecondsRealtime(1f);
        Instantiate(enemyPrefab, new Vector3(25f, 5f, 0f), Quaternion.identity);
        yield return new WaitForSecondsRealtime(1f);
        Instantiate(enemyPrefab, new Vector3(25f, -5f, 0f), Quaternion.identity);
        yield return new WaitForSecondsRealtime(1f);
        Instantiate(enemyPrefab, new Vector3(25f, 10f, 0f), Quaternion.identity);

        yield return new WaitForSecondsRealtime(3.5f);
        player.SetActive(false);
        playerTrail.SetActive(false);
        Time.timeScale = 0f;
        finishInfo.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(0);
    }
}