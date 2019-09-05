using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public bool rocketOne;

    private void Update()
    {
        if (rocketOne)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.position += new Vector3(0, 1, 0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.transform.position += new Vector3(0, -1, 0);
            }
        }
        else {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.position += new Vector3(0, 1, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.position += new Vector3(0, -1, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bound"))
        {
            if (rocketOne)
            {
                StartCoroutine(GameManager.gm.PlayerOneScore());
            }
            else {
                StartCoroutine(GameManager.gm.PlayerTwoScore());
            }
            Destroy(this);
        }
        else if(collision.gameObject.tag.Equals("Asteroid"))
        {
            if (rocketOne)
            {
                StartCoroutine(GameManager.gm.PlayerOneHit());
            }
            else {
                StartCoroutine(GameManager.gm.PlayerTwoHit());
            }
            Destroy(this);
        }
    }
}
