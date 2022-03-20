using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_script : MonoBehaviour
{
    SpriteRenderer sprite;
    //ParticleSystem particle;

    public int key_color;
    //public Sprite[] sprites = new Sprite[3];
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
        //particle = transform.GetComponent<ParticleSystem>();

        switch (key_color)
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
    public int take_key()
    {
        Destroy(gameObject, 0.1f);
        FindObjectOfType<AudioManager>().Play("Key");
        FindObjectOfType<UI_script>().Got_key(key_color);
        return key_color;
    }
}
