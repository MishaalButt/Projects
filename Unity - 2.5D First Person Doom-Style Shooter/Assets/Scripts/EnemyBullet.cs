using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount;

    public float bulletSpeed = 5f;

    public Rigidbody2D theRB;

    private Vector3 direction;

    void Start()
    {
        direction = PlayerController.Instance.transform.position - transform.position;
        direction.Normalize();
        direction *= bulletSpeed;
    }

    void Update()
    {
        theRB.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.Instance.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
        else if(other.tag == "Tiles")
        {
            Destroy(gameObject);
        }
    }
}
