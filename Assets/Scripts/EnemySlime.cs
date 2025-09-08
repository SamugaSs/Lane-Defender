/*****************************************************************************
// File Name : EnemySlime.cs
// Author : Gabriel Flores-Martinez
// Creation Date : September 7, 2025
//
// Brief Description : This script is the code for the slime
*****************************************************************************/
using UnityEngine;

public class EnemySlime : MonoBehaviour
{

    private int health;
    private LifeController life;
    private ScoreController Score;
    private PlayerController player;

    private float speed = 1.5f;
    [SerializeField] private GameObject walking;
    [SerializeField] private GameObject hit;
    [SerializeField] private GameObject dead;
    [SerializeField] private float deathDelay = 1.5f;
    [SerializeField] private AudioSource enemyDeath;
    [SerializeField] private AudioSource enemyhit;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * Time.deltaTime * speed);
        life = GameObject.FindObjectOfType<LifeController>();
        Score = GameObject.FindObjectOfType<ScoreController>();
        player = GameObject.FindObjectOfType<PlayerController>();
    }
    private void UpdateHealth()
    {
        health--;

        if (health <= 0)
        {
            Score.EnemyDeath();
            walking.SetActive(false);
            dead.SetActive(true);
            speed = 0;
            player.EnemyDead();
            Invoke("Dead", deathDelay);
        }
        else
        {
            walking.SetActive(false);
            hit.SetActive(true);
            speed = 0;
            player.EnemyHit();
            Invoke("Hit", deathDelay);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            UpdateHealth();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            life.UpdateHealth();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Life"))
        {
            life.UpdateHealth();
            Destroy(this.gameObject);
        }
    }

    private void Dead()
    {
        Destroy(this.gameObject);
    }

    private void Hit()
    {
        hit.SetActive(false);
        walking.SetActive(true);
        speed = 2f;
    }
}
