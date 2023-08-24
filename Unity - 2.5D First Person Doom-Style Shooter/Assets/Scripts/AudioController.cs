using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource DoorClose, DoorOpen, EnemyAttack, EnemyDeath, EnemyInjure, EnemyNearby, Pickup, PistolFiring, PlayerDeath, PlayerInjure;

    private bool hasDied = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayDoorClose() // 
    {
        if (!hasDied)
        {
            DoorClose.Stop();
            DoorClose.Play();
        }
        
    }

    public void PlayDoorOpen() //
    {
        if(!hasDied)
        {
            DoorOpen.Stop();
            DoorOpen.Play();
        }
        
    }

    public void PlayEnemyAttack()
    {
        if (!hasDied)
        {
            EnemyAttack.Stop();
            EnemyAttack.Play();
        }
        
    }

    public void PlayEnemyDeath() //
    {
        if (!hasDied)
        {
            EnemyDeath.Stop();
            EnemyDeath.Play();
        }
        
    }

    public void PlayEnemyInjure() //
    {
        if (!hasDied)
        {
            EnemyInjure.Stop();
            EnemyInjure.Play();
        }
        
    }

    public void PlayEnemyNearby()
    {
        if (!hasDied)
        {
            EnemyNearby.Stop();
            EnemyNearby.Play();
        }
        
    }

    public void PlayPickup() //
    {
        if (!hasDied)
        {
            Pickup.Stop();
            Pickup.Play();
        }
        
    }

    public void PlayPistolFiring() //
    {
        if (!hasDied)
        {
            PistolFiring.Stop();
            PistolFiring.Play();
        }
        
    }

    public void PlayPlayerDeath() //
    {
        if (!hasDied)
        {
            PlayerDeath.Stop();
            PlayerDeath.Play();
            hasDied = true;
        }
        
    }

    public void PlayPlayerInjure() //
    {
        if(!hasDied)
        {
            PlayerInjure.Stop();
            PlayerInjure.Play();
        }
        
    }

}
