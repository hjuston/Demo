using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //This variable indicates if the player is aiming or not.
    private bool aiming;
    private Animator animator;
    private CursorLockMode mouseTrancado;

    public Camera camera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var runInput = Input.GetAxis("Sprint");

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            aiming = true;
            // speed / 10
        }
        if (Input.GetKeyUp(KeyCode.Mouse1)) { aiming = false; }

        float aimingValue = (aiming) ? 0.3f : 1f;
        animator.SetFloat("Speed", (verticalInput + runInput) * aimingValue);
        animator.SetFloat("Direction", horizontalInput);

        CameraAiming();
    }

    private void CameraAiming()
    {
        if (aiming == true && camera.fieldOfView > 37)
        {
            camera.fieldOfView = camera.fieldOfView - 65.0f * Time.deltaTime;
        }
        if (aiming == false && camera.fieldOfView < 60)
        {
            camera.fieldOfView = camera.fieldOfView + 65.0f * Time.deltaTime;
        }
    }
}
