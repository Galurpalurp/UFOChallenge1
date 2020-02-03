﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody2D rb2d;
    private int count;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

    }


    public bool characterInQuicksand;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();
        }

    }
    void SetCountText()

    {
        countText.text = "Count: " + count.ToString();
        if (count == 12)
        {
            transform.position = new Vector2(50.0f, 50.0f);

        }
        else if (count >=20)
        {
            winText.text = "You Win! Game Created by Nadyah Al-Ghamdi";
        }

       
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


}