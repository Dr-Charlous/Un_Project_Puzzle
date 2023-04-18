using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIAnimation : MonoBehaviour
{
    //public Sprite BaseSprite;
    //public Sprite SpriteSelected;

    public float scalePress = 0.6f;
    public float scaleHighlighted = 0.9f;
    public float baseScale = 0.75f;
    public float time = 0.1f;

    //private bool isSelected;
    private bool isHighlight;

    public void Press()
    {
        transform.DOScale(scalePress, time);
    }    
    
    public void ResetScale()
    {
        transform.DOScale(baseScale, time);
    }

    public void OnPointerUp()
    {
        if (isHighlight == true)
        {
            Highlight();
        }
        else
        {
            ResetScale();
        }
    }

    public void Highlight()
    {
        isHighlight = true;
        transform.DOScale(scaleHighlighted, time);
    }
    public void OnPointerExit()
    {
        isHighlight = false;
    }

    //public void Selected()
    //{
    //    GetComponent<Image>().sprite = SpriteSelected;
    //}



}
