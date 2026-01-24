using System.Collections;
using UnityEngine;

public class MoveableBalatro : MoveableBase
{
    private Vector2 velocity; // Текущая скорость
    public float maxVelocity; // Максимальная скорость

    public override IEnumerator Move(Vector3 target)
    {
        targetPosition = target;

        bool isMoving = true;
        float arrivalThreshold = 1f;

        while (isMoving && Vector2.Distance(transform.localPosition, targetPosition) > arrivalThreshold)
        {
            float realDt = Mathf.Clamp(Time.smoothDeltaTime, 1 / 50f, 1 / 100f);
        
            float expTimeXY = Mathf.Exp(-50 * realDt);

            MoveXY(realDt, expTimeXY);

            yield return null;
        }

        int index = G.roomManager.rooms.IndexOf(entity.state.room);
        G.roomManager.rooms[index + 1].AddEntity(entity);
    }

    private void MoveXY(float dt, float expTimeXY)
    {
        Vector2 T = targetPosition; // Целевая позиция
        Vector2 currentPos = new(transform.localPosition.x, transform.localPosition.y); // Текущая позиция

        float currentMaxVelocity = maxVelocity * dt;

        // Применяем экспоненциальное затухание к скорости
        velocity = expTimeXY * velocity + (1 - expTimeXY) * 35 * dt * (T - currentPos);

        velocity = Vector2.ClampMagnitude(velocity, currentMaxVelocity);
        
        // Ограничиваем скорость
        if (velocity.sqrMagnitude > maxVelocity * maxVelocity)
            velocity = velocity.normalized * maxVelocity;

        // Обновляем позицию
        transform.localPosition += 100f * dt * (Vector3)velocity;
    }
}

//public class MoveableSmoothDamp : MoveableBase
//{
//    private Vector3 velocity;
//    public float smoothTime = 0.3F;
//    public float maxVelocity = 10f;
//    private Vector3 currentVelocity;

//    void Start()
//    {
//        targetPosition = transform.position;
//    }

//    protected override void PausableUpdate()
//    {
//        MoveXY();
//    }

//    protected void MoveXY()
//    {
//        if (Vector3.Distance(transform.position, targetPosition) > 0.01f || velocity.magnitude > 0.01f)
//        {
//            Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime, maxVelocity, Time.deltaTime);
//            velocity = (newPosition - (Vector3)transform.position) / Time.deltaTime;

//            if (velocity.sqrMagnitude > maxVelocity * maxVelocity)
//            {
//                velocity = velocity.normalized * maxVelocity;
//            }

//            transform.position = newPosition + velocity * Time.deltaTime;
//            if (Vector3.Distance((Vector3)transform.position, targetPosition) < 0.01f && velocity.magnitude < 0.01f)
//            {
//                transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
//                velocity = Vector3.zero;
//            }
//        }
//    }
//}

public class MoveableBase : ManagedBehaviour
{
    public Vector3 targetPosition;
    public Entity entity;

    public virtual IEnumerator Move(Vector3 target)
    {
        return null;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(targetPosition, 0.2f);
    }
}