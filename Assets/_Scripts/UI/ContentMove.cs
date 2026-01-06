using DG.Tweening;
using UnityEngine;

public class ContentMove : MonoBehaviour
{
    [SerializeField] private Vector2 originPos;
    [SerializeField] private Vector2 goatPos;
    [SerializeField] private float moveSpeed = 2f;

    private RectTransform rect;

    private void Awake()
    {
        rect = transform.GetComponentInChildren<RectTransform>();    
    }

    private void OnEnable()
    {
        MoveContentToGoatPos();
    }

    private void MoveContentToGoatPos()
    {
        rect.DOAnchorPos(goatPos, moveSpeed).SetUpdate(true);
    }

    public void MoveContentToOriginPos()
    {
        rect.DOAnchorPos(originPos, moveSpeed).SetUpdate(true); 
    }
}
