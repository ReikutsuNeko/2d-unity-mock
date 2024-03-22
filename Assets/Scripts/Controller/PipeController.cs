using ObjectInterface;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private GameObject pipes;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnTimer = 0;
    [SerializeField] private float heightOffset = 10;

    private void Update() {
        if (GameManager.Instance.GameState == (int)GameStateEnum.GAME_START) {
            if (spawnTimer < spawnRate) {
                spawnTimer += Time.deltaTime;
            }
            else {
                SpawnPipes();
                spawnTimer = 0;
            }
        }
    }

    public void SpawnPipes() {
        float lowestPoint = pipes.transform.position.y - heightOffset;
        float highestPoint = pipes.transform.position.y + heightOffset;

        Vector3 newPipeTransform = new Vector3(this.transform.position.x, Random.Range(lowestPoint, highestPoint), 0);

        Instantiate(pipes, newPipeTransform, pipes.transform.rotation);
    }
}