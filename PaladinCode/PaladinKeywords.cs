using BaseLib.Patches.Content;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models;

namespace Paladin.PaladinCode;

public static class PaladinKeywords
{
    [CustomEnum, KeywordProperties(AutoKeywordPosition.Before)]
    public static CardKeyword SpellLvl1;

    public static bool IsSpellLvl1(this CardModel card)
    {
        return card.Keywords.Contains(SpellLvl1);
    }
    
    [CustomEnum, KeywordProperties(AutoKeywordPosition.Before)]
    public static CardKeyword SpellLvl2;

    public static bool IsSpellLvl2(this CardModel card)
    {
        return card.Keywords.Contains(SpellLvl2);
    }
}