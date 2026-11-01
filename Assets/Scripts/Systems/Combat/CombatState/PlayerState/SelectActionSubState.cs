using System.Threading.Tasks;

public class SelectActionSubState : CombatSubState
{
    public SelectActionSubState(CombatPlayerState state, SBattleContext _result) : base(state, _result) { }
    private TaskCompletionSource<SBattleContext> _tcsAction;
    public async override Task<SubStateStatus> Execute()
    {
        if (Result.Skill == null && Result.Item == null)
        {
            _tcsAction = new TaskCompletionSource<SBattleContext>();
            EventBus<SBattleContext>.Subscribe(OnActionSelected);

            var _result = await _tcsAction.Task;

            EventBus<SBattleContext>.Unsubscribe(OnActionSelected);
            EventBus<SBattleContext>.Clear();
            
            SetResult(_result);
        }
        
        if (Result.Action != ActionType.None)
        {
            return SubStateStatus.Completed;
        }
        else
        {
            return SubStateStatus.Cancel;
        }
    }
    async void OnActionSelected(SBattleContext battleAction)
    {
        _tcsAction?.TrySetResult(battleAction);
    }
}