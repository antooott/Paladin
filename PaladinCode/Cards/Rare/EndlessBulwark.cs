using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using Paladin.PaladinCode.Powers;

namespace Paladin.PaladinCode.Cards.Rare;

public class EndlessBulwark : PaladinCard
{
    public EndlessBulwark() : base(2, CardType.Power, CardRarity.Rare, TargetType.Self)
    {
        WithPower<EndlessBulwarkPower>(2);
    }
    
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CommonActions.ApplySelf<EndlessBulwarkPower>(this, DynamicVars["EndlessBulwarkPower"].BaseValue);
    }

    protected override void OnUpgrade()
    {
        AddKeyword(CardKeyword.Innate);
    }
}