using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerCamara : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public GameObject ThirdPersonCam;
    public GameObject CombatCam;
    public float rotationSpeed;


    public CameraStyle currentStyle;

    public Transform combatLookAt; 

    public enum CameraStyle
    {
        Basic,
        combat
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchCameraStyle(CameraStyle.Basic);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchCameraStyle(CameraStyle.combat);
        // rotar orientacion
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchCameraStyle(CameraStyle.Basic);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchCameraStyle(CameraStyle.combat);

        if (currentStyle == CameraStyle.Basic)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
        }
    
    
        else if (currentStyle == CameraStyle.combat)
        {
            Vector3 dirCombatToLook = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirCombatToLook.normalized;

            playerObj.forward = dirCombatToLook.normalized;
        }
            
    }

    private void SwitchCameraStyle(CameraStyle newStyle)
    {
        CombatCam.SetActive(false);
        ThirdPersonCam.SetActive(false);

        if (newStyle == CameraStyle.Basic) ThirdPersonCam.SetActive(true);
        if (newStyle == CameraStyle.combat) CombatCam.SetActive(true);

        currentStyle = newStyle;
    }
}
