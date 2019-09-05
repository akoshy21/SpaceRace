using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public float timer, currentTime;

    public GameObject rocketPrefab;

    public GameObject rocketOne, rocketTwo;
    public Text scoreOneText, scoreTwoText;
    public int scoreOne, scoreTwo;

    public Image fillBar;

    Vector3 posOne, posTwo;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(this);
        }
        else if (gm != this && gm != null)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        posOne = rocketOne.transform.position;
        posTwo = rocketTwo.transform.position;

        currentTime = timer;
        InvokeRepeating("UpdateTimerAndFill", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreOneText.text = scoreOne.ToString();
        scoreTwoText.text = scoreTwo.ToString();
    }

    void UpdateTimerAndFill()
    {
        currentTime--;

        fillBar.fillAmount = currentTime / timer;
    }

    public IEnumerator PlayerOneScore()
    {
        scoreOne++;
        yield return new WaitForSeconds(1);
        rocketOne = Instantiate(rocketPrefab, posOne, Quaternion.identity);
    }

    public IEnumerator PlayerOneHit()
    {
        yield return new WaitForSeconds(1);
        rocketOne = Instantiate(rocketPrefab, posOne, Quaternion.identity);
    }

    public IEnumerator PlayerTwoScore()
    {
        scoreOne++;
        yield return new WaitForSeconds(1);
        rocketOne = Instantiate(rocketPrefab, posTwo, Quaternion.identity);
    }

    public IEnumerator PlayerTwoHit()
    {
        yield return new WaitForSeconds(1);
        rocketTwo = Instantiate(rocketPrefab, posTwo, Quaternion.identity);
    }
}
