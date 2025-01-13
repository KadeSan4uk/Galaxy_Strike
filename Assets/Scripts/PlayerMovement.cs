using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 20f;

    [SerializeField] float controllRollFactor = 20f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float controllPitchFactor = 20f;

    Vector2 movement;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float roll = -controllRollFactor * movement.x;
        float pitch = -controllPitchFactor * movement.y;

        Quaternion targetSidesRotation = Quaternion.Euler(pitch, 0f, roll);

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetSidesRotation, rotationSpeed * Time.deltaTime);
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

}
