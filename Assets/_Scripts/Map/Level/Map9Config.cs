using System.Collections;
using UnityEngine;

public class Map9Config : MapConfig
{
    private GameObject corpseIns;
    private Coroutine currentButtonCoroutine;
    private Coroutine currentGateCoroutine;

    private Vector2 offset = new Vector2(-0.002271198f, -0.01334077f);
    private Vector2 size = new Vector2(0.1236602f, 0.03167106f);
    private bool isGateOpen = false;

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

    public void OnPlayerEnterOnButton(Collider2D collider, TriggerPoint trigger)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (isGateOpen)
            {
                return;
            }

            Animator gateAnimator = gate.gameObject.GetComponent<Animator>();
            BoxCollider2D gateCollider = gate.gameObject.GetComponent<BoxCollider2D>();
            PlayGateDownLogic(gateAnimator, gateCollider);
            isGateOpen = true;
        }
    }

    public void OnPlayerEnterOnVoid(Collider2D collider, TriggerPoint trigger)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerWin();
        }
    }

    private void PlayGateDownLogic(Animator animator, BoxCollider2D gateCollider)
    {
        if (isGateOpen)
        {
            return;
        }

        if (currentGateCoroutine != null)
        {
            StopCoroutine(currentGateCoroutine);
        }

        currentGateCoroutine = StartCoroutine(PlayAni(animator, "GateDown", "GateIdleUp"));
        AdjustGateCollider(gateCollider);
    }

    private void AdjustGateCollider(BoxCollider2D gateCollider)
    {
        gateCollider.size = this.size;
        gateCollider.offset = this.offset;
        isGateOpen = true;
    }

    private IEnumerator PlayAni(Animator animator, string playState, string idleState)
    {
        animator.Play(playState);

        yield return null;

        while (true)
        {
            var info = animator.GetCurrentAnimatorStateInfo(0);

            if (info.IsName(playState) && info.normalizedTime >= 1f)
            {
                break;
            }

            yield return null;
        }

        animator.Play(idleState);
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
