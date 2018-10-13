
using System;

public class GameRandom : SingletonClass<GameRandom> {
    public Random GlobalRandom { get; private set; }

    public void Setup(int globalSeed) {
        GlobalRandom = new Random(globalSeed);
    }
}