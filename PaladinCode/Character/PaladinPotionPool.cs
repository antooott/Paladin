using BaseLib.Abstracts;
using Paladin.PaladinCode.Extensions;
using Godot;

namespace Paladin.PaladinCode.Character;

public class PaladinPotionPool : CustomPotionPoolModel
{
    public override Color LabOutlineColor => Paladin.Color;


    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
}