using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SafeSpot : MonoBehaviour
{
    [SerializeField] private AudioController audioController;

    private void Start() {
        audioController = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.GameObject().layer == 3) {
            ScoreManager.Instance.IncrementScore();
            audioController.PlaySafeSound();
        }
    }
}
