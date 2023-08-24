using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health0 : MonoBehaviour
{   
    public Image img;

    void Start()
    {
        img.enabled = true;
    }

    void Update()
    {
        if(PlayerController.Instance.currentHealth == 100)
        {
            img.enabled = true;
        }
        else
        {
            img.enabled = false;
        }
    }
}
