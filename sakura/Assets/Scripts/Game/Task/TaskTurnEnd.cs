public class TaskTurnEnd : TaskNodeBase {
    public override bool Setup() {
        // プレイヤーの権利を対戦相手に渡す
        PlayerManager.Instance.TurnChange();

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