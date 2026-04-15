using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;

namespace Paladin.PaladinCode.Cards.Common;

public sealed class ShieldBreak : PaladinCard
{
    public ShieldBreak()
        : base(1, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
    {
        WithDamage(7);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        ShieldBreak cardSource = this;
        ArgumentNullException.ThrowIfNull((object)cardPlay.Target, "cardPlay.Target");
        await CreatureCmd.TriggerAnim(cardSource.Owner.Creature, "Cast", cardSource.Owner.Character.CastAnimDelay);
        VfxCmd.PlayOnCreatureCenter(cardSource.Owner.Creature, "vfx/vfx_flying_slash");
        await CreatureCmd.LoseBlock(cardPlay.Target, (Decimal)cardPlay.Target.Block);
        AttackCommand attackCommand = await DamageCmd.Attack(cardSource.DynamicVars.Damage.BaseValue)
            .FromCard((CardModel)cardSource).Targeting(cardPlay.Target).WithHitFx("vfx/vfx_attack_slash")
            .Execute(choiceContext);
    }
    protected override void OnUpgrade()
    {
        this.DynamicVars.Damage.UpgradeValueBy(3M);
    } 
}

