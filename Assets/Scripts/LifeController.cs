/*****************************************************************************
// File Name : LifeController.cs
// Author : Gabriel Flores-Martinez
// Creation Date : September 7, 2025
//
// Brief Description : This script tracks the players life
*****************************************************************************/
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LifeController : MonoBehaviour
{

    private int health;
    private PlayerController player;
    private EnemySpawn Spawn;
    private bool HealthdownCool;

    [SerializeField] private GameObject RestartButton;
    [SerializeField] private GameObject QuitButton;
    [SerializeField] private GameObject life1;
    [SerializeField] private GameObject life2;
    [SerializeField] private GameObject life3;
    [SerializeField] private AudioSource lifeLost;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 3;
        player = GameObject.FindObjectOfType<PlayerController>();
        Spawn = GameObject.FindObjectOfType<EnemySpawn>();
        HealthdownCool = true;
    }
    private void FixedUpdate()
    {
        if (health == 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if (health == 2)
        {
            life1.SetActive(false);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if (health == 1)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(true);
        }
        else if (health == 0)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(false);
        }
    }

    public void UpdateHealth()
    {
            health--;
            lifeLost.Play();
            if (health <= 0)
            {
                //GetComponent<PlayerController>().enabled = false;
                player.canMove = false;
                player.canShoot = false;
                Spawn.StopSpawn();
                RestartButton.SetActive(true);
                QuitButton.SetActive(true);

                //sfx for dying
            }
    }
}
