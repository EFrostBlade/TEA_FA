using AEAssist.CombatRoutine.Trigger.Node;
using AEAssist.CombatRoutine.Trigger;
using AEAssist.Helper;
using AEAssist.CombatRoutine.Module;
using ECommons.DalamudServices;
using AEAssist;
using System.Numerics;
namespace ScriptTest;

public class st拉飞机面向 : ITriggerScript
{
    public bool Check(ScriptEnv scriptEnv, ITriggerCondParams condParams)
    {
        var target = Svc.Objects.FirstOrDefault(obj => obj.DataId == 11342);
        if (target == null)
        {
            return false;
        }
        else
        {
            Vector3 targetPosition = target.Position;
            Vector3 targetTargetPosition = new Vector3(95, 100, 111);

            var d2Poison = new Vector3(targetPosition.X, 0.00f, targetPosition.Z);
            return true;
        }
    }
}
