using DG.Tweening;
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

    public Image item1Chb;
    public Image item2Chb;
    public Image item3Chb;

    Room room1;
    Room room2;
    Room room3;

    public Sprite baseIconMazok;

    public Image Mazok;
    public Image baseImage;
    Color baseImageColor;

    Tween colorTween;
    Ease easeType = Ease.InOutSine;

    void Awake()
    {
        G.choice = this;
        StartCoroutine(CanvasGroupHide(0, 0, 0));

        item1.gameObject.SetActive(false);
        item2.gameObject.SetActive(false);
        item3.gameObject.SetActive(false);

        item1Chb.gameObject.SetActive(true);
        item2Chb.gameObject.SetActive(true);
        item3Chb.gameObject.SetActive(true);

        baseImageColor = baseImage.color;
    }

    public void ButtonUp(int index)
    {
        StartCoroutine(ButtonUps(index));
    }
    private IEnumerator ButtonUps(int index)
    {
        yield return StartCoroutine(CanvasGroupHide(1, 0));

        item1.sprite = null;
        item2.sprite = null;
        item3.sprite = null;

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

    public void EnterColor(int index)
    {
        Room room = null;

        if (index == 1)
            room = room1;
        else if (index == 2)
            room = room2;
        else if (index == 3)
            room = room3;
        else if (index == 4)
        {
            Mazok.sprite = baseIconMazok;

            colorTween?.Kill();

            colorTween = baseImage.DOColor(baseImageColor, .4f)
                .SetEase(easeType)
                .OnStart(() => {
                })
                .OnComplete(() => {
                });

            return;
        }

        Mazok.sprite = room.iconMazok;

        colorTween?.Kill();

        colorTween = baseImage.DOColor(room.color, .4f)
            .SetEase(easeType)
            .OnStart(() => {
            })
            .OnComplete(() => {
            });
    }
    public void ExitColor()
    {
        EnterColor(4);
    }

    public void ChoiceIn(Type roomType1, Type roomType2, Type roomType3)
    {
        item1.gameObject.SetActive(false);
        item2.gameObject.SetActive(false);
        item3.gameObject.SetActive(false);

        item1Chb.gameObject.SetActive(true);
        item2Chb.gameObject.SetActive(true);
        item3Chb.gameObject.SetActive(true);

        room1 = Framefork.AddRoom(roomType1);
        room2 = Framefork.AddRoom(roomType2);
        room3 = Framefork.AddRoom(roomType3);

        room1.gameObject.SetActive(false);
        room2.gameObject.SetActive(false);
        room3.gameObject.SetActive(false);

        item1.sprite = room1.icon;
        item2.sprite = room2.icon;
        item3.sprite = room3.icon;

        item1Chb.sprite = room1.iconCHB;
        item2Chb.sprite = room2.iconCHB;
        item3Chb.sprite = room3.iconCHB;

        StartCoroutine(CanvasGroupHide(0, 1));
    }

    public IEnumerator CanvasGroupHide(float start, float end, float time = .3f)
    {
        if (group == null) yield break;

        group.alpha = start;

        if (!group.gameObject.activeSelf)
            group.gameObject.SetActive(true);

        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / time);

            group.alpha = Mathf.Lerp(start, end, t);

            yield return null;
        }

        group.alpha = end;

        if (end == 0)
            group.gameObject.SetActive(false);
    }
}
