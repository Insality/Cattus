﻿using UnityEngine;

public class Player : MonoBehaviour {
    public static int Money;
    public static int direction;
    public float objScale = 1;

    private void Start() {
        Money = 0;
        direction = 1; //  1: right;   -1:left;
        transform.localScale = new Vector3(objScale, objScale, objScale);
        rigidbody2D.AddForce(new Vector2(100, 0));
        Debug.Log(Camera.main.orthographicSize);
        Debug.Log(Camera.main.aspect*Camera.main.orthographicSize);
    }

    private void Update() {
        UpdateControl();
        //UpdateCollision();
//        Debug.Log(Screen.width);
//        Debug.Log(Screen.height);
    }

    /* private void UpdateCollision() {
        Debug.Log(Camera.main.WorldToScreenPoint(transform.position).x);
        if (Camera.main.ScreenToWorldPoint(transform.position).x > 600)
            Debug.Log("LOH");
    } */

    private void UpdateControl() {
        if ((Input.GetKeyUp(KeyCode.Space) && !Pause.isPaused) ||
            ((direction == 1) &&
             (gameObject.transform.position.x + (gameObject.renderer.bounds.size.x/2) >
              Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)) ||
            ((direction == -1) &&
             (gameObject.transform.position.x - (gameObject.renderer.bounds.size.x/2) <
              Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x))) {
            direction *= -1;
            rigidbody2D.AddForce(new Vector2(200*direction, 0));
            transform.localScale = new Vector3(objScale*direction, objScale, objScale);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Collider action");
        if (col != null) {
            if (col.gameObject.tag == "Enemy") {
                LevelManager.isGameOver = true;

            }
        }
    }

    // IsTrigger вызывает следующие методы: OnTriggerEnter, OnTriggerExit, OnTriggerStay
}