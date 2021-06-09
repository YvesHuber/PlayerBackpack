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
    Color oragne = new Color(255f / 255f, 200f / 255f, 0f / 255f);
    Color green = new Color(0f / 255f, 255f / 255f, 0f / 255f);

    void Start()
    {
        stats = GetComponent<Stats>();
        staminareg = stats.sthregen;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void Update()
    {
        Sprint = stats.Speed * 2;
        Sneak = stats.Speed / 4;
        staminaBar.maxValue = stats.maxStamina;
        staminaBar.value = stats.stamina;
        PlayerMovement();
        jumpact();
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
        Tempo = stats.Speed;
        Walking = true;
        Sprinting = false;
        Sneaking = false;
        stats.stamina = stats.stamina + stats.sthregen * Time.deltaTime;
        //Sneak
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Tempo = Sneak;
            Sneaking = true;
        }

        //Sprint
        if (Input.GetKey(KeyCode.R) && Exhausted == false)
        {
            //Stamina Minus
            Tempo = Sprint;
            Sprinting = true;
        }
        if (Sprinting == true) {
            stats.stamina = stats.stamina - 4 * Time.deltaTime;
            }
        if (stats.stamina < 0)
            {
                Exhausted = true;
            }
            if (stats.stamina > stats.maxStamina)
            {
                stats.stamina = stats.maxStamina;
            }
            if (stats.stamina >= stats.maxStamina / 2)
            {
                Exhausted = false;
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
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * Tempo * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
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