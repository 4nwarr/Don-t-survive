using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject[] playerBullets;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    void Shoot()
    {
        int bulletIndex = FindBullet();

        if (bulletIndex != 100)
        {
            playerBullets[bulletIndex].transform.position = bulletSpawnPoint.position;
            playerBullets[bulletIndex].SetActive(true);
            playerBullets[bulletIndex].GetComponent<Rigidbody2D>().velocity = playerMovement.GetMouseDir().normalized * 10;
        }
    }

    int FindBullet()
    {
        for (int i = 0; i < playerBullets.Length; i++)
        {
            if (!playerBullets[i].activeSelf)
                return i;
        }
        return 100;
    }
}
