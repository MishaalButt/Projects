using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorModel;

    public GameObject collObject;

    public float openSpeed;

    private bool shouldOpen;

    void Start()
    {
        
    }

    void Update()
    {
        if(shouldOpen && doorModel.position.z != 1f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 1), openSpeed * Time.deltaTime);

            // AudioController.instance.PlayDoorOpen();

            if(doorModel.position.z == 1f)
            {
                collObject.SetActive(false);
            }
        }
        else if(!shouldOpen && doorModel.position.z != 0f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 0), openSpeed * Time.deltaTime);

            // AudioController.instance.PlayDoorClose();

            if (doorModel.position.z == 0f)
            {
                collObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            shouldOpen = true;
            AudioController.instance.PlayDoorOpen();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = false;
            AudioController.instance.PlayDoorClose();
        }
    }
}
