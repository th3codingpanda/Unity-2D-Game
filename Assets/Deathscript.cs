using Unity.VisualScripting;
using UnityEngine;
public class Deathscript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxcollider2D;
    [SerializeField]CameraScript _camerascript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        _camerascript.GiveRoom.AddListener(Respawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            _camerascript.FindRespawn(collider2D);
        }
    }


    public void Respawn(BoxCollider2D boxCollider2D, Collider2D collider2D)
    {
        collider2D.transform.root.position = boxCollider2D.transform.Find("RespawnPoint").transform.position;
        Debug.Log(collider2D.transform.root.position);
    }

}
