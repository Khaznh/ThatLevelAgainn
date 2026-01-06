using UnityEngine;
using UnityEngine.EventSystems;

public class GateButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Map3Config config;
    [SerializeField] private Animator redB;

    public void OnPointerDown(PointerEventData eventData)
    {
        config.PlayButtonDownLogic(redB);
        config.PlayGateDownLogic(config.gate.GetComponent<Animator>(),config.gate.GetComponent<BoxCollider2D>());
    }
}
