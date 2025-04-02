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

public class 第一次水雷分摊 : ITriggerScript
{
    public IBattleChara 水奶;
    public string 水奶名字 = "";
    public string 水奶职能 = "";
    public IBattleChara 雷D;
    public string 雷D名字 = "";
    public string 雷D职能 = "";
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

                    foreach (IBattleChara patyer in PartyHelper.Party)
                    {
                        if (patyer.HasAura(2142))
                        {
                            水奶 = patyer;
                            水奶名字 = patyer.Name.TextValue;
                            水奶职能 = scriptEnv.KV[水奶名字].ToString();
                            LogHelper.Print("水奶:" + 水奶职能 + " " + 水奶名字);
                            continue;
                        }
                        if (patyer.HasAura(2143))
                        {
                            雷D = patyer;
                            雷D名字 = patyer.Name.TextValue;
                            雷D职能 = scriptEnv.KV[雷D名字].ToString();
                            LogHelper.Print("雷D：" + 雷D职能 + " " + 雷D名字);
                        }
                    }
                    if (水奶 != null && 雷D != null)
                    {
                        if (Share.DebugPointWithText.ContainsKey("H1"))
                        {
                            Share.DebugPointWithText.Remove("H1");
                        }
                        if (Share.DebugPointWithText.ContainsKey("H2"))
                        {
                            Share.DebugPointWithText.Remove("H2");
                        }
                        if (Share.DebugPointWithText.ContainsKey("D1"))
                        {
                            Share.DebugPointWithText.Remove("D1");
                        }
                        if (Share.DebugPointWithText.ContainsKey("D2"))
                        {
                            Share.DebugPointWithText.Remove("D2");
                        }
                        if (Share.DebugPointWithText.ContainsKey("D3"))
                        {
                            Share.DebugPointWithText.Remove("D3");
                        }
                        if (Share.DebugPointWithText.ContainsKey("D4"))
                        {
                            Share.DebugPointWithText.Remove("D4");
                        }
                        Share.DebugPointWithText.Add(水奶职能, new Vector3(85, 0, 100));
                        RemoteControlHelper.SetPos(水奶职能, new Vector3(85, 0, 100));
                        if (水奶职能 == "H1")
                        {
                            Share.DebugPointWithText.Add("H2", new Vector3(105, 0, 100));
                            RemoteControlHelper.SetPos("H2", new Vector3(105, 0, 100));
                        }
                        else
                        {
                            Share.DebugPointWithText.Add("H1", new Vector3(105, 0, 100));
                            RemoteControlHelper.SetPos("H1", new Vector3(105, 0, 100));
                        }
                        Share.DebugPointWithText.Add(雷D职能, new Vector3(103, 0, 100));
                        RemoteControlHelper.SetPos(雷D职能, new Vector3(103, 0, 100));
                        List<string> D = new List<string> { "D1", "D2", "D3", "D4" };
                        D.Remove(雷D职能);
                        List<Vector3> DPosition = new List<Vector3> { new Vector3(83, 0, 100), new Vector3(87, 0, 100), new Vector3(85, 0, 98) };
                        int i = 0;
                        foreach (string d in D)
                        {
                            Share.DebugPointWithText.Add(d, DPosition[i]);
                            RemoteControlHelper.SetPos(d, DPosition[i]);
                            i++;
                        }
                        Completed = true;
                    }
                }
            }
            catch (Exception e)
            {
                // 处理异常
                LogHelper.PrintError($"第一次水雷分摊处理异常:{e}");
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
