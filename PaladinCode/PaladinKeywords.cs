using BaseLib.Patches.Content;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models;

namespace Paladin.PaladinCode;

public static class PaladinKeywords
{
    [CustomEnum, KeywordProperties(AutoKeywordPosition.Before)]
    public static CardKeyword Spell;

    public static bool IsSpellLvl1(this CardModel card)
    {
        return card.Keywords.Contains(Spell);
    }
}