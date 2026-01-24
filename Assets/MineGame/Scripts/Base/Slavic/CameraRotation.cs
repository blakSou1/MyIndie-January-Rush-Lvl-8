using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{

    [SerializeField] private float rotationDuration = 0.5f;
    [SerializeField] private AnimationCurve rotationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    private bool isRotating = false;

    public void MoveAndRotationCamera(InputAction.CallbackContext obj)
    {
        if(!isRotating)
            StartCoroutine(MoveAndRotate(90f));
    }
    private IEnumerator MoveAndRotate(float angle)
    {
        isRotating = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, angle, 0);
        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            float t = elapsedTime / rotationDuration;

            float curveValue = rotationCurve.Evaluate(t);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, curveValue);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        isRotating = false;
    }

}
