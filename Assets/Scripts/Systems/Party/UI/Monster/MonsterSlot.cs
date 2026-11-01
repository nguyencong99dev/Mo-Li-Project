using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSlot : MonoBehaviour
{
    [SerializeField] Image Image;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] Slider LevelBar;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] Slider HPBar;
    [SerializeField] TextMeshProUGUI HPText;
    [SerializeField] Slider MPBar;
    [SerializeField] TextMeshProUGUI MPText;
    [SerializeField] GameObject AddObject;
    [SerializeField] GameObject InfoObject;
    private MonsterStats _monsterStats = new();
    public void SetMemberData(MonsterData monster)
    {
        if (monster == null)
        {
            AddObject.SetActive(true);
            InfoObject.SetActive(false);
            return;
        }
        ;
        AddObject.SetActive(false);
        InfoObject.SetActive(true);
        SOMonster _monster = ManagerAssets.Instance.MonsterDB.GetById(monster.ID);
        _monsterStats.Monster = _monster;
        _monsterStats.SetMonsterStats(monster);
        Image.sprite = _monsterStats.Monster.FrontImage;
        Name.text = _monsterStats.Monster.Name;
        // UpdateStat(LevelBar, LevelText, monster.Level, _monster.MaxLevel);
        UpdateStat(HPBar, HPText, _monsterStats.CurrentHP, _monsterStats.MaxHP);
        UpdateStat(MPBar, MPText, _monsterStats.CurrentMP, _monsterStats.MaxMP);
    }
    private void UpdateStat(Slider _slider, TextMeshProUGUI _text, float current, float max)
    {
        if (_slider == null || _text == null) return;
        _slider.maxValue = max;
        _slider.value = current;
        _text.text = $"{current}/{max}";
    }
}
