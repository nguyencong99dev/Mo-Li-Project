using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotEffect : MonoBehaviour
{
    [SerializeField] Image EffectBackGround;
    [SerializeField] Image EffectImage;
    public EffectContext EffectContext { get; private set; }
    public void Setup(EffectContext ctx)
    {
        EffectContext = ctx;
        if (ctx.Effect.type == EffectType.Harmful) EffectBackGround.color = Color.red;
        else EffectBackGround.color = Color.green;
        EffectImage.sprite = ctx.Effect.Image;
    }
}