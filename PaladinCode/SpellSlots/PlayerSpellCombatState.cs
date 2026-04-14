using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Hooks;
using MegaCrit.Sts2.Core.Models;

namespace Paladin.PaladinCode.SpellSlots;

public class PlayerSpellCombatState : PlayerCombatState
{
    public PlayerSpellCombatState(Player player) : base(player)
    {
        this.player = player;}
    public Player player;
    private int _spellslots;
    /*
    public int SpellSlots
    {
        get => this._spellslots;
        set
        {
            if (this._spellslots == value)
                return;
            int stars = this._spellslots;
            this._spellslots = value;
            CombatManager.Instance.History.SpellSlotsModified(this.player.Creature.CombatState, this._spellslots - stars, this.player);
            Action<int, int> starsChanged = this.SpellSlotsChanged;
            if (starsChanged == null)
                return;
            starsChanged(stars, this._spellslots);
        }
    }
    
    public new bool HasEnoughResourcesFor(CardModel card, out UnplayableReason reason)
    {
        int num1 = Math.Max(0, card.EnergyCost.GetWithModifiers(CostModifiers.All));
        int num2 = Math.Max(0, card.GetStarCostWithModifiers());
        int num3 = Math.Max(0, card.GetSpellSlotCostWithModifiers());
        if (num1 > this.Energy && card.CombatState != null && Hook.ShouldPayExcessEnergyCostWithStars(card.CombatState, this.player))
        {
            num2 += (num1 - this.Energy) * 2;
            num1 = this.Energy;
        }
        reason = UnplayableReason.None;
        if (num1 > this.Energy)
            reason |= UnplayableReason.EnergyCostTooHigh;
        if (num2 > this.Stars)
            reason |= UnplayableReason.StarCostTooHigh;
        if (num3 > this.SpellSlots)
            reason |= UnplayableReason.SpellSlotCostTooHigh;
        return reason == UnplayableReason.None;
    }

    public void LoseSpellSlots(Decimal amount)
    {
        this.SpellSlots = !(amount < 0M) ? (int) Math.Max((Decimal) this.SpellSlots - amount, 0M) : throw new ArgumentException("Must not be negative.", nameof (amount));
    }

    public void GainSpellSlots(Decimal amount)
    {
        this.SpellSlots = !(amount < 0M) ? (int) Math.Max((Decimal) this.SpellSlots + amount, 0M) : throw new ArgumentException("Must not be negative.", nameof (amount));
    }
    */
}