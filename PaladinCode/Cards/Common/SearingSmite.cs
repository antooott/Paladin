using BaseLib.Abstracts;
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
using Paladin.PaladinCode.Cards;

namespace Paladin.PaladinCode.Cards.Common;

public sealed class SearingSmite : PaladinCard
{
    public SearingSmite() : base(0, CardType.Skill, CardRarity.Common, TargetType.Self)
    {
        WithPower<SearingSmitePower>(3);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.ApplySelf<SearingSmitePower>(this, DynamicVars["SearingSmitePower"].BaseValue);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["SearingSmitePower"].UpgradeValueBy(1m);
    }
}