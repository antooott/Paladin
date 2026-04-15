using BaseLib.Extensions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using Paladin.PaladinCode.Cards;
using Paladin.PaladinCode.Powers;
using Paladin.PaladinCode.SpellSlots;

namespace Paladin.PaladinCode.Cards.Basic;

public class DivineSmite : PaladinCard
{
    public DivineSmite() : base(1,
        CardType.Skill, CardRarity.Basic,
        TargetType.Self)
    {
        WithPower<VigorPower>(6);
        WithPower<SpellSlotPower>(1);
        WithKeyword(PaladinKeywords.SpellLvl1);
    }

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CommonActions.ApplySelf<VigorPower>(this, DynamicVars["VigorPower"].BaseValue);
        await CommonActions.ApplySelf<SpellSlotPower>(this, -DynamicVars["SpellSlotPower"].BaseValue);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["VigorPower"].UpgradeValueBy(3);
    }
    
    protected override bool IsPlayable
    {
        get
        {
            DivineSmite divineSmite = this;
            if (divineSmite.Owner.HasPower<SpellSlotPower>() &&  divineSmite.Owner.Creature.GetPowerAmount<SpellSlotPower>() >= divineSmite.CanonicalEnergyCost)
            {
                return true;
            }
            return false;
        }
    }
}