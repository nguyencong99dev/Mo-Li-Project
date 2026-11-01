public enum BattleState
{
    BattleStart,
    PlayerTurn,
    EnemyTurn,
    ExecuteAction,
    CheckBattleEnd,
    BattleEnd
}
public enum SubStateStatus
{   Completed,
    Back,
    ChangeAction,
    Cancel
}
public enum SubStateAction
{   
    SelectedAction= 1,
    SelectedTarget =2,
    ConfirmAction = 3,
    End = 4,
}
public enum ActionType
{
    None,
    Skill,
    Item,
    Capture,
    Flee,
}
public enum ActionState
{
    Add,
    Remove,
}