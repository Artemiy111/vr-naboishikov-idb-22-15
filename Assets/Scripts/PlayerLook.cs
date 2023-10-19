using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerLook : MonoBehaviour
{

  [SerializeField] private Camera playerCamera;
  //public float mouseSensitivity = 100f;

  [SerializeField] private float mouseXSensitivity = 100f;
  [SerializeField] private float mouseYSensitivity = 100f;

  private float xRotation = 0f;
  private float YRotation = 0f;

  private void Awake()
  {
    //Locking the cursor to the middle of the screen and making it invisible
    Cursor.lockState = CursorLockMode.Locked;

  }

  public void ProcessLook(Vector2 input)
  {
    float mouseX = input.x;
    float mouseY = input.y;

    xRotation -= mouseY * mouseYSensitivity * Time.deltaTime;
    xRotation = Mathf.Clamp(xRotation, -80, 80);

    playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

    transform.Rotate(mouseX * mouseXSensitivity * Time.deltaTime * Vector3.up);
  }

  // private void Update()
  // {
  //   float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
  //   float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

  //   //control rotation around x axis (Look up and down)
  //   xRotation -= mouseY;

  //   //we clamp the rotation so we cant Over-rotate (like in real life)
  //   xRotation = Mathf.Clamp(xRotation, -90f, 90f);

  //   //control rotation around y axis (Look up and down)
  //   YRotation += mouseX;

  //   //applying both rotations
  //   transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);

  // }
}