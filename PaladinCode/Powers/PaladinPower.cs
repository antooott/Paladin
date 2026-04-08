using BaseLib.Abstracts;
using BaseLib.Extensions;
using Paladin.PaladinCode.Extensions;
using Godot;

namespace Paladin.PaladinCode.Powers;

public abstract class PaladinPower : CustomPowerModel
{
    //Loads from Paladin/images/powers/your_power.png
    public override string CustomPackedIconPath
    {
        get
        {
            var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PowerImagePath();
            return ResourceLoader.Exists(path) ? path : "power.png".PowerImagePath();
        }
    }

    public override string CustomBigIconPath
    {
        get
        {
            var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigPowerImagePath();
            return ResourceLoader.Exists(path) ? path : "power.png".BigPowerImagePath();
        }
    }
}