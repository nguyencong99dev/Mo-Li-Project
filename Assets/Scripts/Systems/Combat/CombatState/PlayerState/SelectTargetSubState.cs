using System.Diagnostics;
using System.Threading.Tasks;

public class SelectTargetSubState : CombatSubState
{
    public SelectTargetSubState(CombatPlayerState state, SBattleContext _result) : base(state, _result) { }
    private TaskCompletionSource<SBattleContext> _tcsTarget;
    public async override Task<SubStateStatus> Execute()
    {
        if (Result.Target == null)
        {
            _tcsTarget = new TaskCompletionSource<SBattleContext>();
            EventBus<SBattleContext>.Subscribe(OnTargetSelected);

            var _result = await _tcsTarget.Task;

            EventBus<SBattleContext>.Unsubscribe(OnTargetSelected);
            EventBus<SBattleContext>.Clear();

            SetResult(_result);
        }
        
        if (Result.Target == null) return SubStateStatus.ChangeAction;

        return SubStateStatus.Completed;
    }
    async void OnTargetSelected(SBattleContext target)
    {
        _tcsTarget?.TrySetResult(target);
    }
}