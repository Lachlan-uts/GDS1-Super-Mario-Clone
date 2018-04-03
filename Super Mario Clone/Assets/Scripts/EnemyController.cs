using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Renderer rend;
    private Collider2D thisCollider;
    private Camera cam;
    private Plane[] planes;
    enum Direction { Left, Right }
    Direction enemyDirection;

    public float moveSpeed;
    private bool moveRight;

    public bool squash;
    public Transform squashCheck;
    private float squashCheckRadius = .2f;
    public LayerMask whatIsPlayer;


    public Transform wallCheck;
    private float wallCheckRadius = 0.1f;
    public LayerMask whatIsWall;
    private bool hitWall;

    public bool grounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    float groundRadius = 0.1f;

    void Start()
    {
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        rend = this.GetComponent<Renderer>();
        thisCollider = this.GetComponent<Collider2D>();
        enemyDirection = Direction.Left;
        squash = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && !squash)
        {
            Debug.Log("If Player is Small, Player Dies, if Player is Super lose a power up");
            Destroy(other.gameObject);
            //Have a manager to manage the respawn of the player
            //gameManager.RespawnPlayer ();
        }
        if (other.name == "Player" && squash)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

        squash = Physics2D.OverlapCircle(squashCheck.position, squashCheckRadius, whatIsPlayer);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        hitWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(planes, thisCollider.bounds))
        {
            Debug.Log("Working");
            Move();
        }

        if (hitWall)
        {
            moveRight = !moveRight;
        }


    }

    void Move()
    {
        if (rend.isVisible)
        {
            if (enemyDirection == Direction.Left)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            }
            else this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);

            /*if (moveRight)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }*/
        }
    }
}
