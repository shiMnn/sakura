using UnityEngine;

public class TaskPlayPhase : TaskNodeBase {
    public override bool Setup() {
        return true;
    }

    public override bool Exec() {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {// ターン終了
            TaskManager.Instance.Next(this, new TaskTurnEnd());
            return true;
        }
        return false;
    }

    public override bool Finish() {
        return true;
    }
}