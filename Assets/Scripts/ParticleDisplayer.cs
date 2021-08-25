using UnityEngine;

public class ParticleDisplayer
{    
    public void DisplayParticles(GameObject gameObject)
    {
        ParticleSystem particleSystem;

        if(gameObject.TryGetComponent(out particleSystem))
        {
            particleSystem.Play();
        }
    }
}
