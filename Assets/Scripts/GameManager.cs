using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public float timer, currentTime;
    
    public GameObject rocketPrefab, asteroidPrefab, blackHolePrefab;

    public float spawnFrequency;

    public GameObject rocketOne, rocketTwo;
    public Text scoreOneText, scoreTwoText;
    public int scoreOne, scoreTwo;

    public Image fillBar, P1L, P1R, P2L, P2R;

    Vector3 posOne, posTwo;

    public float xLeft, xRight, yMax, yMin;

    public GameObject gameOver;

    public bool end = false;

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
        for (int i = 0; i < 20; i++)
        {
            float leftRight = Random.Range(0, 3);
            GameObject ast;

            if (leftRight <= 1)
            {
                ast = Instantiate(asteroidPrefab, new Vector3(Random.Range(xLeft, xRight), Random.Range(yMin, yMax), 0), Quaternion.identity);
                ast.GetComponent<Asteroid>().left = false;
            }
            else
            {
                ast = Instantiate(asteroidPrefab, new Vector3(Random.Range(xLeft, xRight), Random.Range(yMin, yMax), 0), Quaternion.identity);
                ast.GetComponent<Asteroid>().left = true;
            }
        }

        posOne = rocketOne.transform.position;
        posTwo = rocketTwo.transform.position;

        currentTime = timer;
        InvokeRepeating("SpawnAsteroids", 0f, spawnFrequency);
        InvokeRepeating("UpdateTimerAndFill", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreOneText.text = scoreOne.ToString();
        scoreTwoText.text = scoreTwo.ToString();

        if (currentTime == 0)
        {
            rocketOne.GetComponent<Rocket>().enabled = false;
            rocketTwo.GetComponent<Rocket>().enabled = false;

            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            for (int i = 0; i < asteroids.Length; i++)
            {
                asteroids[i].GetComponent<Asteroid>().enabled = false;
            }
            end = true;

            if (scoreOne > scoreTwo)
            {
                gameOver.transform.GetChild(0).gameObject.GetComponent<Text>().text = "PLAYER ONE WINS";
            }
            else if (scoreTwo > scoreOne)
            {
                gameOver.transform.GetChild(0).gameObject.GetComponent<Text>().text = "PLAYER TWO WINS";
            }
            else if (scoreOne == scoreTwo)
            {
                gameOver.transform.GetChild(0).gameObject.GetComponent<Text>().text = "ITS A TIE";
            }

            gameOver.SetActive(true);
        }
    }

    void UpdateTimerAndFill()
    {
        currentTime--;

        fillBar.fillAmount = currentTime / timer;

        P1R.fillAmount = 1- ((rocketOne.GetComponent<Rocket>().timestampR - Time.time) / rocketOne.GetComponent<Rocket>().cooldownDelay);
        P1L.fillAmount = 1- ( (rocketOne.GetComponent<Rocket>().timestampL - Time.time) / rocketOne.GetComponent<Rocket>().cooldownDelay);

        P2R.fillAmount = 1- ((rocketTwo.GetComponent<Rocket>().timestampR - Time.time) / rocketTwo.GetComponent<Rocket>().cooldownDelay);
        P2L.fillAmount = 1-((rocketTwo.GetComponent<Rocket>().timestampL - Time.time) / rocketTwo.GetComponent<Rocket>().cooldownDelay);
    }

    void SpawnAsteroids()
    {
        float spawner = Random.Range(0, 18);

        if (!end)
        {
            float leftRight = Random.Range(0, 3);
            GameObject ast;

            if (leftRight <= 1f)
            {
                if (spawner >= 1f)
                {
                    ast = Instantiate(asteroidPrefab, new Vector3(xLeft, Random.Range(yMin, yMax), 0), Quaternion.identity);
                    ast.GetComponent<Asteroid>().left = false;
                }
                else
                {
                    ast = Instantiate(blackHolePrefab, new Vector3(xLeft, Random.Range(yMin, yMax), 0), Quaternion.identity);
                    ast.GetComponent<BlackHole>().direction = 1;
                }
            }
            else
            {
                if(spawner >= 1f)
                { 
                ast = Instantiate(asteroidPrefab, new Vector3(xRight, Random.Range(yMin, yMax), 0), Quaternion.identity);
                ast.GetComponent<Asteroid>().left = true;
                }
                else
                {
                ast = Instantiate(blackHolePrefab, new Vector3(xRight, Random.Range(yMin, yMax), 0), Quaternion.identity);
                ast.GetComponent<BlackHole>().direction = -1;
                }
            }
        }
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
        scoreTwo++;
        yield return new WaitForSeconds(1);
        rocketTwo = Instantiate(rocketPrefab, posTwo, Quaternion.identity);
        rocketTwo.GetComponent<Rocket>().rocketOne = false;
    }

    public IEnumerator PlayerTwoHit()
    {
        yield return new WaitForSeconds(1);
        rocketTwo = Instantiate(rocketPrefab, posTwo, Quaternion.identity);
        rocketTwo.GetComponent<Rocket>().rocketOne = false;
    }
}
