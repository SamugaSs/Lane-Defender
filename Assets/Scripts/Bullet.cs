/*****************************************************************************
// File Name : Bullet.cs
// Author : Gabriel Flores-Martinez
// Creation Date : September 7, 2025
//
// Brief Description : This script allows the bullet fired to move and damage enemies
*****************************************************************************/
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject bullet;
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.right * Time.deltaTime * speed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            speed = 0;
            bullet.SetActive(false);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
