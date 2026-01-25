using UnityEngine;

public class StartAnim : MonoBehaviour
{
    public AnimationDataSO anim;

    void Start()
    {
        AnimationController r = GetComponent<AnimationController>();
        r.Init();
        r.SetAnimation(anim);
    }

    
}
