using System.Collections.Generic;
public class DeckManager {
    public List<CardCase> CardCases { get; private set; }

    public DeckManager() {
        CardCases = new List<CardCase>();
        for(int i = 0; i < GameDef.DECK_NUM; ++i) {
            CardCases.Add(new CardCase());
        }
    }

    public void AddCard(CardBase card) {
        int size = CardCases.Count;
        for (int i = 0; i < size; ++i) {
            var cardCase = CardCases[i];
            if (cardCase.IsEmpty()) {
                cardCase.Set(card);
                break;
            }
        }
    }

    public void Shuffle() {
        int left = CardCases.Count;
        while(left > 1) {
            --left;
            int right = GameRandom.Instance.GlobalRandom.Next(left + 1);
            CardBase rightCard = CardCases[right].Remove();
            CardBase leftCard = CardCases[left].Remove();
            CardCases[right].Set(leftCard);
            CardCases[left].Set(rightCard);
        }
    }

    public CardBase PickTop() {
        var card = CardCases[0].Remove();

        int size = CardCases.Count;
        for(int i = 0; i < size; ++i) {
            if (i == (size - 1)) {
                CardCases[i].Remove();
            } else {
                CardCases[i].Set(CardCases[i + 1].Remove());
            }
        }
        return card;
    }
}
