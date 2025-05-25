using Thread = DesignPatterns.Builder3.Infrastructure.Read._threads.Thread;

namespace DesignPatterns.Builder3.Infrastructure.Read.Spec;

public class WhenFindingAThread
{
    #region Setup

    private readonly IQueryHandler<FindDiscussion> _handler = new FindDiscussionHandler();
    private readonly Thread _thread;

    public WhenFindingAThread()
    {
        var builder = new Thread.Builder();
        var findDiscussion = new FindDiscussion(10, builder);

        _handler.Execute(findDiscussion);

        _thread = builder.GetThread();
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenCommentsAreATree()
    {
    }

    #endregion
}
