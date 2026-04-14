using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace Paladin.PaladinCode.Powers;

public sealed class BurnPower : PaladinPower
{
    public override PowerType Type => PowerType.Debuff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterSideTurnStart(CombatSide side, CombatState combatState)
    {
        BurnPower burnPower = this;
        if (side != burnPower.Owner.Side)
            return;
        burnPower.Flash();
        IEnumerable<DamageResult> damageResults = await CreatureCmd.Damage((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), burnPower.Owner, (Decimal) burnPower.Amount, ValueProp.Unblockable | ValueProp.Unpowered, (Creature) null, (CardModel) null);
    }
}