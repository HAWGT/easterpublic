using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerScript : MonoBehaviour
{
    private float horizontalStatus;

    private float eggs = 0f;

    [SerializeField]
    private float horizontalSpeed = 30f;

    private float fuel = 0.25f;

    [SerializeField] private float fuelLimit = 0.25f;

    private bool facingRight = true;

    private bool jump;

    private float highestPosition = 0;

    private bool shield = false;

    private float hp = 3;

    [SerializeField] private float maxHP = 3;

    private float score = 0f;



    [SerializeField]
    private float jumpForce = 300f;


    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;
    private bool isGrounded = false;

    private GameObject shieldObj;
    private GameObject trailObj;

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Transform groundCheck;

    private Collider2D[] results = new Collider2D[1];

    public float GetHighestPosition()
    {
        return highestPosition;
    }

    private void Start()
    {
        shieldObj = GameObject.FindGameObjectWithTag("Shield");
        trailObj = GameObject.FindGameObjectWithTag("ParticleOrigin");
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().UpdateLives(hp);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Flip()
    {
        Vector3 myRotation = transform.localEulerAngles;
        myRotation.y += 180f;
        transform.localEulerAngles = myRotation;
        facingRight = !facingRight;
    }

    // Update is called once per frame
    private void Update()
    {
        //horizontalStatus = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        horizontalStatus = Input.acceleration.x;
        jump = Input.touchCount > 0;

        if (horizontalStatus < 0 && facingRight)
        {
            Flip();
        }

        if (horizontalStatus > 0 && !facingRight)
        {
            Flip();
        }

        //jump = CrossPlatformInputManager.GetButton("Jump");
        if (transform.position.y > highestPosition) highestPosition = transform.position.y;
        shieldObj.SetActive(shield);

        score = (int)(eggs * 100 + highestPosition * 20);

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().UpdateScore(score);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().UpdateFuel(fuel / fuelLimit);

    }

    public void PickUpEgg()
    {
        eggs++;
        GetComponent<AudioSource>().Play();
    }

    public void PickUpLife()
    {
        hp++;
        if (hp > maxHP) hp = maxHP;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().UpdateLives(hp);
        GetComponent<AudioSource>().Play();
    }
    public void PickUpShield()
    {
        shield = true;
        GetComponent<AudioSource>().Play();
    }

    public void TakeDamage()
    {
        if(shield)
        {
            shield = false;
            return;
        } else
        {
            hp--;
            if(hp <= 0)
            {
                hp = 0;
                Die();
            }
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().UpdateLives(hp);
        }
        groundCheck.GetComponent<AudioSource>().Play();
    }

    public void Die()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver(score);
    }

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = new Vector2(horizontalStatus * horizontalSpeed, myRigidbody2D.velocity.y);

        isGrounded = false;

        if (Physics2D.OverlapPointNonAlloc(groundCheck.position, results, groundLayerMask) > 0)
        {
            isGrounded = true;
        }

        trailObj.SetActive(false);

        if (jump)
        {
            if (fuel > 0f)
            {
                myRigidbody2D.velocity = new Vector2(horizontalStatus * horizontalSpeed, 0);
                myRigidbody2D.AddForce(transform.up * jumpForce);
                fuel -= 0.5f * Time.deltaTime;
                if (fuel < 0) fuel = 0;
                trailObj.SetActive(true);
            }
        } else
        {
            if (isGrounded) {
                fuel += 1f * Time.deltaTime;
                if (fuel > fuelLimit) fuel = fuelLimit;
            }
        }
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}

