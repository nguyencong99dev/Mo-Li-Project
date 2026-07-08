using UnityEngine;
using UnityEngine.UI;

public class HUDParty : MonoBehaviour
{
    [SerializeField] private BuildSlotPartyMember _partyMembers;
    public void InitPartyMember(SPlayerParty data)
    {
        _partyMembers.InitMemberData(data._Party);
    }
}
