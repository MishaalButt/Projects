using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health2 : MonoBehaviour
{
    public Sprite[] nums;
    public Image imgs;

    void Start()
    {

    }

    void Update()
    {
        if(PlayerController.Instance.currentHealth >= 0)
        {
            int j = PlayerController.Instance.currentHealth % 10;

            imgs.sprite = nums[j];
        }
        
    }
}
