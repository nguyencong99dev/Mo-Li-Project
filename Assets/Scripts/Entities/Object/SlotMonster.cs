using UnityEngine.UI;
using UnityEngine;

public struct SMonsterTarget
{
    public MonsterStats target;
}
public class SlotMonster : MonoBehaviour
{
    [SerializeField] SpriteRenderer _image;
    [SerializeField] StatBar _hpBar;
    [SerializeField] StatBar _mpBar;
    [SerializeField] Button _button;
    public void SetMonterStats(MonsterStats stats, bool isPlayerParty)
    {
        if (_image != null)
        {
            if (!isPlayerParty)
            {
                _image.sprite = stats != null ? stats.Monster.FrontImage : null;
            }
            else
            {
                _image.sprite = stats != null ? stats.Monster.BackImage : null;
            }
        }
        _hpBar.SetValue(stats.CurrentHP, stats.MaxHP);
        _mpBar.SetValue(stats.CurrentMP, stats.MaxMP);
        _button.onClick.AddListener(() =>
        {
            EventBus<SMonsterTarget>.Publish(new SMonsterTarget{target = stats});
        });
        stats.OnHPChanged += _hpBar.SetValue;
    }
}
