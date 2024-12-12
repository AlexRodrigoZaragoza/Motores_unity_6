using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class RadioSoundActivator : MonoBehaviour
{
    [Header("Sound Settings")]
    public AudioClip soundClip;
    public Transform player;

    private AudioSource audioSource;
    private bool soundActivated = false;

    void Start()
    {
        // Configurar el AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.loop = true;
        audioSource.spatialBlend = 1.0f; 

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
        if (!soundActivated && other.transform == player)
        {
            ActivateSound();
        }
    }

    private void ActivateSound()
    {
        soundActivated = true;
        audioSource.Play();
        Debug.Log("Sonido activado por primera vez.");
    }
}
