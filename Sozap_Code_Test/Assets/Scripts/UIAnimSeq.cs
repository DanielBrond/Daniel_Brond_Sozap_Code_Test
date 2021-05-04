using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimSeq : MonoBehaviour
{
   
    public float waitBetween = 0.15f;
    public float waitEnd = 0.5f;
    List<Animator> animators;


    // Start is called before the first frame update
    void Start()
    {
        animators = new List<Animator>(GetComponentsInChildren<Animator>());

        StartCoroutine(DoAnimation());
    }

   IEnumerator DoAnimation()
    {
        while (true)
        {
            foreach(var animator in animators)
            {
                animator.SetTrigger("DoAnim");
                yield return new WaitForSeconds(waitBetween);
            }

            yield return new WaitForSeconds(waitEnd);
        }
    }
}
