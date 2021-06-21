using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    private Stats stats;
    public Slider staminaBar;
    public Slider healthBar;
    private bool firstButtonPressed;
    private bool reset;
    private float timeOfFirstButton;
    private float staminareg;
    public float Sneak;
    public float Sprint;
    public float Tempo;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool Exhausted = false;
    public bool Walking = false;
    public bool Sprinting = false;
    public bool Sneaking = false;
    public bool isGrounded;
    Rigidbody rb;
    Color orange = new Color(255f / 255f, 200f / 255f, 0f / 255f);
    Color green = new Color(0f / 255f, 255f / 255f, 0f / 255f);

    //get rigidbody and jump
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    //calculate speed values and execute movement
    void Update()
    {
        stats = GetComponent<Stats>();
        staminareg = stats.sthregen;
        Sprint = stats.Speed * 2;
        Sneak = stats.Speed / 4;
        staminaBar.maxValue = stats.maxStamina;
        staminaBar.value = stats.stamina;
        PlayerMovement();
        jumpact();
        Sethealthbar();
    }

    //set the value of the healthbar
    void Sethealthbar()
    {
        stats.hp += 0.1f * Time.deltaTime;
        healthBar.value = stats.hp;
        if (stats.hp >= stats.maxHP)
        {
            stats.hp = stats.maxHP;
        }
        healthBar.maxValue = stats.maxHP;

    }

    //checks grounded on collision with ground layer to jump
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 && !isGrounded)
        {
            isGrounded = true;
        }
    }
    //general movement no jump
    void PlayerMovement()
    {
        //clear booleans and add stamina
        Tempo = stats.Speed;
        Walking = true;
        Sprinting = false;
        Sneaking = false;
        stats.stamina = stats.stamina + stats.sthregen * Time.deltaTime;
        //Sneak with shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Tempo = Sneak;
            Sneaking = true;
        }

        //Sprint with R
        if (Input.GetKey(KeyCode.R) && Exhausted == false)
        {
            Tempo = Sprint;
            Sprinting = true;
        }
        //while sprinting remove stamina
        if (Sprinting == true)
        {
            stats.stamina = stats.stamina - 4 * Time.deltaTime;
        }
        //when stamina hits 0 get exhausted
        if (stats.stamina < 0)
        {
            Exhausted = true;
        }
        //cap stamina at maxstamina
        if (stats.stamina > stats.maxStamina)
        {
            stats.stamina = stats.maxStamina;
        }
        //when stamina is back to half exhausted is false
        if (stats.stamina >= stats.maxStamina / 2)
        {
            Exhausted = false;
        }
        //set color of the stamina bar to the status of Exhausted
        if (Exhausted == true)
        {
            staminaBar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = orange;
        }
        else
        {
            staminaBar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = green;
        }
        //calculate the force and position
        staminaBar.value = stats.stamina;
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Tempo * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    //jump action
    void jumpact()
    {
        while (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}