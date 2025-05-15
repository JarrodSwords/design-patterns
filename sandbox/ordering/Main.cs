namespace DesignPatterns.Sandbox.ordering;

public class Main
{
    public void Run()
    {
        var order = new Order();

        order.Add(new LineItem());
        order.Add(new LineItem());
        order.RemoveLineItem(Guid.NewGuid());
        order.Cancel();
    }
}
