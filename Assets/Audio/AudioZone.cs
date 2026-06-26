using UnityEngine;


public class AudioZone : MonoBehaviour
{
    private AudioSource audioSource;

    [Range(0f, 1f)]
    public float fadeSpeed = 0.02f;

    public float maxVolume = 0.8f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0f;
        audioSource.Play();
    }

    void Update()
    {
        if (audioSource.volume < maxVolume && IsPlayerInside())
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, maxVolume, fadeSpeed * Time.deltaTime);
        else if (!IsPlayerInside())
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, 0f, fadeSpeed * Time.deltaTime);
    }

    private bool playerInside = false;

    bool IsPlayerInside() => playerInside;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }
}
