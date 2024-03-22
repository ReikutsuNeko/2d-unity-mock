using ObjectInterface;
using UnityEngine;

public class BirdMovement : MonoBehaviour, IDestroyable 
{
    [SerializeField] private float velocity = 5;
    [SerializeField] private float deadZone = -40;
    [SerializeField] private Rigidbody2D birdRigidbody2D;
    [SerializeField] private PopupController popupController;

    private void Start() {
        // popupState = GameObject.FindGameObjectWithTag("PopupState").GetComponent<PopupController>();
    }

    private void Update() {
        BirdInput();
    }

    private void BirdInput() {
        if (GameManager.Instance.GameState == (int)GameStateEnum.GAME_START) {
            if (Input.GetKeyDown(KeyCode.Space))
                birdRigidbody2D.velocity = Vector2.up * velocity;

            if (transform.position.y <= deadZone)
                DestroyObject();

            if (Input.GetKeyDown(KeyCode.Escape)) {
                birdRigidbody2D.mass = 0;
                birdRigidbody2D.gravityScale = 0;
                birdRigidbody2D.velocity = new Vector2(0, 0);
                popupController.ShowPauseScreen();
                GameManager.Instance.InputFrame = false;
            }
        }

        if (GameManager.Instance.GameState == (int)GameStateEnum.GAME_PAUSE) {
            if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.InputFrame) {
                popupController.ClosePauseScreen();
                birdRigidbody2D.mass = 1;
                birdRigidbody2D.gravityScale = 1;
            }
        }
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        popupController.ShowGameOverScreen();
    }
}