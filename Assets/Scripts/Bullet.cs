using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] float bulletSpeed = 5f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = playerMovement.GetMouseDir().normalized * bulletSpeed;
    }
}
