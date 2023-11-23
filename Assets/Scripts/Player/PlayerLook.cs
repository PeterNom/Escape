using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera playerCamera;
    public Transform playerWeapon;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    private float rotateTo = 0f;

    // Update is called once per frame
    public void ProcessLook(Vector2 mouseInput)
    {
        float mouseInputX = mouseInput.x;
        float mouseInputY = mouseInput.y;

        rotateTo -= (mouseInputY * Time.deltaTime ) * ySensitivity ;
        rotateTo = Mathf.Clamp(rotateTo, -80.0f, 80.0f);

        playerCamera.transform.localRotation = Quaternion.Euler(rotateTo, 0f, 0f);
        playerWeapon.localRotation = Quaternion.Euler(rotateTo, 0f, 0f);

        transform.Rotate(Vector3.up * (mouseInputX * xSensitivity) * Time.deltaTime);
    }
}
