using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int currentHealth;
    private int maxHealth = 200;
    private Transform playerPos;
    private float lookAngle;
    private Rigidbody2D rb;
    private Transform bulletSpawnPoint;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float shotsCooldown = 5;
    [SerializeField] GameObject projectile;
    [SerializeField] float movementSpeed;
    Vector2 lookDir;

    void Start()
    {
        currentHealth = maxHealth;
        movementSpeed = 50;
        rb = GetComponent<Rigidbody2D>();
        playerPos = FindObjectOfType<PlayerMovement>().transform;
        bulletSpawnPoint = gameObject.transform.GetChild(0).transform;
        lookDir = playerPos.position - transform.position;
        StartCoroutine(Shoot());
    }

    void Update()
    {
        lookDir = playerPos.position - transform.position;
        lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(playerPos.position, transform.position) > Random.Range(3, 5))
            rb.velocity = lookDir.normalized * movementSpeed * Time.fixedDeltaTime;
        else
            rb.velocity = Vector2.zero;

        rb.rotation = lookAngle;
    }

    IEnumerator Shoot()
    {
        if (Vector2.Distance(playerPos.position, transform.position) < 10)
        {
            GameObject bullet = Instantiate(projectile, bulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = lookDir.normalized * bulletSpeed;
        }

        yield return new WaitForSeconds(Random.Range(3, 8));
        StartCoroutine(Shoot());
    }

    public void GetDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
