

using UnityEngine;
using System.Collections;

public class ControladorDePersonagem : MonoBehaviour {

    //This variable indicates how is the current state of character.
    private int estado;

    //This variable indicates if the player is aiming or not.
    private bool mirando; 

    //Define the turning speed.
    private float velocidadeDeGiro = 4.0f;
    

    private float horizontal;

    private Animator animacao;
    private Vector3 centroDaTela;
    private CursorLockMode mouseTrancado;
    

    public bool bloqueiaControle;

    public float WalkSpeed = 1.0f;
    public float RunSpeed = 5.0f;

    //Get the camera properties.
    public Camera camera; 

    void Start ()
    {
        centroDaTela.x = 0.5f;
        centroDaTela.y = 0.5f;
        centroDaTela.z = 0f;
        animacao = GetComponentInChildren<Animator>();
        estado = 0;
        mirando = false;
        bloqueiaControle = false;
        horizontal = transform.eulerAngles.y;
    }

    void Update ()
    {
        FocoRaycast();
        if (bloqueiaControle == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Controle();
        }
        MovePersonagem();
        FocoCamera();
    }



    private void Controle()
    {
        /*
        Estado:
        01 = Walking
        02 = Running
        03 = Walking Back
        04 = Walking Right
        05 = Walking Left
        */

        if (Input.GetKeyDown("w"))
        {
            estado = 1;
        }
        if (Input.GetKeyUp("w") && estado == 1)
        {
            estado = 0;
            if (Input.GetKey("s")) { estado = 3; }
            if (Input.GetKey("a")) { estado = 5; }
            if (Input.GetKey("d")) { estado = 4; }
        }
        if (Input.GetKeyUp("w") && estado == 2)
        {
            estado = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && estado == 1)
        {
            estado = 2;
            if (mirando == true)
            {
                mirando = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && estado == 2) { estado = 1; }
                
        if (Input.GetKeyDown("s"))
        {
            estado = 3;
        }
        if (Input.GetKeyUp("s") && estado == 3)
        {
            estado = 0;
            if (Input.GetKey("a")) { estado = 5; }
            if (Input.GetKey("d")) { estado = 4; }
            if (Input.GetKey("w")) { estado = 1; }
        }

        if (Input.GetKeyDown("d"))
        {
            estado = 4;
        }
        if (Input.GetKeyUp("d") && estado == 4)
        {
            estado = 0;
            if (Input.GetKey("s")) { estado = 3; }
            if (Input.GetKey("a")) { estado = 5; }
            if (Input.GetKey("w")) { estado = 1; }

        }

        if (Input.GetKeyDown("a"))
        {
            estado = 5;
        }
        if (Input.GetKeyUp("a") && estado == 5)
        {
            estado = 0;
            if (Input.GetKey("s")) { estado = 3; }
            if (Input.GetKey("d")) { estado = 4; }
            if (Input.GetKey("w")) { estado = 1; }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            mirando = true;
            if (estado == 2)
            {
                estado = 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1)) { mirando = false; }
    }

    private void FocoCamera()
    {
        if (mirando == true && camera.fieldOfView > 37)
        {
            camera.fieldOfView = camera.fieldOfView - 65.0f * Time.deltaTime;
        }
        if (mirando == false && camera.fieldOfView < 60)
        {
            camera.fieldOfView = camera.fieldOfView + 65.0f * Time.deltaTime;
        }
    }

    private void FocoRaycast()
    {
        RaycastHit hitInfo;
        Ray cameraRay = camera.ViewportPointToRay(centroDaTela);
    }
    
    private void MovePersonagem()
    {
        var mouseHorizontal = Input.GetAxis("Mouse X");
        horizontal = (horizontal + velocidadeDeGiro * mouseHorizontal) % 360f;
        transform.rotation = Quaternion.AngleAxis(horizontal, Vector3.up);

        float runningSpeed = 0f;

        // Jeżeli kuca (animacja) to nie może się poruszać
        if (animacao.GetCurrentAnimatorStateInfo(0).IsName("HumanoidCrouchIdle")) return;

        if (estado == 0) { transform.Translate(0, 0, 0); runningSpeed = 0f; }
        if (estado == 1) { transform.Translate(0, 0, WalkSpeed * Time.deltaTime); runningSpeed = 0f; }
        if (estado == 2) { transform.Translate(0, 0, RunSpeed * Time.deltaTime); runningSpeed = 1f; }
        if (estado == 3) { transform.Translate(0, 0, -WalkSpeed * Time.deltaTime); }
        if (estado == 4) { transform.Translate(0f * Time.deltaTime, 0, 0); }
        if (estado == 5) { transform.Translate(-0f * Time.deltaTime, 0, 0); }

        animacao.SetFloat("Direction", Input.GetAxis("Mouse X"), 2f, Time.deltaTime * 10f);
        animacao.SetFloat("Speed", Input.GetAxis("Vertical") + runningSpeed, 0.1f, Time.deltaTime * 10f);
    }

    public bool RetornaMirando()
    {
        return mirando;
    }
}
