using System.Collections.Generic;
using UnityEngine;

public class CombatEffectStatus : MonoBehaviour
{
    [SerializeField] private SlotEffect effectPrefab; // Đổi tên cho rõ ràng đây là Prefab

    public List<EffectContext> ListEffect { get; private set; } = new List<EffectContext>();

    public void AddEffect(EffectContext ctx)
    {
        SlotEffect newEffectInstance = Instantiate(effectPrefab, transform);
        newEffectInstance.Setup(ctx);
        ListEffect.Add(ctx);
    }

    public void RemoveEffect(EffectContext ctx)
    {
        var existEffect = ListEffect.Find(e => e.Effect.EffectId == ctx.Effect.EffectId);

        if (existEffect != null)
        {
            ListEffect.Remove(existEffect);
            var listTransform = transform.GetComponentsInChildren<SlotEffect>();
            foreach (var slot in listTransform)
            {
                if (slot.EffectContext != null && slot.EffectContext.Effect.EffectId == ctx.Effect.EffectId)
                {
                    Destroy(slot.gameObject); // Xóa GameObject khỏi Scene
                    break; // Tìm thấy và xóa xong thì thoát vòng lặp ngay để tối ưu hiệu năng
                }
            }
        }
    }
}
