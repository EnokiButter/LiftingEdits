using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarasGenerateScript : MonoBehaviour
{   
    [SerializeField]private GameObject karas;
    [SerializeField] private string karasDir;
    private int probability;

    // Start is called before the first frame update
    void Start()
    {
    }
    public void KarasGenrate(int score)
    {
        if (10 <= score && score < 30) 
        {
            probability = 5;
        }
        else if (30 <= score && score < 100)
        {
            probability = score - 24;
        }
        else if (100 <= score)
        {
            probability = 100;
        }
        if (Random.Range(1,101) < probability )
        {
            Vector2 karaspoint = transform.position;
            GameObject Karas = Instantiate(karas, karaspoint, transform.rotation);
            KarasflyScript karasflyscript = Karas.GetComponent<KarasflyScript>();
            karasflyscript.GetSetDir = karasDir;
            karasflyscript.KarasFlip();
            Destroy(Karas, 2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
