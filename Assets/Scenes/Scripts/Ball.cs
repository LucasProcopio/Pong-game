using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  private Rigidbody2D rb;
  public float speed = 3.5f;
  private float moveX;

  private int speedMultiplier = 2;
  private float moveY;
  // Start is called before the first frame update

  void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.name == "Player" || col.gameObject.name == "Enemy")
    {
      if (speed <= 8.0f)
      {
        speed += Time.deltaTime * speedMultiplier;
        speedMultiplier++;
        Debug.Log("SPEED: " + speed);
      }
    }
    else if (col.gameObject.name == "EnemyWall" || col.gameObject.name == "PlayerWall")
    {
      SetInitialPosition();
      SetRandomMovement();
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
    if (Input.GetKey(KeyCode.P))
    {
      float x = speedMultiplier * Random.Range(1, 10);
      float y = speedMultiplier * Random.Range(-1, 15);
      rb.AddRelativeForce(new Vector2(x, y), ForceMode2D.Force);
    }
  }

  private void Launch()
  {
    SetRandomMovement();
  }

  private void SetRandomMovement()
  {
    moveX = Random.Range(0, 2) == 0 ? 1 : -1;
    moveY = Random.Range(0, 2) == 0 ? 1 : -1;
    rb.velocity = new Vector2(speed * moveY, speed * moveY);
  }

  private void SetInitialPosition()
  {
    transform.position = new Vector2(0, 0);
    speed = 3.5f;
    speedMultiplier = 2;
  }
}