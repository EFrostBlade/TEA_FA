using AEAssist.CombatRoutine.Trigger.Node;
using AEAssist.CombatRoutine.Trigger;
using AEAssist.Helper;
using AEAssist.CombatRoutine.Module;
using ECommons.DalamudServices;
using AEAssist;
using System.Numerics;
namespace ScriptTest;

public class mt拉残暴正义号面向 : ITriggerScript
{
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
                    var target = Svc.Objects.FirstOrDefault(obj => obj.DataId == 11340);
                    if (target != null)
                    {
                        Vector3 targetPosition = target.Position;
                        Vector3 targetTargetPosition = new Vector3(95, 0, 89);
                        Vector3 direction = Vector3.Normalize(targetTargetPosition - targetPosition);
                        Vector3 stPoison = targetTargetPosition + direction * 3;
                        Vector3 d2Poison = new Vector3(targetPosition.X, 0.00f, targetPosition.Z);
                        if (Share.DebugPointWithText.ContainsKey("MT"))
                        {
                            Share.DebugPointWithText.Remove("MT");
                        }
                        Share.DebugPointWithText.Add("MT", stPoison);
                        RemoteControlHelper.SetPos("MT", stPoison);
                        Completed = true;
                    }
                }
            }
            catch
            {
                // 处理异常
                LogHelper.PrintError("mt拉残暴正义号面向处理异常");
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
