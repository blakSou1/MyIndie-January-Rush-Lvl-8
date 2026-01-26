using System.Collections;
using UnityEngine;

public class StartAnim : MonoBehaviour
{
    public AnimationDataSO anim;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(0,1.3f));

        AnimationController r = GetComponent<AnimationController>();
        r.Init();
        r.SetAnimation(anim);
    }

    
}
