using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class SoundOnTrigger : MonoBehaviour
{
    [Header("Sound Settings")]
    public AudioClip soundClip;
    public Transform player;

    private AudioSource audioSource;

    void Start()
    {
        // Configurar el AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.loop = false;

        // Configurar el Collider como Trigger
        Collider collider = GetComponent<Collider>();
        if (!collider.isTrigger)
        {
            collider.isTrigger = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Comprobar si el jugador activó el Trigger
        if (other.transform == player)
        {
            PlaySound();
        }
    }

    private void PlaySound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // Detener el sonido si ya está reproduciéndose
        }
        audioSource.Play();
        Debug.Log("Sonido activado por el jugador.");
    }
}

