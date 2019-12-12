using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649
public class Colleague : MonoBehaviour
{
    private Rigidbody2D mRB2D;
    [SerializeField] private float mSpeed;
    private Animator mAnim;

    void Awake()
    {
        mRB2D = gameObject.GetComponent<Rigidbody2D>();
        mAnim = gameObject.GetComponent<Animator>();
    }

    private IEnumerator Movement()
    {
        WaitForSeconds moveTime = new WaitForSeconds(1F);
        while (true)
        {
            int dir = Random.Range(0, 2);
            if (dir == 0) // see left side 
            {
                transform.rotation = Quaternion.identity;
            }
            else // see right side
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            int moveOfStay = Random.Range(0, 2);
            if (moveOfStay == 0)
            {
                mRB2D.velocity = Vector2.zero;
                mAnim.SetBool(AnimHash.Move, false);
            }
            else
            {
                mRB2D.velocity = transform.right * -mSpeed;
                mAnim.SetBool(AnimHash.Move, true);
            }
            yield return moveTime;
        }
    }

    private IEnumerator Function(float time)
    {
        WaitForSeconds term = new WaitForSeconds(time);
        while (true)
        {
            yield return term;
            // TODO 특정동작 구현
        }
    }
}
