using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    string progress = "progress";

    int progres;
    public Image[] locks = new Image[3];
    // Start is called before the first frame update
    void Start()
    {
        progres = PlayerPrefs.GetInt(progress);
        if (progres == 0)
            progres = 1;

        Debug.Log(progres);

        for (int i = 0; i < progres; i++)
            locks[i].enabled = false;

    }

    public void Levels()
    {
        transform.localPosition = new Vector3(0, -600, 0);
    }

    public void main_menu()
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    public void load_lvl(int i)
    {
        FindObjectOfType<Game_master>().load_lvl(i);
    }

    public void start_play()
    {
        FindObjectOfType<Game_master>().Start_play();
    }

    public void Music()
    {
        FindObjectOfType<AudioManager>().Music_button();
    }

    public void All_sounds()
    {
        FindObjectOfType<AudioManager>().Sounds_button();
    }

    public void Quite()
    {
        Application.Quit();
    }
}
