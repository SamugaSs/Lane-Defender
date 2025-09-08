using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject BulletSpawn;
    [SerializeField] private GameObject bulletExplosion;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioSource TankShoot;
    [SerializeField] private AudioSource enemyDeath;
    [SerializeField] private AudioSource enemyhit;
    public bool canMove = true;
    public bool canShoot = true;
    private bool BulletCooldown;

    [SerializeField] private float playerSpeed = 5f;
    [HideInInspector] public Vector3 playerMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canMove = true;
        canShoot = true;
        BulletCooldown = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == true)
        {
            rb.linearVelocity = new Vector3(0, playerMove.y);
        }
    }

    private void FixedUpdate()
    {
 
    }
    private void OnShoot()
    {
        if (canShoot == true & BulletCooldown == true)
        {
            StartCoroutine(ShootCooldown());
            StartCoroutine(ShootBullet());
        }
    }

    private void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnQuit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void OnMove(InputValue iValue)
    {
        Vector2 inputMovementValue = iValue.Get<Vector2>();
        playerMove.x = inputMovementValue.x * playerSpeed;
        playerMove.y = inputMovementValue.y * playerSpeed;
    }

   

    public IEnumerator ShootBullet()
    {
        for (int i = 0; i < 1; i++)
        {
            TankShoot.Play();
            Vector2 bulletPos = BulletSpawn.transform.position;
            bulletExplosion.SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            GameObject B = Instantiate(bullet, bulletPos, Quaternion.identity);
            bulletExplosion.SetActive(false);

            yield return null;
        }
    }

    public IEnumerator ShootCooldown()
    {
        BulletCooldown = false;
        yield return new WaitForSecondsRealtime(2);
        BulletCooldown = true;
    }

    public void EnemyHit()
    {
        enemyhit.Play();
    }

    public void EnemyDead()
    {
        enemyDeath.Play();
    }
}
