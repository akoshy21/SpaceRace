﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            if (collision.gameObject.GetComponent<Asteroid>().left)
            {
                collision.gameObject.GetComponent<Asteroid>().left = false;
            }
            else {
                collision.gameObject.GetComponent<Asteroid>().left = true;
            }
        }
    }
}