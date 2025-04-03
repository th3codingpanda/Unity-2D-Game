using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class CameraScript : MonoBehaviour
{
    [SerializeField] Camera _maincamera;
    [SerializeField] Transform _player;
    private BoxCollider2D _boxcollider2d;
    public UnityEvent<BoxCollider2D,Collider2D> GiveRoom = new UnityEvent<BoxCollider2D,Collider2D>();
    //replace with box collider
    void Start()
    {

    }
    // Update is called once per frame
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(_player.transform.position.x, _boxcollider2d.bounds.min.x + _maincamera.orthographicSize * _maincamera.aspect, _boxcollider2d.bounds.max.x - _maincamera.orthographicSize * _maincamera.aspect);
        pos.y = Mathf.Clamp(_player.transform.position.y, _boxcollider2d.bounds.min.y + _maincamera.orthographicSize, _boxcollider2d.bounds.max.y - _maincamera.orthographicSize);
        _maincamera.transform.position = pos;
    }

    private void FixedUpdate()
    {


    }
    public void Change(BoxCollider2D boxcollider2d)
    {
        _boxcollider2d = boxcollider2d;

    }
    public void FindRespawn(Collider2D collider2D) {
        GiveRoom.Invoke(_boxcollider2d,collider2D);
    }

}