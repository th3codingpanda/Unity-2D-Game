using System;
using UnityEngine;

public class Camera : MonoBehaviour 
{
    public GameObject VirtualCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.CompareTag("Player")) {
        VirtualCam.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            VirtualCam.SetActive(false);
        }

    }
}
