using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChange : MonoBehaviour
{
    public GameObject image;

    public void button_change()
    {
        if (image.activeSelf)
            image.SetActive(false);
        else image.SetActive(true);
    }
}
