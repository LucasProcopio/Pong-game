using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float speed;
  private Rigidbody2D rb2d;
  private Vector2 targetpos;
  private Vector2 moveamount;
  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
  }
  void FixedUpdate()
  {
    if (Input.GetKey(KeyCode.Z))
    {
      targetpos = Vector2.left;
      //transform.Translate(targetpos.x, targetpos.y, 0);
      moveamount = targetpos.normalized * speed;
      rb2d.MovePosition(rb2d.position + moveamount * Time.fixedDeltaTime);
    }
    else if (Input.GetKey(KeyCode.C))
    {
      targetpos = Vector2.right;
      //transform.Translate(targetpos.x, targetpos.y, 0);
      moveamount = targetpos.normalized * speed;
      rb2d.MovePosition(rb2d.position + moveamount * Time.fixedDeltaTime);
    }
  }
}
