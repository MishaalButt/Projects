using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health1 : MonoBehaviour
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
        int i;
        int health = PlayerController.Instance.currentHealth;
        if (health < 100 && health > 9)
            i = health / 10;
        else
            i = 0;

        img.sprite = num[i]; 
    }
}
