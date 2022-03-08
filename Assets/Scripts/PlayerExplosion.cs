using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{
    public AudioSource explosion;

    public GameObject player;

    private bool canPlay;

    private void Start()
    {
        canPlay = false;
    }
    private void Update()
    {
        if (player == null && !canPlay)
        {
            canPlay = true;
            explosion.volume = UnityEngine.Random.Range(0.5f, 1f);
            explosion.Play();
        }
    }
}
