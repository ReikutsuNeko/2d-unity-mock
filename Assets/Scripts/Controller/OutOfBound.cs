using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    [SerializeField] private PopupController popupController;

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == 3) {
            popupController.ShowGameOverScreen();
        }
    }

}
