using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100;

    bool isFiring = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach (var laser in lasers)
        {
            var emmissionLeftModule = laser.GetComponent<ParticleSystem>().emission;
            emmissionLeftModule.enabled = isFiring;
        }
    }

    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers()
    {
        foreach (var laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;// вычесление Вектора направления от лазеров до таргета. 
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);// вычесление угла(ротации) лазеров корабля в сторону таргета
            laser.transform.rotation = rotationToTarget;// сам поворот ласера в сторону таргета
        }
    }
}
