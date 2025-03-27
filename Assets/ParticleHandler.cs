using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    [SerializeField] private Movementscript _movementscript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _movementscript.OnJump.AddListener(JumpParticles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void JumpParticles(bool inair) {
    
    }
}
