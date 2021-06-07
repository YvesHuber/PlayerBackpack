using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraControl : MonoBehaviour
{
    float rotationSpeed = 1f;
    public Transform Target, Player;
    float mouseX, mouseY;
    bool looking = true;
    public Transform Obstruction;
    float zoomSpeed = 2f;
    
    void Start()
    {
        Obstruction = Target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
    }
    

    void CamControl()
    {   
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -60, 60);

        if (Input.GetMouseButton(1))
        {
            looking = false;
            if (looking == false)
            {
            transform.LookAt(Player);
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);                
            }
        }
        else
        {
            looking = true;
        }
        if (looking == true)
        {
        transform.LookAt(Target);
        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
    
}