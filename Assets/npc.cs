using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    public Animator animator;
    public Transform[] room;
    public float seconds;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loop());
    }

    IEnumerator loop()
    {
        int i = 0;
        while (true)
        {
            transform.DORotate(transform.rotation.eulerAngles + new Vector3(0, -180), duration);
            animator.CrossFade("Walk", .5f);
            yield return new WaitForSeconds(duration);
            transform.DOMove(room[i].position, seconds);
            yield return new WaitForSeconds(seconds);
            animator.CrossFade("Idle",.5f);
            yield return new WaitForSeconds(duration);

            i++;

            if (i > room.Length - 1)
            {
                i = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
