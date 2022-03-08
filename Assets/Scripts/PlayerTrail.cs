using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    public GameObject player;

    public ParticleSystem playerTrail;

    private void Start()
    {
        playerTrail.Play();
    }

    private void Update()
    {
        if(player == null)
        {
            playerTrail.Stop();
        }
        else
        {
            transform.position = player.transform.position;
        }
    }
}
