using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]Camera _maincamera;
    [SerializeField]Transform _player;
    private PolygonCollider2D _polygonCollider;
    //replace with box collider
    void Start()
    {

    }
    // Update is called once per frame
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(_player.transform.position.x, _polygonCollider.bounds.min.x + _maincamera.orthographicSize * _maincamera.aspect, _polygonCollider.bounds.max.x - _maincamera.orthographicSize * _maincamera.aspect);
        pos.y = Mathf.Clamp(_player.transform.position.y, _polygonCollider.bounds.min.y + _maincamera.orthographicSize, _polygonCollider.bounds.max.y - _maincamera.orthographicSize);
        _maincamera.transform.position = pos;
    }

    private void FixedUpdate()
    {


    }
    public void Change(PolygonCollider2D polygonCollider2D) {
        _polygonCollider = polygonCollider2D;

    }
}