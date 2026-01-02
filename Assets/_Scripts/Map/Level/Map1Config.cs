using UnityEngine;

public class Map1Config : MonoBehaviour
{
    public void OnPlayerEnterOnSpike(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Ngu");
        }
    }
}
