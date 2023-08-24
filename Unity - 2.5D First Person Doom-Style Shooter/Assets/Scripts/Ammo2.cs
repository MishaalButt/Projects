using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo2 : MonoBehaviour
{
    public Sprite[] num;
    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int ammo = PlayerController.Instance.currentAmmo;
        int i;

        if(ammo <= 0)
        {
            i = 0;
        }
        else
        {
            i = ammo % 10;
        }

        img.sprite = num[i];
    }
}
