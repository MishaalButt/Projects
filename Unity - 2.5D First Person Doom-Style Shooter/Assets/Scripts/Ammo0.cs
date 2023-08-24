using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo0 : MonoBehaviour
{
    public Sprite[] num;
    public Image img;

    void Start()
    {
        
    }

    void Update()
    {
        int ammo = PlayerController.Instance.currentAmmo;
        int i;

        if(ammo > 99)
        {
            img.enabled = true;
            i = ammo;
            i /= 100;
            img.sprite = num[i];
        }
        else
        {
            img.enabled = false;
        }
    }
}
