using XRL;
using XRL.World;

[PlayerMutator]
public class ExpMutator : IPlayerMutator {
    public void mutate(GameObject player) {
        player.AddPart<ExpPart>();
    }
}

public class ExpPart : IPart {

    public ExpPart() {}

    public override bool WantEvent(int ID, int cascade) {
        return base.WantEvent(ID, cascade) || ID == AwardingXPEvent.ID;
    }

    public override bool HandleEvent(AwardingXPEvent e) {
        if (e.Actor.ToString() != "The Player") {
            return true;
        }
        e.Amount = 0;
        XRL.Messages.MessageQueue.AddPlayerMessage("Culled exp from the player.");
        return true;
    }
}