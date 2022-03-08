using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public Camera cameraObject;

    private float force = 15f;

    public float currentPoints = 0f;

    public Text score;

    public Text highScore;

    public GameObject tapToStart;

    public ParticleSystem playerExplosion;

    public ParticleSystem pointExplosion;

    public Animator textAnimation;

    public Animator cameraShake;

    public AudioSource pointsPickup;

    public ParticleSystem shield;

    bool isStarted = false;

    public GameObject pauseMenu;

    private void Start()
    {
        isStarted = false;

        gameObject.SetActive(true);

        rb = GetComponent<Rigidbody2D>();

        currentPoints = 0f;

        Time.timeScale = 0.00001f;

        tapToStart.SetActive(true);
    }

    private void Update()
    {
        shield.transform.position = transform.position;

        if(Input.touchCount > 0 && Time.timeScale == 0.00001f)
        {
            tapToStart.SetActive(false);
            Time.timeScale = 1;

            isStarted = true;
        }

        if (isStarted && Input.touchCount > 0 && !pauseMenu.activeSelf)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 cast = Camera.main.ScreenToWorldPoint(touch.position);

            RaycastHit2D hit;

            hit = Physics2D.Raycast(new Vector2(cast.x, cast.y), Vector2.zero);

            //Checking for points
            if (hit.transform.tag == "Points")
            {
                pointsPickup.volume = UnityEngine.Random.Range(0.5f, 0.75f);
                pointsPickup.Play();
                StartCoroutine(TextAnimation());
                currentPoints++;
                pointExplosion.transform.position = hit.transform.position;
                pointExplosion.Play();
                Destroy(hit.transform.gameObject);
            }
            else
            {
                Jump();
            }
        }

        //Out of bounds
        if (transform.position.y > 12)
        {
            Die();
        }

        score.text = currentPoints.ToString();
    }

    public void Jump()
    {
        rb.velocity = Vector2.up * force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Lava")
        {
            Destroy(shield);
            Die();
        }
        else if (collision.transform.tag == "Enemy")
        {
            if (shield.isPlaying)
            {
                
            }
            else
            {
                Die();
            }
        }
        else if (collision.transform.tag == "Points")
        {

            pointsPickup.volume = UnityEngine.Random.Range(0.5f, 0.75f);
            pointsPickup.Play();
            pointExplosion.transform.position = collision.transform.position;
            pointExplosion.Play();
            StartCoroutine(TextAnimation());
            currentPoints++;
        }
        else if (collision.transform.tag == "Shields")
        {
            StartCoroutine(Shields());
        }
    }

    private void Die()
    {
        if(PlayerPrefs.GetFloat("Highscore") < currentPoints)
        {
            PlayerPrefs.SetFloat("Highscore", currentPoints);
        }
        playerExplosion.transform.position = gameObject.transform.position;
        playerExplosion.Play();
        StartCoroutine(CameraShake());
        Destroy(gameObject);
    }

    IEnumerator Shields()
    {
        shield.Play();
        yield return new WaitForSeconds(5f);
        shield.Stop();
    }

    IEnumerator TextAnimation()
    {
        textAnimation.SetBool("GotPoints", true);
        yield return new WaitForSeconds(0.1f);
        textAnimation.SetBool("GotPoints", false);
    }

    IEnumerator CameraShake()
    {
        cameraShake.SetBool("GotPoint", true);
        yield return new WaitForSeconds(0.08f);
        cameraShake.SetBool("GotPoint", false);
    }
}
