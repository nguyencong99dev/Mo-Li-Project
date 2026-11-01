using UnityEngine;
using UnityEngine.UI;

public class HUDParty : MonoBehaviour
{
    [SerializeField] private BuildSlot _party;
    void Awake()
    {

    }
    void OnEnable()
    {
        EventBus<SPlayerParty>.Subscribe(InitMemberData);
    }
    void OnDisable()
    {
        EventBus<SPlayerParty>.Unsubscribe(InitMemberData);
    }
    public void InitMemberData(SPlayerParty data)
    {
        _party.InitMonsterData(data.Party);
    }
}
