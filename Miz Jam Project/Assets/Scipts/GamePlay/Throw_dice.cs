using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_dice : MonoBehaviour
{
    public Camera cam;
    Transform dice;
    Transform target_object;
    SpriteRenderer Dice_sprite;

    public int lenth = 4;
    bool thrown = false;


    private void Start()
    {
        dice = GameObject.Find("Dice").transform;
        Dice_sprite = dice.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
            if (!thrown)
                Throw();
            else
            {
                StopAllCoroutines();
                Dice_unhide();
                StartCoroutine(Geting_back());
            }
    }

    void Throw()
    {
        Ray screen_ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        RaycastHit2D hit2D;
        if (Physics.Raycast(screen_ray,out hit, 1000))
        {
            dice.position = transform.position;
            Ray2D ray_dice = new Ray2D(transform.position,(hit.point - transform.position).normalized);
            hit2D = Physics2D.Raycast(ray_dice.origin + ray_dice.direction* 0.4f, ray_dice.direction * lenth, lenth, LayerMask.GetMask("Default","Platforms","Water"));
            Debug.DrawRay(ray_dice.origin + ray_dice.direction * 0.4f, ray_dice.direction * lenth);
            if (hit2D)
                if(hit2D.transform.tag == "Platform" && hit2D.transform.name != "Tilemap")
                    StartCoroutine(Dice_scud(hit2D.point, hit2D.transform));
                else StartCoroutine(Dice_scud(hit2D.point, transform));
            else
                StartCoroutine(Dice_scud(transform.position + (Vector3)ray_dice.direction * lenth, transform));
            thrown = true;
        }
    }

    IEnumerator Dice_scud(Vector3 dice_target,Transform target_obj)
    {
        yield return new WaitForFixedUpdate();
        if ((dice_target - dice.position).magnitude > 0.5f)
        {
            dice.Rotate(Vector3.back, 1800 * Time.deltaTime);
            dice.localScale = new Vector3(1, 1, 1);
            dice.position = Vector3.MoveTowards(dice.position, dice_target, 20 * Time.deltaTime);
            StartCoroutine(Dice_scud(dice_target, target_obj));
        }
        else if (target_obj!=transform)
        {
            dice.position = Vector3.MoveTowards(dice.position, dice_target, -10 * Time.deltaTime);
            dice.rotation = Quaternion.identity;
            target_object = target_obj;
            StartCoroutine(Rolling(1));
        }
        else StartCoroutine(Geting_back());
    }

    void Get_back_dice()
    {
        StopAllCoroutines();
        if(target_object!=null)
            target_object.SendMessage("cancel_impact");
        dice.localScale = Vector3.zero;
        dice.rotation = Quaternion.identity;
        thrown = false;
    }

    IEnumerator Geting_back()
    {
        yield return new WaitForFixedUpdate();
        if ((transform.position - dice.position).magnitude > 0.2f)
        {
            dice.position = Vector3.MoveTowards(dice.position, transform.position, 16 * Time.deltaTime);
            StartCoroutine(Geting_back());
        }
        else Get_back_dice();
    }

    void Roll(Transform Dice_target)
    {
        int side;
        side = Random.Range(10000,99999) % 6;
        Dice_sprite.sprite = Dice_sprites.dices[10 + side];
        FindObjectOfType<AudioManager>().Play("Dice");
        if (Dice_target != null)
           Dice_target.SendMessage("Impact", side);
        StartCoroutine(Dice_hide());
    }

    IEnumerator Dice_hide()
    {
        yield return new WaitForSeconds(1f);
        dice.localScale = Vector3.zero;
    }

    void Dice_unhide()
    {
        dice.localScale = new Vector3(1,1,1);
    }

    IEnumerator Rolling(float timer)
    {
        yield return new WaitForFixedUpdate();
        if (timer <= 0)
            Roll(target_object);
        else
        {
            int i = Random.Range(0, 5);
            if (Dice_sprites.dices[10 + i] != null)
                Dice_sprite.sprite = Dice_sprites.dices[10 + i];
            timer -= Time.deltaTime;
            StartCoroutine(Rolling(timer));
        }
    }
}
