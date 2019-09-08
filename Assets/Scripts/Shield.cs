using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float cooldown, initTime;
    Color tint;


    bool firstInit = true;

    private void Start()
    {
        Color tint = GetComponent<SpriteRenderer>().color;
        tint.a = 0.25f;
        this.GetComponent<SpriteRenderer>().color = tint;
    }

    private void Update()
    {
        if (this.GetComponent<BoxCollider2D>().enabled == true && firstInit == true)
        {
            initTime = Time.time + cooldown;
            firstInit = false;
        }

        if (firstInit == false && initTime <= Time.time)
        {
            Debug.Log("OOF");
            this.GetComponent<BoxCollider2D>().enabled = false;
            
            this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.25f) ;
            Debug.Log(GetComponent<SpriteRenderer>().color);
            firstInit = true;
        }

    }

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
