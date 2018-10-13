public class Player {
    public DeckManager Deck { get; private set; }
    public HandManager Hand { get; private set; }
    public FieldManager Field { get; private set; }

    public PlayerID ID { get; private set; }
    public bool IsMyTurn { get; private set; }

    public Player(PlayerID id) {
        this.ID = id;
        Deck = new DeckManager();
        Hand = new HandManager();
        Field = new FieldManager();

        IsMyTurn = false;
    }

    public void OnMyTurn() {
        IsMyTurn = true;
    }

    public void OffMyTurn() {
        IsMyTurn = false;
    }
}