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
                txt.text = "Jump with Space.";
                break;
            case 2:
                txt.text = "Drop candle with J.\nThrow candle with J + A, W, and D.";
                break;
            case 3:
                txt.text = "Move boxes with J\nif not holding candle.";
                break;
            case 4:
                txt.text = "Go up and down ladders with W and S.";
                break;
            case 5:
                txt.text = "Spikes will kill me.";
                break;
            case 6:
                txt.text = "Respawn with P.";
                break;
        }

    }

}
