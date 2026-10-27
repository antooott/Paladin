using Godot;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using System;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Hooks;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Paladin.PaladinCode.Powers;

public sealed class BurnPower : PaladinPower
{
  public override PowerType Type => PowerType.Debuff;

  public override PowerStackType StackType => PowerStackType.Counter;

  public override Color AmountLabelColor => PowerModel._normalAmountLabelColor;

  /// <summary>
  /// <see cref="T:MegaCrit.Sts2.Core.Models.Powers.AccelerantPower" /> makes Poison trigger extra times, but it should never trigger more times than the
  /// amount of Poison we have.
  /// Since the power is applied to players, enemy creatures need to look to them (their opponents) to figure out the
  /// trigger count.
  /// </summary>

  public int CalculateTotalDamageNextTurn()
  {
    Decimal totalDamageNextTurn = 0M;
    for (int index = 0; index < this.Amount; ++index)
    {
      Decimal num2 = Hook.ModifyDamage(this.Owner.CombatState.RunState, this.Owner.CombatState, this.Owner, (Creature) null, (Decimal) (this.Amount - index), ValueProp.Unblockable | ValueProp.Unpowered, (CardModel) null, (CardPlay) null, ModifyDamageHookType.All, CardPreviewMode.None, out IEnumerable<AbstractModel> _);
      totalDamageNextTurn += num2;
    }
    return (int) totalDamageNextTurn;
  }

  public override async Task AfterSideTurnStart(
    CombatSide side,
    IReadOnlyList<Creature> participants,
    ICombatState combatState)
  {
    if (!participants.Contains<Creature>(this.Owner))
      return;
    await this.Trigger();
  }

  /// <summary>
  /// Deals the Poison damage and decrements the stacks, once per <see cref="P:MegaCrit.Sts2.Core.Models.Powers.PoisonPower.TriggerCount" />.
  /// </summary>
  public async Task Trigger()
  {
    IEnumerable<DamageResult> damageResults = await CreatureCmd.Damage((PlayerChoiceContext) new ThrowingPlayerChoiceContext(), this.Owner, (Decimal) this.Amount, ValueProp.Unblockable | ValueProp.Unpowered, (CardModel) null, (CardPlay) null);
    if (this.Owner.IsAlive)
      await Cmd.CustomScaledWait(0.1f, 0.25f);
  }
}
