public class TaskTurnStart : TaskNodeBase {
    public override bool Setup() {
        return true;
    }

    public override bool Exec() {
        return true;
    }

    public override bool Finish() {
        Player turnPlayer = PlayerManager.Instance.GetTurnPlayer();

        // ターン開始時、とりあえず2枚引いてみる
        int turnStartDrawNum = 2;
        TaskNodeBase baseTask = this;
        TaskNodeBase addTask = new TaskDrawCard(turnPlayer.ID, turnStartDrawNum);
        TaskManager.Instance.Next(baseTask, addTask);
        baseTask = addTask;
        addTask = new TaskPlayPhase();
        TaskManager.Instance.Next(baseTask, addTask);
        return true;
    }
}