using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_master : MonoBehaviour
{
    public static Game_master instance;

    string progress = "progress";

    int player_progres = 1;
    int last_level = 6;
    int scene_now=0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        player_progres = PlayerPrefs.GetInt(progress);
        if (player_progres == 0)
            player_progres = 1;
        Debug.Log("Dont't destroy");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            StopAllCoroutines();
            reload_level();
        }
    }

    public void load_lvl(int l)
    {
        StopAllCoroutines();
        StartCoroutine(load_scene(l));
    }


    public void Quite()
    {
        Application.Quit();
    }

    public void Start_play()
    {
        StartCoroutine(load_scene(player_progres));
    }

    public void next_lvl()
    {
        if (player_progres != last_level)
        {
            player_progres++;
            PlayerPrefs.SetInt(progress, player_progres);

            StartCoroutine(load_scene(player_progres));
            Debug.Log("next lvl");
        }
        else StartCoroutine(load_scene(0));
    }
    public void reload_level()
    {
        StartCoroutine(load_scene(scene_now));
        Debug.Log("reload");
    }

    IEnumerator load_scene(int scene)
    {
        yield return new WaitForSeconds(1f);
        scene_now = scene;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
