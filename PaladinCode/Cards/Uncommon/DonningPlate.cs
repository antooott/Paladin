using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Paladin.PaladinCode.Cards.Uncommon;


public sealed class DonningPlate : PaladinCard
{
    public DonningPlate()
        : base(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)

    {
        WithPower<PlatingPower>(6);
        WithPower<VulnerablePower>(2);
    }
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        DonningPlate cardSource = this;
        await CreatureCmd.TriggerAnim(cardSource.Owner.Creature, "Cast", cardSource.Owner.Character.CastAnimDelay); 
        PlatingPower? platingPower = await PowerCmd.Apply<PlatingPower>(cardSource.Owner.Creature, cardSource.DynamicVars["PlatingPower"].BaseValue, cardSource.Owner.Creature, (CardModel) cardSource); 
        Task<VulnerablePower?> vulnerablePower = PowerCmd.Apply<VulnerablePower>(cardSource.Owner.Creature, cardSource.DynamicVars["VulnerablePower"].BaseValue, cardSource.Owner.Creature, (CardModel) cardSource);
    }
    
    protected override void OnUpgrade()
    {
        DynamicVars["PlatingPower"].UpgradeValueBy(1m);
        DynamicVars["VulnerablePower"].UpgradeValueBy(-1m);
    }
    
}