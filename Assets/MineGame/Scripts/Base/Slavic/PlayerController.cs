using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public List<Transform> positionTargetMoveCamera;

    public float speed = .5f;

    public void MoveAndRotationCamera(Transform start, Transform end)
    {
        StartCoroutine(MoveAndRotate(start, end));
    }
    public void MoveAndRotationCamera(int startIndex, int endIndex)
    {
        StartCoroutine(MoveAndRotate(positionTargetMoveCamera[startIndex], positionTargetMoveCamera[endIndex]));
    }

    private IEnumerator MoveAndRotate(Transform start, Transform end)
    {
        float startTime = Time.time;

        while (Time.time - startTime < speed)
        {
            float fractionOfJourney = Mathf.Clamp01((Time.time - startTime) / speed);

            transform.position = Vector3.Lerp(start.position, end.position, fractionOfJourney);
            transform.rotation = Quaternion.Slerp(start.rotation, end.rotation, fractionOfJourney);

            yield return null;
        }

        transform.position = end.position;
        transform.rotation = end.rotation;
    }

}
