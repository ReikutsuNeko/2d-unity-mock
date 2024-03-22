using ObjectInterface;
using UnityEngine;

public class PipeModel : MonoBehaviour, IDestroyable
{
    [SerializeField] private float velocity = 5;
    [SerializeField] private float deadZone = -40;

    private void Update() {
        if (GameManager.Instance.GameState == (int)GameStateEnum.GAME_START)
            UpdateObjectMovement();
    }

    public void UpdateObjectMovement() {
        transform.position += (Vector3.left * velocity) * Time.deltaTime;

        if (transform.position.x <= deadZone) {
            DestroyObject();
        }
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }
}