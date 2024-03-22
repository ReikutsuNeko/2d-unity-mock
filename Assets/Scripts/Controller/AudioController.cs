using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip safeClip;
    [SerializeField] private AudioClip overClip;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void PlaySafeSound() {
        if (safeClip != null) {
            AudioManager.Instance.PlaySoundEffect(safeClip, audioSource);
        }
    }

    public void PlayOverSound() {
        if (overClip != null) {
            AudioManager.Instance.PlaySoundEffect(overClip, audioSource);
        }
    }
}
