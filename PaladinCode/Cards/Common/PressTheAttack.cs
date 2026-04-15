using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;


#nullable enable
namespace Paladin.PaladinCode.Cards.Common;

public sealed class PressTheAttack : PaladinCard
{
    public PressTheAttack()
        : base(1, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
    {
        WithDamage(10);
    }
    
    private void ReduceCost() => this.EnergyCost.SetThisTurn(0);
    
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        PressTheAttack card = this;
        ArgumentNullException.ThrowIfNull((object) cardPlay.Target, "cardPlay.Target");
        AttackCommand attackCommand = await DamageCmd.Attack(card.DynamicVars.Damage.BaseValue).FromCard((CardModel) card).Targeting(cardPlay.Target).WithHitFx("vfx/vfx_attack_slash").Execute(choiceContext);
    }
    
    public override Task AfterCardEnteredCombat(CardModel card)
    {
        if (card != this || !this.Owner.Creature.HasPower<VigorPower>())
            return Task.CompletedTask;
        this.ReduceCost();
        return Task.CompletedTask;
    }

    public override Task AfterCardPlayedLate(PlayerChoiceContext context, CardPlay cardPlay)
    {
        if (!this.Owner.Creature.HasPower<VigorPower>())
            return base.AfterCardPlayedLate(context, cardPlay);
        this.ReduceCost();
        return base.AfterCardPlayedLate(context, cardPlay);
    }

    public override Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        if (!this.Owner.Creature.HasPower<VigorPower>())
            return base.AfterPlayerTurnStart(choiceContext, player);
        this.ReduceCost();
        return base.AfterPlayerTurnStart(choiceContext, player);
    }

    protected override void OnUpgrade()
    {
        this.DynamicVars.Damage.UpgradeValueBy(4m);
    } 
}