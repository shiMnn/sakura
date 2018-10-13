public class TaskPlayPhase : TaskNodeBase {
    public override bool Setup() {
        return true;
    }

    public override bool Exec() {
        return false;
    }

    public override bool Finish() {
        TaskManager.Instance.Next(this, new TaskTurnEnd());
        return true;
    }
}