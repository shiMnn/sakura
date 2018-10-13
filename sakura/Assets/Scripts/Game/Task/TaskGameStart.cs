public class TaskGameStart : TaskNodeBase {
    public override bool Setup() {
        //TODO: 先攻/後攻を決める、がとりあえずは自プレイヤーを先攻にする
        PlayerManager.Instance.GetPlayer(PlayerID.Self).OnMyTurn();

        // 互いにデッキをシャッフルする(ターンプレイヤーから)
        Player turnPlayer = PlayerManager.Instance.GetTurnPlayer();
        Player waitPlayer = PlayerManager.Instance.GetOpponentPlayer(turnPlayer);
        turnPlayer.Deck.Shuffle();
        waitPlayer.Deck.Shuffle();


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