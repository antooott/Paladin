using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Paladin.PaladinCode.Character;
using Paladin.PaladinCode.Powers;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;
using Paladin.PaladinCode.Cards;
using Paladin.PaladinCode.SpellSlots;

namespace Paladin.PaladinCode.Cards.Common;

public sealed class SearingSmite : PaladinCard
{
    public SearingSmite() : base(1, CardType.Skill, CardRarity.Common, TargetType.Self)
    {
        WithPower<VigorPower>(6);
        WithPower<SearingSmitePower>(3);
        WithPower<SpellSlotPower>(1);
        WithKeyword(PaladinKeywords.SpellLvl1);
        WithTags(PaladinTags.Smite);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.ApplySelf<VigorPower>(this, DynamicVars["VigorPower"].BaseValue);
        await Cmd.Wait(0.1f);
        await CommonActions.ApplySelf<SearingSmitePower>(this, DynamicVars["SearingSmitePower"].BaseValue);
        await CommonActions.ApplySelf<SpellSlotPower>(this, -DynamicVars["SpellSlotPower"].BaseValue);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["VigorPower"].UpgradeValueBy(2m);
        DynamicVars["SearingSmitePower"].UpgradeValueBy(1m);
    }
    
    protected override bool IsPlayable
    {
        get
        {
            SearingSmite searingSmite = this;
            if (searingSmite.Owner.HasPower<SpellSlotPower>() &&  searingSmite.Owner.Creature.GetPowerAmount<SpellSlotPower>() >= searingSmite.CanonicalEnergyCost)
            {
                return true;
            }
            return false;
        }
    }
}