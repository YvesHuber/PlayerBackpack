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
    float Sprint;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public float Sneak;
    public bool Exhausted = false;
    public bool Walking = false;
    public bool Sprinting = false;
    public bool Sneaking = false;
    public bool isGrounded;
    Rigidbody rb;
    Color oragne = new Color(255f / 255f, 200f / 255f, 0f / 255f);
    Color green = new Color(0f / 255f, 255f / 255f, 0f / 255f);

    void Start()
    {
        stats = GetComponent<Stats>();
        staminareg = stats.sthregen;


        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        Sprint = stats.Speed * 2;
    }
    void Update()
    {
        Sprint = stats.Speed * 2;
        Sneak = stats.Speed / 4;
        staminaBar.maxValue = stats.maxStamina;
        staminaBar.value = stats.stamina;
        jumpact();
        PlayerMovement();
        Sethealthbar();
    }

    void Sethealthbar(){
        stats.hp += 0.1f * Time.deltaTime;
        healthBar.value = stats.hp;
        if (stats.hp >= stats.maxHP)
        {
            stats.hp =stats.maxHP;
        }
        healthBar.maxValue = stats.maxHP;

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 && !isGrounded)
        {
            isGrounded = true;
        }
    }

    void PlayerMovement()
    {
        Sprinting = false;
        //Sneak
        if (Input.GetKey(KeyCode.LeftShift))
        {
            stats.Speed = Sneak;
            Sneaking = true;
        }

        //Sprint
        if (Input.GetKeyDown(KeyCode.W) && firstButtonPressed)
        {
            if (Time.time - timeOfFirstButton < 0.5f)
            {
                Debug.Log("Sprint");
                if (Exhausted == false && stats.stamina > 0)
                {
                    stats.Speed = Sprint;
                    stats.stamina = stats.stamina - 4 * Time.deltaTime;
                    Sprinting = true;
                    if (stats.stamina < 0)
                    {
                        Exhausted = true;
                    }
                }
                reset = true;
            }
        }

            if (Input.GetKeyDown(KeyCode.W) && !firstButtonPressed)
            {
                firstButtonPressed = true;
                timeOfFirstButton = Time.time;
            }

            if (reset)
            {
                firstButtonPressed = false;
                reset = false;
            }

            stats.stamina = stats.stamina + staminareg * Time.deltaTime;
            if (stats.stamina > stats.maxStamina)
            {
                stats.stamina = stats.maxStamina;
            }
            if (stats.stamina > stats.stamina / 2)
            {
                Exhausted = false;
            }
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * stats.Speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
            stats.Speed = stats.Speed;
            Walking = true;
            if (Sprinting == true || Sneaking == true)
            {
                Walking = false;
            }
            if (Walking == true)
            {
                Sprinting = false;
                Sneaking = false;
            }
            if (Exhausted == true)
            {

                staminaBar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = oragne;
            }
            else
            {
                staminaBar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = green;
            }
            staminaBar.value = stats.stamina;

        }
        void jumpact()
        {
            while (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {

                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }