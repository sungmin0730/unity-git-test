using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Movement : MonoBehaviour
{
    [SerializeField] float speed;   
    Animator ani;
    [SerializeField] Animator attack_ani;
    Rigidbody2D rigid;

    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";
    const string ATTACK = "Attack";

    private void Awake()
    {
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Co_movement());
    }

    private IEnumerator Co_movement()
    {
        while(true)
        {
            {
                yield return null;
                var h = Input.GetAxisRaw(HORIZONTAL);
                var v = Input.GetAxisRaw(VERTICAL);
                if (h == 0 && v == 0)
                {
                    ani.SetBool("iswalk", false);
                }
                else if (h == 1)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else if (h == -1)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                if (h > 0 || h < 0 || v > 0 || v < 0)
                {
                    ani.SetBool("iswalk", true);
                } 

                rigid.velocity = new Vector2(h, v) * speed;
            }//움직임

            {

                if (Input.GetButtonDown(ATTACK)) {

                    attack_ani.SetTrigger("attack");

                }

            }//공격
        }

    }

}
