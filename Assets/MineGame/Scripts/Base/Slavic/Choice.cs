using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public CanvasGroup group;

    public Image item1;
    public Image item2;
    public Image item3;

    Room room1;
    Room room2;
    Room room3;

    void Awake()
    {
        G.choice = this;
        StartCoroutine(CanvasGroupHide(0, 0, 0));
    }

    public void ButtonUp(int index)
    {
        item1.sprite = null;
        item2.sprite = null;
        item3.sprite = null;

        StartCoroutine(CanvasGroupHide(1, 0));

        RoomBase room = null;
        if (index == 1)
            room = room1.state.model;
        else if (index == 2)
            room = room2.state.model;
        else if(index == 3)
            room = room3.state.model;

        Destroy(room1.gameObject);
        Destroy(room2.gameObject);
        Destroy(room3.gameObject);

        room1 = null;
        room2 = null;
        room3 = null;

        G.roomManager.AddInsertRoom(room.GetType());
        G.gameMode.StartCoroutine(G.gameMode.NextWave());
    }

    public void ChoiceIn(Type roomType1, Type roomType2, Type roomType3)
    {
        room1 = Framefork.AddRoom(roomType1);
        room2 = Framefork.AddRoom(roomType2);
        room3 = Framefork.AddRoom(roomType3);

        room1.gameObject.SetActive(false);
        room2.gameObject.SetActive(false);
        room3.gameObject.SetActive(false);

        item1.sprite = room1.icon;
        item2.sprite = room2.icon;
        item3.sprite = room3.icon;

        StartCoroutine(CanvasGroupHide(0, 1));
    }

    private IEnumerator CanvasGroupHide(float start, float end, float time = .3f)
    {
        group.alpha = start;

        if (group.alpha == 0)
            group.gameObject.SetActive(true);
        else
            group.gameObject.SetActive(false);

        float elapsedTime = start;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / time);

            group.alpha = Mathf.Lerp(1, 0, t);

            yield return null;
        }

        group.alpha = end;

        if (group.alpha == 1)
            group.gameObject.SetActive(true);
        else
            group.gameObject.SetActive(false);
    }
}
