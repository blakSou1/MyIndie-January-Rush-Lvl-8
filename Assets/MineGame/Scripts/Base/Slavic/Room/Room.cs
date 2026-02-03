using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RoomeState
{
    public RoomBase model;
}

public class Room : MonoBehaviour
{
    public Sprite icon;
    public Sprite iconCHB;
    public Color color;

    public List<Entity> objects = new();

    public List<UnityEvent> events;

    public Transform startPos;
    public Transform endPos;

    private AnimActivScill skillAnim;

    [HideInInspector] public Button button;

    public RoomeState state;

    public float timereset = 2f;
    private bool reset = true;
    public void SetState(RoomeState room)
    {
        state = room;
        state.model.model = this;
        skillAnim = GetComponent<AnimActivScill>();
        if(skillAnim != null)skillAnim.model = this;
    }

    public void AddEntity(Entity toClaim)
    {
        if (toClaim.state.room != null)
            toClaim.state.room.Release(toClaim);

        toClaim.state.room = this;
        objects.Add(toClaim);

        toClaim.transform.SetParent(transform, false);
        toClaim.transform.SetSiblingIndex(3);

        toClaim.transform.position = startPos.position;

        state.model.EnterEntity(toClaim);
    }

    public void ActivationSkill()
    {
        if (!reset) return;

        state.model.ActivSkil();
        skillAnim.Activ();

        button.StartCoroutine(SkilButtonReset());
    }
    private IEnumerator SkilButtonReset()
    {
        reset = false;
        button.interactable = false;

        yield return button.StartCoroutine(SkilButtonResetVisual());

        reset = true;
        button.interactable = true;
    }
    private IEnumerator SkilButtonResetVisual()
    {
        Image im = button.GetComponent<Image>();

        float time = 0;

        while(time < timereset)
        {
            time += .1f;

            float targetFillAmount = (float)time / (float)timereset;
            im.fillAmount = targetFillAmount;

            yield return new WaitForSeconds(.1f);
        }

        im.fillAmount = 1;
    }

    public void Release(Entity toClaim)
    {
        if (objects.Contains(toClaim))
        {
            objects.Remove(toClaim);
            state.model.ExitEntity(toClaim);
        }
    }

}
