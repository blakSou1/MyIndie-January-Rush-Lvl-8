using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Header("Настройки вращения")]
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    [SerializeField] private float rotationSpeed = 90f;

    void Update()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);

        // ИЛИ по осям отдельно
        // transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0); // По X
        // transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); // По Y
        // transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); // По Z
    }
}
