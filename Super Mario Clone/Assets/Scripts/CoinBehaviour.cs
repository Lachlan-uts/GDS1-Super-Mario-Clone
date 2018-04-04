using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    private Rigidbody2D coinRB2D;
    private float previousHeight;
    private float newHeight;

    // Use this for initialization
    void Start()
    {
        coinRB2D = GetComponent<Rigidbody2D>();
        coinRB2D.constraints = RigidbodyConstraints2D.FreezePosition;
        newHeight = this.transform.position.y;
        previousHeight = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        previousHeight = newHeight;
        newHeight = this.transform.position.y;
        AfterJump();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            coinRB2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            coinRB2D.AddForce(Vector2.up * 5);
        }
    }

    void AfterJump()
    {
        if (newHeight < previousHeight)
        {
            Destroy(this.gameObject);
        }
    }
}
