using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.tag.Equals("Bound")) {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            if (collision.gameObject.GetComponent<Rocket>() != null)
            {
                if (collision.gameObject.GetComponent<Rocket>().rocketOne)
                {
                    Debug.Log("HIT");
                    StartCoroutine(GameManager.gm.PlayerOneScore());
                }
                else
                {
                    Debug.Log("HIT");
                    StartCoroutine(GameManager.gm.PlayerTwoScore());
                }
            }
        Destroy(collision.gameObject);
        }
    }
}
