using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelMember : MonoBehaviour
{
    [SerializeField] Image Image;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] GameObject Level;
    [SerializeField] GameObject HPBar;
    [SerializeField] GameObject MPBar;

    public void SetMemberData(MonsterData member)
    {
        MonsterStats monsterStats = gameObject.AddComponent<MonsterStats>();
        monsterStats.SetMonsterStats(member);
        // if (MonsterStats != null)
        // {
        Image.sprite = monsterStats.Monster.FrontImage; // Assuming MonsterData has an ID that can be used to fetch the corresponding Monster
        Name.text = monsterStats.Monster.Name; // Assuming MonsterData has an ID that can be used to fetch the corresponding Monster
        // Level.GetComponent<StatBar>().SetValue(0,100); // Example: Set level to 0 out of 100
        // Level.GetComponent<StatText>().SetValue(0,100);
        HPBar.GetComponent<StatBar>().SetValue(monsterStats.CurrentHP, monsterStats.MaxHP);
        HPBar.GetComponent<StatText>().SetValue(monsterStats.CurrentHP, monsterStats.MaxHP);
        MPBar.GetComponent<StatBar>().SetValue(monsterStats.CurrentMP, monsterStats.MaxMP);
        MPBar.GetComponent<StatText>().SetValue(monsterStats.CurrentMP, monsterStats.MaxMP);
        // }

    }
}
