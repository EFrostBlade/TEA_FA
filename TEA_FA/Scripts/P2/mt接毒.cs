using AEAssist.CombatRoutine.Trigger.Node;
using AEAssist.CombatRoutine.Trigger;
using AEAssist.Helper;
using AEAssist.CombatRoutine.Module;
using ECommons.DalamudServices;
using AEAssist;
using System.Numerics;
using Dalamud.Game.ClientState.Objects.Types;
using AEAssist.Extension;
namespace ScriptTest;

public class mt接毒 : ITriggerScript
{
    public IBattleChara MT;
    public bool Completed = false;
    // 锁对象
    public readonly object _executionLock = new object();

    // 使用整型标记进行原子操作，0：空闲，1：处理中
    public int _isProcessing = 0;
    public bool Check(ScriptEnv scriptEnv, ITriggerCondParams condParams)
    {
        // 已经完成，则直接返回
        if (Completed) return true;

        // 如果已有任务在处理中，则直接返回当前状态，不重复调度
        if (Interlocked.CompareExchange(ref _isProcessing, 1, 0) != 0)
            return Completed;

        Task.Run(() =>
        {
            try
            {
                lock (_executionLock)
                {
                    MT = scriptEnv.KV["MT"] as IBattleChara;
                    if (MT.HasAura(2223) || MT.HasAura(2222) || MT.HasAura(2138) || MT.HasAura(2137))
                    {
                        Completed = true;
                    }
                }
            }
            catch
            {
                // 处理异常
                LogHelper.PrintError("mt接毒处理异常");
            }
            finally
            {
                // 处理结束后重置标记
                Interlocked.Exchange(ref _isProcessing, 0);
            }
        });
        return Completed;
    }
}
