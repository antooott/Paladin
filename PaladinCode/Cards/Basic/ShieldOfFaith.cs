using BaseLib.Extensions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using Paladin.PaladinCode.Powers;

namespace Paladin.PaladinCode.Cards.Basic;

public class ShieldOfFaith: PaladinCard
{
    public ShieldOfFaith() : base(0,
        CardType.Skill, CardRarity.Basic,
        TargetType.Self)
    {
        WithBlock(4);
        WithCards(1);
        WithPower<SpellSlotPower>(1);
        WithKeyword(PaladinKeywords.Spell);
    }

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CommonActions.ApplySelf<SpellSlotPower>(this, -DynamicVars["SpellSlotPower"].BaseValue);
        await CommonActions.CardBlock(this, play);
        await CardPileCmd.Draw(choiceContext, this.DynamicVars.Cards.BaseValue, this.Owner);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["Block"].UpgradeValueBy(2);
    }
    
    protected override bool IsPlayable
    {
        get
        {
            ShieldOfFaith shieldOfFaith= this;
            if (shieldOfFaith.Owner.HasPower<SpellSlotPower>() &&  shieldOfFaith.Owner.Creature.GetPowerAmount<SpellSlotPower>() >= shieldOfFaith.CanonicalEnergyCost)
            {
                return true;
            }
            return false;
        }
    }
}