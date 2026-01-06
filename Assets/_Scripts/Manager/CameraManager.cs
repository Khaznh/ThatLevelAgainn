using System.Collections;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private Camera mainCamera;
    private float timer = 0;

    protected override void Awake()
    {
        base.Awake();

        mainCamera = Camera.main;
    }

    public void MoveCamera(float xOffset)
    {
        Vector3 newPos = new Vector3(mainCamera.transform.position.x + xOffset, mainCamera.transform.position.y, mainCamera.transform.position.z);
        StartCoroutine(MoveCameraCoroutine(newPos,1f));

    }

    private IEnumerator MoveCameraCoroutine(Vector3 tag, float duration)
    {
        timer = 0;

        while (timer <= 1f)
        {
            timer += Time.deltaTime / duration;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, tag, timer);
            yield return null;
        }
    }
}
