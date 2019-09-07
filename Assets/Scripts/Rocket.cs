using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public bool rocketOne;
    public float speed;

    Color shield;

    public GameObject leftShield, rightShield;

    public float timestampL, timestampR, cooldownDelay;

    private void Start()
    {
        shield = new Color(255, 255, 255, 255);
    }

    private void Update()
    {
        if (rocketOne)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.position += new Vector3(0, speed, 0);
                Debug.Log("Up");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.transform.position += new Vector3(0, -speed, 0);
                Debug.Log("Down");
            }
            
            if (Input.GetKeyDown(KeyCode.A) && timestampL <= Time.time)
            {
                leftShield.GetComponent<SpriteRenderer>().color = shield; // 85 tinted
                leftShield.GetComponent<BoxCollider2D>().enabled = true;
                timestampL = Time.time + cooldownDelay;
            }

            if (Input.GetKeyDown(KeyCode.D) && timestampR <= Time.time)
            {
                rightShield.GetComponent<SpriteRenderer>().color = shield;
                rightShield.GetComponent<BoxCollider2D>().enabled = true;
                timestampR = Time.time + cooldownDelay;

            }
        }
        else {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.position += new Vector3(0, speed, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.position += new Vector3(0, -speed, 0);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && timestampL <= Time.time)
            {
                leftShield.GetComponent<SpriteRenderer>().color = shield; // 85 tinted
                leftShield.GetComponent<BoxCollider2D>().enabled = true;
                timestampL = Time.time + cooldownDelay;
 
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && timestampR <= Time.time)
            {
                rightShield.GetComponent<SpriteRenderer>().color = shield;
                rightShield.GetComponent<BoxCollider2D>().enabled = true;
                timestampR = Time.time + cooldownDelay;
            }
        }
    }
}
