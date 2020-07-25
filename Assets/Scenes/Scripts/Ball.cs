using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
  private Rigidbody2D rb;
  public float speed = 3.5f;
  private int moveX;
  private int moveY;
  private int speedMultiplier = 2;

  void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.name == "Player" || col.gameObject.name == "Enemy")
    {
      if (speed <= 10.5f)
      {
        speed += Time.deltaTime * speedMultiplier;
        speedMultiplier++;
      }
    }
    else if (col.gameObject.name == "EnemyWall" || col.gameObject.name == "PlayerWall")
    {
      SetInitialPosition();
      SetInitialMovement();
      setScore(col);
    }
    SetRandomMovement();
  }
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    Launch();
  }

  void Update()
  {
    // MOVE STUCK BALL
    if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.X))
    {
      SetInitialMovement();
    }
    // RESET BALL INITIAL POSITION
    if (Input.GetKey(KeyCode.R))
    {
      SetInitialPosition();
      SetInitialMovement();
    }

    // Change game scene 
    if (Input.GetKey(KeyCode.Escape))
    {

      SceneManager.LoadScene("MainMenu");
    }

    if (moveX == -1 && moveY == 0 || moveX == 1 && moveY == 0)
    {
      moveX = Random.Range(-1, 2);
      moveY = Random.Range(-1, 2);
    }
  }

  private void Launch()
  {
    SetRandomMovement();
  }

  private void SetRandomMovement()
  {
    moveX = Random.Range(-3, 3);
    moveY = Random.Range(-3, 3);
    if (moveX == 0) moveX = 1;
    if (moveY == 0) moveY = 1;
    rb.velocity = new Vector2(speed * moveX, speed * moveY);
  }

  private void SetInitialMovement()
  {
    if (Random.Range(-1, 2) >= 0)
    {
      moveX = 1;
      moveY = -1;
    }
    else
    {
      moveX = -1;
      moveY = 1;
    }
    rb.velocity = new Vector2(speed * moveX, speed * moveY);
  }

  private void SetInitialPosition()
  {
    transform.position = new Vector2(0, 0);
    speed = 3.5f;
    speedMultiplier = 2;
  }

  private void setScore(Collision2D col)
  {
    if (col.gameObject.name == "PlayerWall")
    {
      EnemyScoreScript.score += 1;
    }

    if (col.gameObject.name == "EnemyWall")
    {
      PlayerScoreScript.score += 1;
    }
  }
}