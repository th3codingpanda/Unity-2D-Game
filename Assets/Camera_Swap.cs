using System;
using UnityEngine;

public class Camera_Swap : MonoBehaviour
{
    [SerializeField] BoxCollider2D _boxcollider2d;
    [SerializeField] CameraScript _cameraScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            _cameraScript.Change(_boxcollider2d);
        }
    }
}
