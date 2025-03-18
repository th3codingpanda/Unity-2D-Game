using System;
using UnityEngine;

public class Camera_Swap : MonoBehaviour
{
    [SerializeField] PolygonCollider2D _polygonCollider2D;
    [SerializeField] CameraScript _cameraScript;
    private Camera[] _camera;
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
            Debug.Log(collision.transform.parent.name);
         
            
            _camera = collision.transform.parent.GetComponentsInChildren<Camera>();
            Debug.Log(_camera[0].name);
            
            _cameraScript.Change(_polygonCollider2D);
            Debug.Log(_camera[0].name);
        }
    }
}
