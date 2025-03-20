using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]Camera _camera;
    [SerializeField]Transform _transform;
    private PolygonCollider2D _polygonCollider;
    void Start()
    {
        _camera.transform.position = new Vector3(_transform.position.x, _transform.position.y , _camera.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {   // edit math clamp to take in camera size
        _camera.transform.position = new Vector3(Mathf.Clamp(_transform.position.x + _camera.orthographicSize/2, _polygonCollider.points[0].x, _polygonCollider.points[2].x), _transform.position.y, -1);
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