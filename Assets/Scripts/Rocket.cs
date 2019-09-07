using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public bool rocketOne;
    public float speed;

    public GameObject leftShield, rightShield;

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

            if (Input.GetKeyDown(KeyCode.A))
            {
                leftShield.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                rightShield.SetActive(true);
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
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                leftShield.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rightShield.SetActive(true);
            }
        }
    }
}
