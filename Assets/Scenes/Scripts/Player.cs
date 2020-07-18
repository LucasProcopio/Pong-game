using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float speed;
  private Rigidbody2D rb2d;

  private Vector2 moveamount;
  private void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
  }
  void Update()
  {
    Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    moveamount = movement.normalized * speed;
  }

  private void FixedUpdate()
  {
    rb2d.MovePosition(rb2d.position + moveamount * Time.fixedDeltaTime);
  }
}
