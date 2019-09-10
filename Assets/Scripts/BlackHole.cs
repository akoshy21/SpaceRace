using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public int direction;
    public float speed;
    public float slowMod;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (direction == -1)
        {
            this.transform.position += new Vector3(-speed, 0, 0);
            this.transform.Rotate(0f, 0f, 3f, Space.Self);
        }
        else
        {
            this.transform.position += new Vector3(speed, 0, 0);
            this.transform.Rotate(0f, 0f, -3f, Space.Self);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Rocket>().speed *= slowMod;
            collision.gameObject.GetComponent<Rocket>().timestampL += 3;
            collision.gameObject.GetComponent<Rocket>().timestampR += 3;  
        }
        else if (collision.gameObject.tag.Equals("shield"))
        {
            direction *= -1;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Rocket>().speed /= slowMod;
        }
    }
}
