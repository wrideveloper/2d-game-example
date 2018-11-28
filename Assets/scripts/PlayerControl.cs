using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
  public Text scoreText;

  Rigidbody2D myRigidbody;
  float speed = 10;

  bool isGround = false;

  int score = 0;

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
    }
    else if (other.CompareTag("Meat"))
    {
      int index = Random.Range(0, 4);
      other.transform.position = meatPosition[index];
      score++;

      scoreText.text = score.ToString();
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Ground"))
    {
      isGround = false;
    }
  }
}
