using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    private Stats stats; 
    public Slider staminaBar;
    private float Stamina;
    private float maxStamina;
    private float staminareg;
    public float Speed;
    float Sprint;
    float SetSpeed;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    
    public bool Exhausted = false;
    public bool Walking = false;
    public bool Sprinting = false;
    public bool isGrounded;
    Rigidbody rb;
    Color oragne = new Color(255f/255f, 200f/255f, 0f/255f);
    Color green = new Color(0f/255f, 255f/255f, 0f/255f);

    void Start ()
    {
        stats = GetComponent<Stats>();
        maxStamina = stats.maxStamina;
        Speed = stats.Speed;
        staminareg = stats.sthregen;
        Stamina = stats.stamina;

        staminaBar.maxValue = maxStamina;
        staminaBar.value = Stamina;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        Sprint = Speed * 2;
        SetSpeed = Speed;
    }
	void Update ()
    {   
        jumpact();
        PlayerMovement();
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == 6 && !isGrounded)
        {
        isGrounded = true;
        
        

    }
    }

    void PlayerMovement()
    {
        Sprinting = false;
        if (Input.GetKey(KeyCode.LeftShift) && Stamina > 0)
        {   
            if ( Exhausted == false)
            {
            Speed = Sprint;
            Stamina = Stamina - 4 *  Time.deltaTime;
            Sprinting = true;
            if (Stamina < 0)
            {
                Exhausted = true;
            } 
            }
        }
        Stamina = Stamina + staminareg * Time.deltaTime;
        if (Stamina > maxStamina)
        {
            Stamina = maxStamina;
        }
        if (Stamina > Stamina/2)
        {
            Exhausted = false;
        }
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
        Speed = SetSpeed; 
        Walking = true;
        if (Sprinting == true)
        {
            Walking = false;
        }
        if (Walking == true)
        {
            Sprinting = false;
        }
        if (Exhausted == true)
        {
            
            staminaBar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = oragne;
        }
        else
        {
            staminaBar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = green;
        }
        staminaBar.value = Stamina;

    }
    void jumpact(){
        while(Input.GetKeyDown(KeyCode.Space) && isGrounded){

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}