using AEAssist.CombatRoutine.Trigger.Node;
using AEAssist.CombatRoutine.Trigger;
using AEAssist.Helper;
using AEAssist.CombatRoutine.Module;
using ECommons.DalamudServices;
using AEAssist;
using System.Numerics;
namespace ScriptTest;

public class 左右刀判断 : ITriggerScript
{
    public bool Check(ScriptEnv scriptEnv, ITriggerCondParams condParams)
    {
        // 查找所有 DataId 为 11341 的目标
        var targets = Svc.Objects.Where(obj => obj.DataId == 11341).ToList();
        if (targets.Count == 0)
        {
            return false;
        }
        if (targets.Count == 2)
        {
            var target0PosX = Math.Round(targets[0].Position.X);
            var target1PosX = Math.Round(targets[1].Position.X);
            var target0PosZ = Math.Round(targets[0].Position.Z);
            var target1PosZ = Math.Round(targets[1].Position.Z);
            if (target0PosX == 100 && target1PosX == 100)
            {
                LogHelper.Print("南北飞轮,MTST");
                Share.DebugPointWithText.Clear();
                Share.DebugPointWithText.Add("MT", new Vector3(85.45f, 0.00f, 87.79f));
                RemoteControlHelper.SetPos("MT", new Vector3(85.45f, 0.00f, 87.79f));
                Share.DebugPointWithText.Add("D3", new Vector3(81.51f, 0.00f, 95.62f));
                RemoteControlHelper.SetPos("D3", new Vector3(81.51f, 0.00f, 95.62f));
                Share.DebugPointWithText.Add("H1", new Vector3(81.51f, 0.00f, 104.38f));
                RemoteControlHelper.SetPos("H1", new Vector3(81.51f, 0.00f, 104.38f));
                Share.DebugPointWithText.Add("D2", new Vector3(85.45f, 0.00f, 112.21f));
                RemoteControlHelper.SetPos("D2", new Vector3(85.45f, 0.00f, 112.21f));
                Share.DebugPointWithText.Add("D1", new Vector3(114.55f, 0.00f, 87.79f));
                RemoteControlHelper.SetPos("D1", new Vector3(114.55f, 0.00f, 87.79f));
                Share.DebugPointWithText.Add("H2", new Vector3(118.49f, 0.00f, 95.62f));
                RemoteControlHelper.SetPos("H2", new Vector3(118.49f, 0.00f, 95.62f));
                Share.DebugPointWithText.Add("D4", new Vector3(118.49f, 0.00f, 104.38f));
                RemoteControlHelper.SetPos("D4", new Vector3(118.49f, 0.00f, 104.38f));
                Share.DebugPointWithText.Add("ST", new Vector3(114.55f, 0.00f, 112.21f));
                RemoteControlHelper.SetPos("ST", new Vector3(114.55f, 0.00f, 112.21f));
                return true;
            }
            if (target0PosZ == 100 && target1PosZ == 100)
            {
                LogHelper.Print("东西飞轮,H1H2");
                Share.DebugPointWithText.Clear();
                Share.DebugPointWithText.Add("D3", new Vector3(87.79f, 0.00f, 85.45f));
                RemoteControlHelper.SetPos("D3", new Vector3(87.79f, 0.00f, 85.45f));
                Share.DebugPointWithText.Add("MT", new Vector3(95.62f, 0.00f, 81.51f));
                RemoteControlHelper.SetPos("MT", new Vector3(95.62f, 0.00f, 81.51f));
                Share.DebugPointWithText.Add("D1", new Vector3(104.38f, 0.00f, 81.51f));
                RemoteControlHelper.SetPos("D1", new Vector3(104.38f, 0.00f, 81.51f));
                Share.DebugPointWithText.Add("H2", new Vector3(112.21f, 0.00f, 85.45f));
                RemoteControlHelper.SetPos("H2", new Vector3(112.21f, 0.00f, 85.45f));
                Share.DebugPointWithText.Add("H1", new Vector3(87.79f, 0.00f, 114.55f));
                RemoteControlHelper.SetPos("H1", new Vector3(87.79f, 0.00f, 114.55f));
                Share.DebugPointWithText.Add("D2", new Vector3(95.62f, 0.00f, 118.49f));
                RemoteControlHelper.SetPos("D2", new Vector3(95.62f, 0.00f, 118.49f));
                Share.DebugPointWithText.Add("ST", new Vector3(104.38f, 0.00f, 118.49f));
                RemoteControlHelper.SetPos("ST", new Vector3(104.38f, 0.00f, 118.49f));
                Share.DebugPointWithText.Add("D4", new Vector3(112.21f, 0.00f, 114.55f));
                RemoteControlHelper.SetPos("D4", new Vector3(112.21f, 0.00f, 114.55f));
                return true;
            }
            if ((target0PosX == 85 && target1PosZ == 85) || (target0PosZ == 85 && target1PosX == 85))
            {
                LogHelper.Print("东北西南飞轮,D1D2");
                Share.DebugPointWithText.Clear();
                Share.DebugPointWithText.Add("D1", new Vector3(98.34f, 0.00f, 81.07f));
                RemoteControlHelper.SetPos("D1", new Vector3(98.34f, 0.00f, 81.07f));
                Share.DebugPointWithText.Add("MT", new Vector3(90.03f, 0.00f, 83.83f));
                RemoteControlHelper.SetPos("MT", new Vector3(90.03f, 0.00f, 83.83f));
                Share.DebugPointWithText.Add("D3", new Vector3(83.83f, 0.00f, 90.03f));
                RemoteControlHelper.SetPos("D3", new Vector3(83.83f, 0.00f, 90.03f));
                Share.DebugPointWithText.Add("H1", new Vector3(81.07f, 0.00f, 98.34f));
                RemoteControlHelper.SetPos("H1", new Vector3(81.07f, 0.00f, 98.34f));
                Share.DebugPointWithText.Add("D2", new Vector3(101.66f, 0.00f, 118.93f));
                RemoteControlHelper.SetPos("D2", new Vector3(101.66f, 0.00f, 118.93f));
                Share.DebugPointWithText.Add("ST", new Vector3(109.97f, 0.00f, 116.17f));
                RemoteControlHelper.SetPos("ST", new Vector3(109.97f, 0.00f, 116.17f));
                Share.DebugPointWithText.Add("D4", new Vector3(116.17f, 0.00f, 109.97f));
                RemoteControlHelper.SetPos("D4", new Vector3(116.17f, 0.00f, 109.97f));
                Share.DebugPointWithText.Add("H2", new Vector3(118.93f, 0.00f, 101.66f));
                RemoteControlHelper.SetPos("H2", new Vector3(118.93f, 0.00f, 101.66f));
                return true;
            }
            if ((target0PosX == 85 && target1PosZ == 115) || (target0PosZ == 115 && target1PosX == 85))
            {
                LogHelper.Print("西北东南飞轮,D3D4");
                Share.DebugPointWithText.Clear();
                Share.DebugPointWithText.Add("D3", new Vector3(101.66f, 0.00f, 81.07f));
                RemoteControlHelper.SetPos("D3", new Vector3(101.66f, 0.00f, 81.07f));
                Share.DebugPointWithText.Add("MT", new Vector3(109.97f, 0.00f, 83.83f));
                RemoteControlHelper.SetPos("MT", new Vector3(109.97f, 0.00f, 83.83f));
                Share.DebugPointWithText.Add("D1", new Vector3(116.17f, 0.00f, 90.03f));
                RemoteControlHelper.SetPos("D1", new Vector3(116.17f, 0.00f, 90.03f));
                Share.DebugPointWithText.Add("H2", new Vector3(118.93f, 0.00f, 98.34f));
                RemoteControlHelper.SetPos("H2", new Vector3(118.93f, 0.00f, 98.34f));
                Share.DebugPointWithText.Add("D4", new Vector3(98.34f, 0.00f, 118.93f));
                RemoteControlHelper.SetPos("D4", new Vector3(98.34f, 0.00f, 118.93f));
                Share.DebugPointWithText.Add("ST", new Vector3(90.03f, 0.00f, 116.17f));
                RemoteControlHelper.SetPos("ST", new Vector3(90.03f, 0.00f, 116.17f));
                Share.DebugPointWithText.Add("D2", new Vector3(83.83f, 0.00f, 109.97f));
                RemoteControlHelper.SetPos("D2", new Vector3(83.83f, 0.00f, 109.97f));
                Share.DebugPointWithText.Add("H1", new Vector3(81.07f, 0.00f, 101.66f));
                RemoteControlHelper.SetPos("H1", new Vector3(81.07f, 0.00f, 101.66f));
                return true;
            }
        }
        return true;
    }
}
