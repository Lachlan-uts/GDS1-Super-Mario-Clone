using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    private Rigidbody2D coinRB2D;

    // Use this for initialization
    void Start()
    {
        coinRB2D = GetComponent<Rigidbody2D>();
        coinRB2D.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            coinRB2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            coinRB2D.AddForce(Vector2.up * 2);
        }
    }
}
