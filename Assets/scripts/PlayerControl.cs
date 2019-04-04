using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  Rigidbody2D myRigidbody;
  Animator myAnimator;
  float speed = 10;
  public bool isGround = false;
  Vector3[] meatPosition = {
    new Vector3(15.28F, 8.4F, 0),
    new Vector3(-11.5F, 8.7F, 0),
    new Vector3(6.2F, 4.4F, 0),
    new Vector3(-6, 0.7F, 0),
    new Vector3(-13.9F, -3.1F, 0)
  };

  // Use this for initialization
  void Start()
  {
    myRigidbody = GetComponent<Rigidbody2D>();
    myAnimator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    float horizontal = Input.GetAxis("Horizontal");
    myRigidbody.velocity = new Vector2(horizontal * speed, myRigidbody.velocity.y);

    if (Input.GetButtonDown("Jump") && isGround)
    {
      Jump();
    }
  }

  void Jump()
  {
    myRigidbody.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Ground"))
    {
      isGround = true;
      myAnimator.SetBool("jump", false);
    }
    else if (other.CompareTag("Meat"))
    {
      int index = Random.Range(0, 4);
      other.transform.position = meatPosition[index];

      GameControl.AddScore();
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Ground"))
    {
      isGround = false;
      myAnimator.SetBool("jump", true);
    }
  }
}
