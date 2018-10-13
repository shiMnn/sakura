public class CardCase {
    public CardBase Card { get; private set; }

    public CardCase() {
        Card = null;
    }

    public void Set(CardBase card) {
        if (this.Card != null) { return; }
        this.Card = card;
    }

    public CardBase Remove() {
        CardBase temp = this.Card;
        if (temp != null) {
            this.Card = null;
            return temp;
        } else {
            return null;
        }
    }

    public bool IsEmpty() {
        return (this.Card == null);
    }
}