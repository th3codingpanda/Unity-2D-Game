using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]Camera _camera;
    private PolygonCollider2D _polygonCollider;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(_camera.transform.position.y)
        _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z);
        if (Input.GetMouseButton(0)) {
            Debug.Log(_camera.transform.position);
            //do camera stuff with points max out -15 prob because size wow wowoowowowowowowowo

        }
    }
    private void FixedUpdate()
    {


    }
    public void Change(PolygonCollider2D polygonCollider2D) {
        _polygonCollider = polygonCollider2D;
        Debug.Log(_polygonCollider.points[0].y);

    }
}