using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using Paladin.PaladinCode.Cards;

namespace Paladin.PaladinCode.Cards.Common;

public class Intimidate : PaladinCard
{
    public Intimidate() : base(1, CardType.Skill, CardRarity.Common, TargetType.AllEnemies)
    {
        WithPower<WeakPower>(1);
        WithPower<VulnerablePower>(0);
        WithKeyword(CardKeyword.Exhaust);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        Intimidate intimidate = this;
        await CreatureCmd.TriggerAnim(intimidate.Owner.Creature, "Cast", intimidate.Owner.Character.CastAnimDelay);
        VfxCmd.PlayOnCreatureCenter(intimidate.Owner.Creature, "vfx/vfx_flying_slash");
        
        Decimal weak = (Decimal) DynamicVars["WeakPower"].BaseValue;
        Decimal vul = (Decimal) DynamicVars["VulnerablePower"].BaseValue;
        
        foreach (Creature enemy in (IEnumerable<Creature>) intimidate.CombatState.HittableEnemies)
        {
            WeakPower weakPower = await PowerCmd.Apply<WeakPower>(enemy, weak, intimidate.Owner.Creature, (CardModel) intimidate);
            VulnerablePower vulnerablePower = await PowerCmd.Apply<VulnerablePower>(enemy, vul, intimidate.Owner.Creature, (CardModel) intimidate);
        }

    }

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}