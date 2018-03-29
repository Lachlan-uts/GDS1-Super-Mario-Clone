using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Renderer rend;
    private Collider2D thisCollider;
    enum Direction { Left, Right }
    Direction enemyDirection;

    private Camera cam;
    private Plane[] planes;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        rend = this.GetComponent<Renderer>();
        thisCollider = this.GetComponent<Collider2D>();
        enemyDirection = Direction.Left;
    }
	
	// Update is called once per frame
	void Update () {
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(planes, thisCollider.bounds))
        {
            Move();
        }
    }

    void Move()
    {
        if (rend.isVisible)
        {
            if (enemyDirection == Direction.Left)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime);
            }
            else this.transform.Translate(Vector3.right * Time.deltaTime);
        }
    }

    Direction ReverseDirection (Direction dir)
    {
        if (dir == Direction.Left)
        {
            print("changed to Right");
            return dir = Direction.Right;
        }

        else {
            print("nothing");
            return dir = Direction.Left;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Pipe")
        {
            enemyDirection = ReverseDirection(enemyDirection);
        }
    }
}
