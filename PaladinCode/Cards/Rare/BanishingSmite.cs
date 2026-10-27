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

namespace Paladin.PaladinCode.Cards.Rare;

public class BanishingSmite : PaladinCard
{
    public BanishingSmite() : base(3, CardType.Skill, CardRarity.Rare, TargetType.Self)
    {
        WithPower<VigorPower>(6);
        WithPower<BanishingSmitePower>(2);
        WithPower<SpellSlotPower>(1);
        WithKeyword(PaladinKeywords.Spell);
        WithTags(PaladinTags.Smite);
    }
    
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.ApplySelf<VigorPower>(this, DynamicVars["VigorPower"].BaseValue);
        await Cmd.Wait(0.1f);
        await CommonActions.ApplySelf<BanishingSmitePower>(this, DynamicVars["BanishingSmitePower"].BaseValue);
        await CommonActions.ApplySelf<SpellSlotPower>(this, -DynamicVars["SpellSlotPower"].BaseValue);
    }
    
    protected override void OnUpgrade()
    {
        DynamicVars["VigorPower"].UpgradeValueBy(2m);
        DynamicVars["BanishingSmitePower"].UpgradeValueBy(1m);
    }
    
    protected override bool IsPlayable
    {
        get
        {
            BanishingSmite banishingSmite = this;
            if (banishingSmite.Owner.HasPower<SpellSlotPower>() &&  banishingSmite.Owner.Creature.GetPowerAmount<SpellSlotPower>() >= 1)
            {
                return true;
            }
            return false;
        }
    }
}