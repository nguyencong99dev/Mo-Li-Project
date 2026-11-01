using System.Threading.Tasks;

public class ConfirmActionSubState : CombatSubState
{
    public ConfirmActionSubState(CombatPlayerState state,SBattleContext _result) : base(state,_result) { }
    private TaskCompletionSource<SBattleContext> _tcsAction;
    public async override Task<SubStateStatus> Execute()
    {
        _tcsAction = new TaskCompletionSource<SBattleContext>();
        EventBus<SBattleContext>.Subscribe(OnActionSelected);

        var _result = await _tcsAction.Task;

        EventBus<SBattleContext>.Unsubscribe(OnActionSelected);

        EventBus<SBattleContext>.Clear();

        SetResult(_result);
        
        if (Result.Item != null || Result.Skill != null) return SubStateStatus.ChangeAction;

        if (Result.Target != null) return SubStateStatus.Back;

        return SubStateStatus.Completed;
    }
    async void OnActionSelected(SBattleContext confirm)
    {
        _tcsAction?.TrySetResult(confirm);
    }
}