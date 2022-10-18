using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man : MonoBehaviour
{
    private Animator anim;
    private GameObject Ball;
    private ball ballscript;
    public AudioClip sound1;
    AudioSource audioSource;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        anim = GetComponent<Animator>();
        Ball = GameObject.Find("ball");
        ballscript = Ball.GetComponent<ball>();
        audioSource = GetComponent<AudioSource>();
    }

    public void ManMoving()
    {
        if (Input.GetKey("a"))
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            anim.SetBool("move", true);
        }
        if (Input.GetKey("d"))
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            anim.SetBool("move", true);
        }
        if(!Input.GetKey("a") && !Input.GetKey("d"))
        {
            anim.SetBool("move", false);
        }
    }

    public float GetSetSpeed
    {
        get { return speed; }
        set { speed = value; }
    }

    public void IsKickingOff()
    {
        ballscript.GetSetIsKicking = false;
        Debug.Log("iskoff");
    }

    public void KickAnim()
    {
        if (ballscript.GetSetIsKicking)
        {
            anim.SetBool("kick", true);
        }
        if (!ballscript.GetSetIsKicking)
        {
            anim.SetBool("kick",false);
        }
    }
    public void KickSound()
    {

        audioSource.PlayOneShot(sound1);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
