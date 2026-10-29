using BaseLib.Extensions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using Paladin.PaladinCode.Powers;

namespace Paladin.PaladinCode.Cards.Uncommon;

public class Aid : PaladinCard
{
    public Aid() : base(2, CardType.Skill, CardRarity.Uncommon, TargetType.AllAllies)
    {
        WithPower<PlatingPower>(3);
        WithPower<SpellSlotPower>(1);
        WithKeyword(CardKeyword.Exhaust);
        WithKeyword(PaladinKeywords.Spell);
    }

    public override CardMultiplayerConstraint MultiplayerConstraint => CardMultiplayerConstraint.MultiplayerOnly;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CommonActions.ApplySelf<SpellSlotPower>(this, -DynamicVars["SpellSlotPower"].BaseValue);
        ICombatState combatState = this.CombatState;
        foreach (Player player in (IEnumerable<Player>)((combatState != null
                     ? (object)combatState.Players
                     : (object)null) ?? (object)Array.Empty<Player>()))
        {
            PlatingPower platingPower = await PowerCmd.Apply<PlatingPower>(choiceContext, player.Creature,
                this.DynamicVars["PlatingPower"].BaseValue, this.Owner.Creature, (CardModel)this);
        }
    }

    protected override bool IsPlayable
    {
        get
        {
            Aid aid = this;
            if (aid.Owner.HasPower<SpellSlotPower>() &&  aid.Owner.Creature.GetPowerAmount<SpellSlotPower>() >= 1)
            {
                return true;
            }
            return false;
        }
    }
    
    protected override void OnUpgrade()
    {
        DynamicVars["PlatingPower"].UpgradeValueBy(1);
    }
}