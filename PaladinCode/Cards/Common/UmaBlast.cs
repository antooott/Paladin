using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Paladin.PaladinCode.Cards;

namespace Paladin.PaladinCode.Cards.Common;

public class UmaBlast : PaladinCard
{
    public UmaBlast() : base(3, CardType.Skill, CardRarity.Common, TargetType.Self)
    {
        WithBlock(8);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardBlock(this, play);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["Block"].UpgradeValueBy(3m);
    }
}