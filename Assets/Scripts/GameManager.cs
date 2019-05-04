using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int counter;
    public GameObject hand;
    public GameObject trashCan;
    public GameObject ball;
    public GameObject bar;
    public GameObject gameOver;
    public Text points;
    float barDirection;
    bool flag;
    bool gameO = false;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(trashCan, new Vector2(UnityEngine.Random.Range(-9.0f, 13.0f), -3.1f), Quaternion.identity);
        counter = 0;
        barDirection = 0.08f;
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        points.text = counter.ToString();
        bar.transform.Translate(new Vector3(barDirection, 0, 0));
        
        if (Input.GetKey(KeyCode.Space) && flag)
        {
            ThrowBall();
            flag = false;
        }

        if (gameO)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Application.LoadLevel("SampleScene");
            }
        }
    }

    public void ChangeDirectionBar()
    {
        barDirection *= -1;
    }

    public void ReturnBall() {

        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        ball.transform.position = hand.transform.position;
        Instantiate(trashCan, new Vector2(UnityEngine.Random.Range(-9.0f, 13.0f), -3.1f), Quaternion.identity);
        flag = true;
        counter++;
    }

    void ThrowBall()
    {
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(4.5f, 4) * (bar.transform.position.y / 1.6f);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        gameO = true;
    }
}
