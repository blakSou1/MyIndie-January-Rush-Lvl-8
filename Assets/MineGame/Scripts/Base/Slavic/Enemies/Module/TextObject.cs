using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    [SerializeField]private float _destroyTime;
    private TextMeshProUGUI _text;
    public void Init(float damage)
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = damage.ToString();
        
        Destroy(gameObject, _destroyTime);
        
        transform.DOScale(0, _destroyTime);
        transform.DOLocalMoveY(200, _destroyTime);
    }
}