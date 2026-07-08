using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildSlotPartyMember : MonoBehaviour
{
    public void InitMemberData(List<MonsterData> list)
    {
        foreach (MonsterData monster in list)
        {
            int idx = list.IndexOf(monster);
            UIHandleMemberPanel hudMember = transform.GetChild(idx).GetComponent<UIHandleMemberPanel>();
            if (hudMember != null)
            {
                MemberPanel memberPanelScript = transform.GetChild(idx).GetComponent<MemberPanel>();
                if (memberPanelScript != null)
                {
                    hudMember.InitBtn.gameObject.SetActive(false);
                    memberPanelScript?.SetMemberData(monster);
                    hudMember.MemberPanel.SetActive(true);
                }
            }
        }
    }
}
