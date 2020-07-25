using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScoreScript : MonoBehaviour
{
  public static int score = 0;
  Text text;

  void Awake()
  {
    text = GetComponent<Text>();
  }
  void Update()
  {
    text.text = score.ToString();
  }
}
