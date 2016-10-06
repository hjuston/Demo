
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private float vertical;
    private float horizontal;
    private float velcoidadeDeGiro = 4.0f;
    void Start ()
    {
        vertical = transform.eulerAngles.x;
    }
	
	void Update ()
    {
        var mouseVertical = Input.GetAxis("Mouse Y");
        vertical = (vertical - velcoidadeDeGiro * mouseVertical) % 360f;
        vertical = Mathf.Clamp(vertical, -30, 60);

        var mouseHorizontal = Input.GetAxis("Mouse X");
        horizontal = (horizontal + velcoidadeDeGiro * mouseHorizontal) % 360f;
        horizontal = Mathf.Clamp(horizontal, -30, 60);
        transform.localRotation = Quaternion.Euler(vertical, horizontal, 0);
    }
}
