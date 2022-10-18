using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarasflyScript : MonoBehaviour
{
    [SerializeField]private string dir;
    private float speed;
    public AudioClip sound1;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        KarKar();
    }
    public string GetSetDir
    {
        get { return dir; }
        set { dir = value; }
    }

    public void KarasFlip()
    {
        if (dir == "left")
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void KarasFly()
    {
        if (dir == "right")
        {
            speed = 10f;
        }
        else
        {
            speed = -10f;
        }
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }

    // Update is called once per frame

    public void KarKar()
    {
        audioSource.PlayOneShot(sound1);
    }

    void Update()
    {
        if(dir != null)
        {
            KarasFly();
        }
    }
}
