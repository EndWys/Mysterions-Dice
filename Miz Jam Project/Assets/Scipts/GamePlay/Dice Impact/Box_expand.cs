using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_expand : MonoBehaviour
{
    SpriteRenderer sprite;
    BoxCollider2D col;

    public Color32 impact_color;
    Color32 starter_color;
    Vector2 start_spr_sz;
    Vector2 start_col_sz;

    //Vector2 target_spr_sz;
    //Vector2 target_col_sz;

    public int roll_offset = 2;
    public float multiplayer = 1;

    public bool x;
    public bool y;

    void Start()
    {
        sprite = transform.GetComponent<SpriteRenderer>();
        col = transform.GetComponent<BoxCollider2D>();

        starter_color = sprite.color;
        start_spr_sz = sprite.size;
        start_col_sz = col.size;
    }

    void Impact(int roll)
    {

        sprite.color = impact_color;
        if (x)
        {
            sprite.size = new Vector2(start_spr_sz.x + (roll - roll_offset) * multiplayer, sprite.size.y);
            col.size = new Vector2(start_col_sz.x + (roll - roll_offset) * multiplayer, col.size.y);
        }
        if (y)
        {
            sprite.size = new Vector2(sprite.size.x, start_spr_sz.y + (roll - roll_offset) * multiplayer);
            col.size = new Vector2(col.size.x, start_col_sz.y + (roll - roll_offset) * multiplayer);
        }
    }

    void cancel_impact()
    {
        sprite.color = starter_color;
        sprite.size = start_spr_sz;
        col.size = start_col_sz;
    }
}
