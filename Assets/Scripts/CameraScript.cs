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

    }
    // Update is called once per frame
    void Update()
    {   // edit math clamp to take in camera size
        //if (_camera.transform.position.x >= _polygonCollider.points[0].x + _camera.orthographicSize) {
        //    _camera.transform.position = new Vector2(_polygonCollider[0]., 0);
        //}
        _camera.transform.position = new Vector3(Mathf.Clamp(_transform.transform.position.x, _polygonCollider.points[0].x + _camera.orthographicSize , _polygonCollider.points[2].x - _camera.orthographicSize), _transform.transform.position.y, -1);
        //_camera.transform.position = new Vector3(_transform.transform.position.x, _transform.transform.position.y, _camera.transform.position.z);
        if (Input.GetMouseButton(0))
        {
            Debug.Log(_camera.transform.position);
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