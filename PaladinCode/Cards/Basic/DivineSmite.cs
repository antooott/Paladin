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

namespace Paladin.PaladinCode.Cards.Basic;

public class DivineSmite : PaladinCard
{
    public DivineSmite() : base(1,
        CardType.Skill, CardRarity.Basic,
        TargetType.Self)
    {
        WithPower<VigorPower>(6);
    }

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        //await CommonActions.ApplySelf<StrengthPower>(this, DynamicVars.Strength.BaseValue);
        await CommonActions.ApplySelf<VigorPower>(this, DynamicVars["VigorPower"].BaseValue);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["VigorPower"].UpgradeValueBy(3);
    }
}