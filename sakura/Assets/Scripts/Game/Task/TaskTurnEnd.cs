public class TaskTurnEnd : TaskNodeBase {
    public override bool Setup() {
        return true;
    }

    public override bool Exec() {
        return true;
    }

    public override bool Finish() {
        TaskManager.Instance.Next(this, new TaskTurnStart());
        return true;
    }
}