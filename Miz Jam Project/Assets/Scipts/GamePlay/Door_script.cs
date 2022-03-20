using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_script : MonoBehaviour
{
    SpriteRenderer sprite;

    public Sprite opend_door;
    public bool[] locks = new bool[3];
    bool next_level, once = true;
    // Start is called before the first frame update
    private void Start()
    {
        next_level = false;
        sprite = transform.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        int i;
        for (i = 0; i < 3; i++)
            if (locks[i])
            {
                next_level = false;
                break;
            }
            else next_level = true;

        if (next_level&& once)
        {
            sprite.sprite = opend_door;
            FindObjectOfType<AudioManager>().Play("Lock");
            FindObjectOfType<Game_master>().next_lvl();
            once = false;
        }
    }


    void Unlock(int n)
    {
        locks[n] = false;
    }
}
