using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionQueue
{
    private readonly LinkedList<ICombatAction> list = new();
    private bool isRunning;

    // public ActionQueue(SBattleContext ctx) => this.ctx = ctx;

    public void EnqueueLast(ICombatAction a) => list.AddLast(a);

    // Chèn một nhóm action lên đầu nhưng GIỮ đúng thứ tự (reaction như Faint dùng cái này)
    public void EnqueueFront(params ICombatAction[] actions)
    {
        for (int i = actions.Length - 1; i >= 0; i--)
            list.AddFirst(actions[i]);
    }

    // "Drain" (xả) hàng đợi: chạy tới khi rỗng, kể cả action mới được chèn thêm giữa chừng
    public async Task RunUntilEmpty(SBattleContext ctx)
    {
        if (isRunning) return;   // chống chạy lồng nhau (reentrancy)
        isRunning = true;
        try
        {
            while (list.Count > 0)
            {
                var action = list.First.Value;
                list.RemoveFirst();
                await action.ExecuteAsync(ctx);
            }
        }
        finally { isRunning = false; }
    }

    public void Clear() => list.Clear();
}