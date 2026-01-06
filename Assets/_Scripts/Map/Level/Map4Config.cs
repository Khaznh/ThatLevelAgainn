using UnityEngine;

public class Map4Config : MapConfig
{
    private GameObject corpseIns;

    private void Awake()
    {
        PlayerManager.Instance.player = Instantiate(playerPrefap, spawnPoint.transform.position, Quaternion.identity);
    }

    public void OnPlayerEnterOnSpike(Collider2D collider, TriggerPoint trigger)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerDie(collider.ClosestPoint(trigger.transform.position));
        }
    }

    public void OnPlayerEnterOnVoid(Collider2D collider, TriggerPoint trigger)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerWin();
        }
    }

    private void PlayerWin()
    {
        Destroy(PlayerManager.Instance.player);
        LevelManager.Instance.SpawnLevel();
        CameraManager.Instance.MoveCamera(LevelManager.Instance.mapLength);
    }

    private void PlayerDie(Vector2 hitPoint)
    {
        if (corpseIns != null)
        {
            Destroy(corpseIns);
        }

        corpseIns = Instantiate(corpseGO, hitPoint, Quaternion.identity);
        corpseIns.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        PlayerManager.Instance.player.transform.position = spawnPoint.transform.position;
    }
}
