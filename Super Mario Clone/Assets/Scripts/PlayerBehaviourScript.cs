using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour {

    public float speed;
    public float baseSpeed;
    public float maxSpeed;
    public float jumpForce;
    public float jumpTime;
    public float jumpTimeCounter;
    public bool stoppedJumping;

    public bool grounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    float groundRadius = 0.1f;

    // serialized private variables
    [SerializeField]
    private GameObject fireball;

    // private variables

    private Rigidbody2D playerRB2D;

    private int healthState;

    private int livesCount;

    private bool facingRight;

    //Timer branch with Respawn
    public int currentHealth;
    bool isDead;
    bool damaged;
    //Small Mario & Big Mario
    bool bigMario;
    RespawnManager respawnManager;

    // Use this for initialization
    void Start() {

        playerRB2D = GetComponent<Rigidbody2D>();

        jumpTimeCounter = jumpTime;

        healthState = 0; // In short, take a single hit, death ensues
        livesCount = 3;
        currentHealth = livesCount;
        facingRight = true;

        respawnManager = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
    }

    // Update is called once per frame
    void Update() {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (grounded) {
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetMouseButtonDown(0)) {
            if (grounded) {
                playerRB2D.velocity = new Vector2(playerRB2D.velocity.x, jumpForce);
                stoppedJumping = false;
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        while (Input.GetMouseButtonUp(1) && (speed > baseSpeed)) {
            speed -= 0.5f;
        }
    }

    void FixedUpdate() {


        float move = Input.GetAxis("Horizontal");
        if (Input.GetMouseButton(1) && speed < maxSpeed && grounded) {
            speed += 0.5f;
        }

        playerRB2D.velocity = new Vector2(move * speed, playerRB2D.velocity.y);

        if ((Input.GetMouseButton(0)) && !stoppedJumping) {
            if (jumpTimeCounter > 0) {
                playerRB2D.velocity = new Vector2(playerRB2D.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        Debug.Log(currentHealth);
    }

    void test() {
        //Missing void name on my end - Rowena
        //A simple test to help test if the camera will move with the player object.
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            playerRB2D.AddForce(Vector2.right * 4, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            Debug.Log("Z");
            if (healthState >= 2) {
                CreateFireball();
                Debug.Log("Fire ball");
            }
        }
    }

    void CreateFireball() {
        GameObject newFireball = Instantiate(fireball, gameObject.transform.position, Quaternion.identity) as GameObject;
        if (facingRight) {
            newFireball.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 3.0f, ForceMode2D.Impulse);
        } else {
            newFireball.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 3.0f, ForceMode2D.Impulse);
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Powerup")
        { // If the player comes into contact with a powerup
            Debug.Log("CollisionWithPowerup");
            if (healthState == 0 && other.gameObject.GetComponent<PowerupBehaviourScript>().typeOfPower == 0)
            {
                healthState++;
                bigMario = true;
                Debug.Log("Mushroom");
            }
            else if (healthState < 2 && other.gameObject.GetComponent<PowerupBehaviourScript>().typeOfPower == 1)
            {
                healthState = 2;
                bigMario = true;
                Debug.Log("Fire Flower");
            }
            else if (other.gameObject.GetComponent<PowerupBehaviourScript>().typeOfPower == 2)
            {
                livesCount++;
                currentHealth++;
                Debug.Log("1-UP");
            }

        }
    }
    //Timer branch with Respawn, works with 1 up prefab and fireflower 
    public void takeDamage(int amount)
    {
        if (bigMario == false)
        {
            damaged = true;
            currentHealth -= amount;
            respawnManager.RespawnPlayer();
        }
        if (bigMario == true)
        {
            bigMario = false;
            healthState = 0;
        }
        if (currentHealth <= 0 && !isDead)
        {
            death();
        }
    }
    void death()
    {
        isDead = true;
        Debug.Log("Dead");
        //Restart Game


    }

    public bool isBig()
    {
        return bigMario;
    }
}
