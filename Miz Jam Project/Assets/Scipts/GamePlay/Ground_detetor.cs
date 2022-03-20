using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_detetor : MonoBehaviour
{
    Move move;
    bool on_gr;
    // Start is called before the first frame update

    private void Start()
    {
        move = transform.GetComponentInParent<Move>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.transform.tag == "Platform")
        {
            move.on_ground = true;
            on_gr = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
            on_gr = false;  
    }
    
    void Jump_failed()
    {
       StartCoroutine(ground_chek());
    }

    IEnumerator ground_chek()
    {
        yield return new WaitForSeconds(0.05f);
        if (on_gr)
            move.on_ground = true;
    }
}
