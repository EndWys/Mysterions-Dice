using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keysNlocks : MonoBehaviour
{
    public bool[] have_keys = new bool[3];

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.tag == "Key")
        {
            Key_script _key = collision.GetComponent<Key_script>();
            have_keys[_key.take_key()] = true;
        }
        if (collision.tag == "Lock")
        {
            Lock_script _lock = collision.GetComponent<Lock_script>();
            if (have_keys[_lock.lock_color])
                _lock.open_lock();
        }
        if (collision.name == "Death-zone")
        {
            FindObjectOfType<AudioManager>().Play("Death");
            FindObjectOfType<Game_master>().reload_level();
        }
    }
}
