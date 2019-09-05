using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public bool left;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            this.transform.position += new Vector3(-speed, 0, 0);
        }
        else {
            this.transform.position += new Vector3(speed, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rocket>() != null)
        {
            if (collision.gameObject.GetComponent<Rocket>().rocketOne)
            {
                StartCoroutine(GameManager.gm.PlayerOneHit());
            }
            else
            {
                StartCoroutine(GameManager.gm.PlayerTwoHit());
            }
            Destroy(collision.gameObject);
        }
    }
}
