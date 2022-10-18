using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gcon : MonoBehaviour
{
    GameObject Man;
    GameObject Ball;
    GameObject KeytxtObj;
    GameObject Scoreboard;
    GameObject karasG1;
    GameObject karasG2;

    man manscript;
    ball ballscript;
    KeyTextSc keytextscr;
    Score scorescr;
    KarasGenerateScript karagsc1;
    KarasGenerateScript karagsc2;

    AudioSource audioSource;
    private bool splaying; //sound playing
    private int times;
    private float timesfloat;

    private bool isKicking;

    // Start is called before the first frame update
    void Start()
    {
        timesfloat = 0;
        times = 0;

        splaying = false;
        Man = GameObject.Find("man");
        Ball = GameObject.Find("ball");
        KeytxtObj = GameObject.Find("Canvas/KeyText");
        Scoreboard = GameObject.Find("Canvas/ScoreGroup");
        karasG1 = GameObject.Find("karasGenerator1");
        karasG2 = GameObject.Find("karasGenerator2");


        manscript = Man.GetComponent<man>();
        ballscript = Ball.GetComponent<ball>();
        keytextscr = KeytxtObj.GetComponent<KeyTextSc>();
        scorescr = Scoreboard.GetComponent<Score>();
        audioSource = GetComponent<AudioSource>();
        karagsc1 = karasG1.GetComponent<KarasGenerateScript>();
        karagsc2 = karasG2.GetComponent<KarasGenerateScript>();
    }

    public void timer()
    {
        timesfloat += Time.deltaTime;
        if (1.00f <= timesfloat)
        {
            timesfloat = 0;
            times += 1;
            karagsc1.KarasGenrate(scorescr.GetSetScore);
            karagsc2.KarasGenrate(scorescr.GetSetScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (0 < scorescr.GetSetScore && !splaying)
        {
            audioSource.Play();
            splaying = true;
        }

        keytextscr.GetSetMoji = ballscript.GetSetNextkey;
        keytextscr.ShowMoji();

        ballscript.LiftinfMain();
        if (!ballscript.GetSetIsKicking)
        {
            manscript.ManMoving();
        }
        manscript.KickAnim();

        if (0 <= Man.transform.position.x)
        {
            KeytxtObj.transform.position = new Vector2(Man.transform.position.x - 1f, Man.transform.position.y);
        }
        else
        {
            KeytxtObj.transform.position = new Vector2(Man.transform.position.x + 2f, Man.transform.position.y);
        }

        scorescr.ShowScore();

        timer();
    }
}
