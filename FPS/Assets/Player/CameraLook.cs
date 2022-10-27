using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    
    [SerializeField] private float sensitivity = 100f;
    
    private float _mouseX;
    private float _mouseY;

    private float _xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        
        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * _mouseX);
    }
}
