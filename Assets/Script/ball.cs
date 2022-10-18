using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 vc;
    private char nextkey;
    [SerializeField] bool isChose;
    [SerializeField] bool isKickable;

    GameObject Scoreboad;
    Score scorescript;

    [SerializeField]private bool isKicking;

    // Start is called before the first frame update
    void Start()
    {
        isKicking = false;
        isChose = false;
        InitBall();
        rb = GetComponent<Rigidbody2D>();
        Scoreboad = GameObject.Find("Canvas/ScoreGroup");
        scorescript = Scoreboad.GetComponent<Score>();

    }

    public bool GetSetIsKicking{
        get { return isKicking; }
        set { isKicking = value; }
    }

    public void InitBall()
    {
        transform.position = new Vector2(0,0);
    }

    public char RandomButtonChoice() {
        var txt = "JKLIOP";
        var rand = new System.Random();
        return txt[rand.Next(txt.Length)];
    }

    public void InitKey() {
        nextkey = RandomButtonChoice();
        Debug.Log(nextkey);
    }

    public char GetSetNextkey
    {
        get { return nextkey; }
        set { nextkey = value; }
    }

    public void Lifting() {
        if (KeyToChar() == nextkey)
        {
            isKickable = false;
            isKicking = true;
            rb.velocity = Vector3.zero;
            var rand1 = new System.Random();
            var rand2 = new System.Random();
            vc = new Vector2(rand1.Next(-10, 11), rand2.Next(80,170));
            rb.AddForce(vc);
            scorescript.ScoreCalc(1);
            isChose = false;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "waku" || collision.gameObject.name == "waku2")
        {
            isKickable = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "waku" || collision.gameObject.name == "waku2")
        {
            isKickable = false;
        }
    }

    public void LiftinfMain()
    {
        if (!isChose)
        {
            isChose = true;
            InitKey();
        }
        if (isKickable)
        {
            Lifting();
        }
    }

    public char KeyToChar() {
        if (Input.GetKeyDown("j"))
        {
            return 'J';
        }
        else if (Input.GetKeyDown("k"))
        {
            return 'K';
        }
        else if (Input.GetKeyDown("l"))
        {
            return 'L';
        }
        else if (Input.GetKeyDown("i"))
        {
            return 'I';
        }
        else if (Input.GetKeyDown("o"))
        {
            return 'O';
        }
        else if (Input.GetKeyDown("p"))
        {
            return 'P';
        }
        else{
            return ' ';
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "ground")
        {
            isKickable = true;
            scorescript.Miss();
            Debug.Log("gameover");
            scorescript.ShowHighScore();
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
