using UnityEngine;
using System.Collections;
using System.Drawing;

public class Map5Config : MapConfig
{
    private GameObject corpseIns;
    private Coroutine currentButtonCoroutine;
    private Coroutine currentGateCoroutine;

    private Vector2 offsetUp = new Vector2(-0.002271198f, -0.01334077f);
    private Vector2 sizeUp = new Vector2(0.1236602f, 0.03167106f);

    private Vector2 offsetDown = new Vector2(-0.002271198f, -0.2391409f);
    private Vector2 sizeDown = new Vector2(0.1236602f, 0.4832713f);
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
        if (collider.gameObject.CompareTag("Corpse"))
        {
            isGateOpen = true;
            Animator buttonAnimator = trigger.gameObject.GetComponent<Animator>();
            Animator gateAnimator = gate.gameObject.GetComponent<Animator>();
            BoxCollider2D gateCollider = gate.gameObject.GetComponent<BoxCollider2D>();
            PlayButtonDownLogic(buttonAnimator);
            PlayGateLogic(gateAnimator, gateCollider);
        }
    }

    public void OnPlayerExitOnButton(Collider2D collider, TriggerPoint trigger)
    {
        if (collider.gameObject.CompareTag("Corpse"))
        {
            isGateOpen = false;
            Animator animator = trigger.gameObject.GetComponent<Animator>();
            Animator gateAnimator = gate.gameObject.GetComponent<Animator>();
            BoxCollider2D gateCollider = gate.gameObject.GetComponent<BoxCollider2D>();
            PlayButtonUpLogic(animator);
            PlayGateLogic(gateAnimator, gateCollider);
        }
    }

    public void OnPlayerEnterOnVoid(Collider2D collider, TriggerPoint trigger)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerWin();
        }
    }

    private void PlayButtonDownLogic(Animator animator)
    {
        if (currentButtonCoroutine != null)
        {
            StopCoroutine(currentButtonCoroutine);
        }

        currentButtonCoroutine = StartCoroutine(PlayAni(animator, "RedButtonDown", "RedBInDown"));
    }

    private void PlayGateLogic(Animator animator, BoxCollider2D gateCollider)
    {
        if (currentGateCoroutine != null)
        {
            StopCoroutine(currentGateCoroutine);
        }

        if (isGateOpen)
        {
            currentGateCoroutine = StartCoroutine(PlayAni(animator, "GateDown", "GateIdleUp"));
            AdjustGateCollider(gateCollider, sizeUp, offsetUp);
        } else
        {
            currentGateCoroutine = StartCoroutine(PlayAni(animator, "GateUp", "GateIdleDown"));
            AdjustGateCollider(gateCollider, sizeDown, offsetDown);
        }

        
    }

    private void AdjustGateCollider(BoxCollider2D gateCollider, Vector2 size, Vector2 offset)
    {
        gateCollider.size = size;
        gateCollider.offset = offset;
        isGateOpen = true;
    }

    private void PlayButtonUpLogic(Animator animator)
    {
        if (currentButtonCoroutine != null)
        {
            StopCoroutine(currentButtonCoroutine);
        }

        currentButtonCoroutine = StartCoroutine(PlayAni(animator, "RedButtonUp", "RedBInUp"));
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
