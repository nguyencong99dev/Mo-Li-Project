using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemberPanel : MonoBehaviour
{
    [SerializeField] Image Image;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] GameObject Level;
    [SerializeField] GameObject HPBar;
    [SerializeField] GameObject MPBar;
    MonsterStats MonsterStats = new MonsterStats();
    public void SetMemberData(MonsterData member)
    {
        MonsterStats.SetMonsterStats(member);
        // if (MonsterStats != null)
        // {
        Image.sprite = MonsterStats.Member.Image; // Assuming MonsterData has an ID that can be used to fetch the corresponding Monster
        Name.text = MonsterStats.Member.Name; // Assuming MonsterData has an ID that can be used to fetch the corresponding Monster
        // Level.GetComponent<StatBar>().SetValue(0,100); // Example: Set level to 0 out of 100
        // Level.GetComponent<StatText>().SetValue(0,100);
        HPBar.GetComponent<StatBar>().SetValue(MonsterStats.CurrentHP, MonsterStats.MaxHP);
        HPBar.GetComponent<StatText>().SetValue(MonsterStats.CurrentHP, MonsterStats.MaxHP);
        MPBar.GetComponent<StatBar>().SetValue(MonsterStats.CurrentMP, MonsterStats.MaxMP);
        MPBar.GetComponent<StatText>().SetValue(MonsterStats.CurrentMP, MonsterStats.MaxMP);
        // }

    }
}
