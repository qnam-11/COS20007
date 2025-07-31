using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosAdventure
{
    public enum GameState
    {
        MainMenu,
        GameInstruction,
        ChoosingCharacter,
        NotAbleToContinue,
        DuringStage,
        BuffPurchase,
        WinGame,
        LoseGame
    }
}
