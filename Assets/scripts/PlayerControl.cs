using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

  Rigidbody2D myRigidbody;
  float speed = 10;

  bool isGround = false;

  // Use this for initialization
  void Start()
  {
    myRigidbody = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    float horizontal = Input.GetAxis("Horizontal");
    myRigidbody.velocity = new Vector2(horizontal * speed, myRigidbody.velocity.y);


    if (Input.GetButtonDown("Jump") && isGround)
    {
      myRigidbody.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Ground"))
    {
      isGround = true;
      Debug.Log(isGround);
    }
    else if (other.CompareTag("Meat"))
    {
      Destroy(other.gameObject);
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Ground"))
    {
      isGround = false;
      Debug.Log(isGround);
    }
    else if (other.CompareTag("Meat"))
    {
      Destroy(other.gameObject);
    }
  }
}
