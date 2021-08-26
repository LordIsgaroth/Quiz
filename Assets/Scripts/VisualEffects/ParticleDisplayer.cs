using UnityEngine;

/// <summary>
/// Отображение эффекта частиц
/// </summary>
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