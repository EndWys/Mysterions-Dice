using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_script : MonoBehaviour
{
    SpriteRenderer sprite;
    ParticleSystem particle;

    public int lock_color;
    //public Sprite[] sprites = new Sprite[3];

    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
        particle = transform.GetComponent<ParticleSystem>();

        switch (lock_color)
        {
            case 0:
                sprite.color = Color.blue;
                break;
            case 1:
                sprite.color = Color.red;
                break;
            case 2:
                sprite.color = Color.yellow;
                break;
            default: break;
        }
    }
    public void open_lock()
    {
        transform.parent.SendMessage("Unlock",lock_color);
        Destroy(gameObject, 0.02f);
    }
}
