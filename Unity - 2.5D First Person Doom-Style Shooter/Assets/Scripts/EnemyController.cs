using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 5;
    private int i = 0;

    public Sprite[] sprites;

    public SpriteRenderer spriteRenderer;

    public float playerRange = 10f;
    public float moveSpeed;
    public float fireRate = .5f;
    private float shotCounter;

    public Rigidbody2D theRB;

    public bool shouldShoot;

    public GameObject bullet;

    public Transform firePoint;

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.Instance.transform.position - transform.position;

            theRB.velocity = playerDirection.normalized * moveSpeed;                // 1 on the x or 1 on the y maximum

            if(shouldShoot && health > 0)
            {

                shotCounter -= Time.deltaTime;                                      // Counts down
                if(shotCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                }
            }
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }
    }
    
    public void TakeDamage()
    {
        health--;
        ChangeSprite();
        if (health <= 0) Invoke("Death", 1.5f);
        else AudioController.instance.PlayEnemyInjure();
    }

    public void ChangeSprite()
    {
        
        if(i >= 0 || i <= health-1)
        {
            i++;
            spriteRenderer.sprite = sprites[i];
        }
        
        if (health <= 0)
        {
            theRB.velocity = Vector2.zero;
            moveSpeed = 0;
            Invoke("Death", 1);

            AudioController.instance.PlayEnemyDeath();
        }
            
    }

    public void Death()
    {
        Destroy(gameObject);
    }

}
