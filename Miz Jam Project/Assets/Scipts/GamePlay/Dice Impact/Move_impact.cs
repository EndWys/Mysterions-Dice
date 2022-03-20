using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_impact : MonoBehaviour
{
    Vector2 star_pos;
    Vector2 target_pos;

    public int roll_offset = 2;
    public float multiplayer = 1;

    public bool x;
    public bool y;

    void Start()
    {
        star_pos = transform.position;
    }

    // Update is called once per frame
    void Impact(int roll)
    {
        StopAllCoroutines();
        target_pos = star_pos;
        if (x)
            target_pos += new Vector2((roll - roll_offset) * multiplayer,0);
        if (y)
            target_pos +=new Vector2(0, (roll - roll_offset) * multiplayer);
        StartCoroutine(Moveing());
    }

    void cancel_impact()
    {
        StopAllCoroutines();
        StartCoroutine(Back());
    }

    IEnumerator Moveing()
    {
        yield return new WaitForSeconds(0.2f);
        if ((Vector2)transform.position != target_pos)
        {
            transform.position = Vector2.MoveTowards(transform.position, target_pos, 0.2f);
            StartCoroutine(Moveing());
        }
    }

    IEnumerator Back()
    {
        yield return new WaitForSeconds(0.2f);
        if ((Vector2)transform.position != star_pos) {
            transform.position = Vector2.MoveTowards(transform.position, star_pos, 0.2f);
            StartCoroutine(Back());
        }
    }
}
