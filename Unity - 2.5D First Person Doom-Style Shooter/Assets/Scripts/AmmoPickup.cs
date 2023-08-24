using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    public int ammoAmount = 25;



    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerController.Instance.AddAmmo(ammoAmount);

            AudioController.instance.PlayPickup();

            Destroy(gameObject);
        }
    }
}
