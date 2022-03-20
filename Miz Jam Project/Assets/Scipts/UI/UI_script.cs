using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_script : MonoBehaviour
{
    public Image[] keys_on_lvl = new Image[3];
    Texture2D cursor;

    bool paus = false;
    Transform pause_menu;

    private void Start()
    {
        cursor = Resources.Load<Texture2D>("Cursor");
        Cursor.SetCursor(cursor,Vector3.zero,CursorMode.ForceSoftware);

        pause_menu = transform.GetChild(1);
    }

    public void Got_key(int n)
    {
        keys_on_lvl[n].enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
            if (paus)
            {
                paus = false;
                pause_menu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                paus = true;
                pause_menu.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
    }

    public void Menu()
    {
        Time.timeScale = 1;
        GameObject.Find("Game master").GetComponent<Game_master>().load_lvl(0);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        GameObject.Find("Game master").SendMessage("reload_level");
    }
}
