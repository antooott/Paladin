using BaseLib.Abstracts;
using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace Paladin.PaladinCode.Powers;

public class SearingSmitePower: CustomPowerModel
{

    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
    
    public override async Task AfterDamageGiven(
        PlayerChoiceContext choiceContext,
        Creature? dealer,
        DamageResult result,
        ValueProp props,
        Creature target,
        CardModel? cardSource)
    {
        SearingSmitePower searingSmitePower = this;
        if (dealer == null || dealer != searingSmitePower.Owner && dealer.PetOwner?.Creature != searingSmitePower.Owner || !props.IsPoweredAttack_())
            return;
        BurnPower burnPower = await PowerCmd.Apply<BurnPower>(target, (Decimal) (searingSmitePower.Amount), searingSmitePower.Owner, (CardModel) null);
        await PowerCmd.Remove((PowerModel)this);
    }
}