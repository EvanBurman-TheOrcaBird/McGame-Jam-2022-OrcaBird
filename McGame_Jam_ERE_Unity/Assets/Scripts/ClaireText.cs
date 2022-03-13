using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaireText : MonoBehaviour
{
    public Rigidbody2D rbPlayer;
    Vector2 height;
    TextMesh txt;

    // Start is called before the first frame update
    void Start()
    {
        height = new Vector2(0f, 1f);
        txt = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = rbPlayer.position + height;
        //Debug.Log(GetComponent<Animator>().GetState());
    }

    public void Prompt(int promptNumber)
    {
        switch (promptNumber)
        {
            case 1:
                txt.text = "I can jump with Space.";
                break;
            case 2:
                txt.text = "I can throw my candle with J.";
                break;
            case 3:
                txt.text = "I can move boxes with J\nif I don't have my candle.";
                break;
            case 4:
                txt.text = "I can go up and down ladders using W and S.";
                break;
            case 5:
                txt.text = "Spikes will kill me and my candle.";
                break;
            case 6:
                txt.text = "I should jump to get the painting!";
                break;
        }

    }

}
