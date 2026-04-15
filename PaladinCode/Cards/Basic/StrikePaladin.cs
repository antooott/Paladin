using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Commands;
using Paladin.PaladinCode.Character;

namespace Paladin.PaladinCode.Cards.Basic;

[Pool(typeof(PaladinCardPool))]
public class StrikePaladin : PaladinCard
{
    public StrikePaladin() : base(1, CardType.Attack, CardRarity.Basic, TargetType.AnyEnemy)
    {
        WithDamage(6);
        WithTags(CardTag.Strike);
    }
    
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        StrikePaladin card = this;
        ArgumentNullException.ThrowIfNull((object) play.Target, "cardPlay.Target");
        await DamageCmd.Attack(card.DynamicVars.Damage.BaseValue).FromCard((PaladinCard) card).Targeting(play.Target)
            .WithHitFx("vfx/vfx_attack_blunt", tmpSfx: "blunt_attack.mp3").Execute(choiceContext);
    }

    protected override void OnUpgrade()
    {
        DynamicVars["Damage"].UpgradeValueBy(3m);
    }
}