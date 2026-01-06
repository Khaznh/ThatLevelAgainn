using UnityEngine;

public class PlayerCorpse : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rid = gameObject.GetComponent<Rigidbody2D>();
        rid.linearVelocity = Vector3.zero;
        rid.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
