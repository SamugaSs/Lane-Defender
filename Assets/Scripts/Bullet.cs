using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject explosion;
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.right * Time.deltaTime * speed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(bulletHitEnemy());
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator bulletHitEnemy()
    {
        speed = 0;
        bullet.SetActive(false);
        explosion.SetActive(true);
        yield return new WaitForSecondsRealtime(0.2f);
        explosion.SetActive(false);
        Destroy(this.gameObject);
    }
}
