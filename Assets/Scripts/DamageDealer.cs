using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 50;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
            collider.GetComponent<Enemy>().GetDamage(damage);
        else if (collider.CompareTag("Player"))
            collider.GetComponent<PlayerMovement>().GetDamage(damage);

        gameObject.SetActive(false);
    }
}
