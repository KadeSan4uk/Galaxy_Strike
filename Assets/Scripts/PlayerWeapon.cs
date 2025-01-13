using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject laser;

    bool isFiring = false;

    private void Update()
    {
        ProcessFiring();
    }
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        var emmisionModule = laser.GetComponent<ParticleSystem>().emission;
        emmisionModule.enabled = isFiring;
    }
}
