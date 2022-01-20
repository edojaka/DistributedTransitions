namespace TwoPhaseCommit.Coordinator.Model
{
    public enum MessageAction
    {
        Prepare,
        Response,
        Commit,
        Abort,
        Ack
    }
}
