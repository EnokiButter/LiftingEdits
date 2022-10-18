using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTextSc : MonoBehaviour
{
    Text textmoji;
    char moji;

    // Start is called before the first frame update
    void Start()
    {
        textmoji = GetComponent<Text>();
    }

    public char GetSetMoji
    {
        get{ return moji; }
        set{ moji = value; }
    }

    public void ShowMoji()
    {
        textmoji.text = GetSetMoji.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
