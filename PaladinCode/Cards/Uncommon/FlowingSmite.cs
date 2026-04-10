using BaseLib.Extensions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using Paladin.PaladinCode.Character;
using Paladin.PaladinCode.Powers;

namespace Paladin.PaladinCode.Cards.Uncommon;
[Pool(typeof(PaladinCardPool))]
#nullable enable
public class FlowingSmite : PaladinCard
{
    public FlowingSmite() : base(1,
        CardType.Skill, CardRarity.Uncommon,
        TargetType.Self)
    {
        WithPower<VigorPower>(4);
        WithPower<FlowingSmitePower>(1);
    }
    
    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        FlowingSmite cardSource = this;
        await CreatureCmd.TriggerAnim(cardSource.Owner.Creature, "Cast", cardSource.Owner.Character.CastAnimDelay);
        await CommonActions.ApplySelf<VigorPower>(this, DynamicVars["VigorPower"].BaseValue);
        await PowerCmd.Apply<FlowingSmitePower>(cardSource.Owner.Creature, DynamicVars["FlowingSmitePower"].BaseValue, cardSource.Owner.Creature, (CardModel) cardSource);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["VigorPower"].UpgradeValueBy(4);
    }
}