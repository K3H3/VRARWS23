using UnityEngine;

public class ConfettiController : MonoBehaviour
{
    ParticleSystem confettiParticleSystem;

    void Start()
    {
        // Get the ParticleSystem component
        confettiParticleSystem = GetComponent<ParticleSystem>();

        // Deactivate the confetti initially
        StopConfetti();
    }

    public void StartConfetti()
    {
        // Activate the confetti
        confettiParticleSystem.Play();
    }

    public void StopConfetti()
    {
        // Deactivate the confetti
        confettiParticleSystem.Stop();
    }
}