using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogCameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = GetComponent<Transform>();
        xRotation = cameraTransform.eulerAngles.x;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
    }
}
