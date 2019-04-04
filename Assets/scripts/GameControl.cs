using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{
  static Text scoreText;
  static int score = 0;

  void Start()
  {
    scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
  }

  public static void AddScore()
  {
    score++;
    scoreText.text = score.ToString();
  }
}
