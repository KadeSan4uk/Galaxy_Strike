using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;

    bool isFiring = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
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
    private void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
}
