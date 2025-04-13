# Builder 3

Over the years, the builder design pattern has both fascinated and frustrated me.
It's obvious when you consider that this is the third builder entry in this repository.
It's possible and even likely that others don't have trouble understanding this pattern at all.
I think it's important to acknowledge my personal difficulty here because it's nothing to be ashamed of, despite how many in the profession tend to carry themselves.
There isn't anything wrong with not understanding something.
And there isn't any need to pretend that it's trivial to understand once you obtain that understanding.

I'm writing this example in an effort to capture my thoughts after struggling through a different problem set brought to me by a friend.
And while it's unlikely that more than three sets of eyes ever read it, I believe the learning experience I had here is significant enough to warrant documentation.
I learned a lot about this problematic design pattern, the shortcomings of the way software development skills are taught, and the value of cultivating expertise over time.

<p align="center">
 <img src="https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExNmFsbHNrMXI4cmN6YWRyeGdjNm1mNXZ6YzUwN2Zkc2d3ZndnMXQzbSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/8YmZ14DOpivXMuckSI/giphy.gif" />
</p>

## Motivation

### Domains

A domain can be summarized as the problem set of an application.
An E-commerce app's domain is geared around selling things online.
An appointment domain deals with scheduling or managing appointments.
The domain layer of an application is where architectures such as the Onion Architecture codify the business rules of a particular domain.

### Rich Domains

Rich domain models are perhaps most easily explained by contrasting them with their opposite - anemic domain models.

```csharp
// <remarks>A pale, sickly model</remarks>
public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public List<LineItem> LineItems { get; } = [];
}
```

This `Order` class represents the shape of the data, but nothing else.
We can write entire programs with classes like these.
But it lacks one half of what makes object-oriented programming work - functionality.

> A class is a collection of objects and a collection of operations on those objects.

&mdash; Wayne Gretzky, probably

If we take the advice of that sage hockey player, we can build a richer domain model by encapsulating its functionality as well as its shape.

```csharp
// <remarks>The model she tells you not to worry about</remarks>
public class Order
{
    private List<LineItem> _lineItems = [];

    public Order(Guid id, Guid customerId, params LineItem[] lineItems)
    {
        Id = id;
        CustomerId = customerId;
        foreach (var li in lineItems)
            Add(li);
    }

    public Guid Id { get; }
    public Guid CustomerId { get; }
    public IReadOnlyList<LineItem> LineItems => _lineItems;

    public Order Add(LineItem lineItem)
    {
        if (!_lineItems.Contains(lineItem))
            _lineItems.Add(lineItem);

        return this;
    }
}
```

One of the strengths of this style of model is that it more clearly communicates its functionality as well as its *intent*:
* `Id` and `CustomerId` are immutable so this class isn't about editing them
* the constructor indicates what must be present to instantiate an `Order`
* the `LineItems` property improves encapsulation by preventing clients from manipulating the collection
* the `Add(LineItem)` function indicates that this class controls the process of adding `LineItem`s
  * it also handles the rule that duplicates not be allowed

And while you can apply design patterns to either type of domain, I believe they primarly exist to solve problems in rich domains.

## Intent

From *Design Patterns: Elements of Reusable Object-Oriented Software*

> Separate the construction of a complex object from its representation so that the same construction process can create different representations.

What I can say about this summary of the builder pattern's intent, is that it makes sense to me now (on 2025-04-09) but that has not always been the case.
One might read it for the first time and initially think that they understand it. 
It's short, succinct, and there aren't any obscure or difficult words.
But it wouldn't surprise me if most developers are somewhat lost after reading this the first time.

I'm going to break this down as much as I can.

> Separate the construction of a complex object from its representation...

Looks like it answers *what*.

> ...a complex object...

> ...its representation...

I was long confused about what this actually means.
Does this mean destination `Type`?
Does it mean from its potential source `Type`(s)?

> ...so that the same construction process can create different representations.

Looks like it answers *why*.

> ...the same construction process...

What is the *construction process*?

> ...different representations.

## Step by Step

## The desperate need for some kind of realistically complex real world example

## Problems

The builder is a weird pattern.

### Director

I think the reason why the director seems to be an accessory rather than a core component of the pattern in many examples is because the director's purpose is not clearly explained.
When the intent statement says "the same construction process," I think it is easy to confuse the calls a director makes with the process.
Sometimes a component of a pattern is really just a label for something largely known to be something else.
For example, the commonly used `Client` isn't part of some class hierarchy with the "-Client" suffix - it's just meant to indicate "the thing using the rest of the components of the pattern."
It is ambiguous whether `Director` classes are one of these, or some sort of actual standalone class.
This ambiguity stings a lot here because so much of the rest of the pattern shares the same problem.

Page 100 starting with "But sometimes..." and ending on 101 with "...parent nodes."
If a `Director` is actually just a "thing that calls methods on the builder interface" then I think this is actually incorrect.
This would couple a `Director` to a `ConcreteProduct`.
This would be problematic if you had say, an `OrderRepository` as your directtor, since it would then know the concrete product type under construction.

If a `Director` is more or less like a domain service though, things are more problematic because it would then need to know where the 

```csharp
///<remarks>Peter Jackson</remarks>
public class OrderRepository : IOrderRepository
{
    private IOrderBuilder _builder;

    public IOrderRepository Find(Guid id)
    {
        var order = _context.Order
                    .Include(x => x.LineItems)
                    .SingleOrDefault(x => x.Id == id);

        _builder.Add(new OrderDetails(order));

        foreach (var li in order.LineItems)
            _builder.Add(new LineItemDto(li);

        return this;
    }
}
```

```csharp
///<remarks>Actually Peter Jackson</remarks>
public class Director
{
    private IOrderBuilder _builder;

    
}

///<remarks></remarks>
public class OrderRepository : IOrderRepository
{

}
```

If a `Director` is more like a service, then this is not an issue.
A director would inherently be part of the domain, and the `ConcreteProduct` type would still be encapsulated and out of view of the repository.

If a `Director` is a specific

- [ ] What classifies as "a complex object?"
  - I think the intended meaning here is something along the lines of "a non-trivial object to instantiate"
  - But I think it is more accurate to just say, a domain object, entity, aggregate, etc.
  - The reality? Any object. StringBuilder.
- [ ] What is "its representation?"
  - Its type
- [ ] What does "the same construction process" refer to?
  - The set of methods provided by the abstract builder
  - not the actual sequence of steps

The construction process is not the same as the actual sequence of steps.

- [ ] What types of methods belong on a builder?
  - Instructions do something
    - not necessarily to build part of an aggregate
      - e.g. select current tree node
- [ ] What question does a concrete builder answer?
  - How an explicit type accomplishes a given instruction
    - e.g. create a `LineItem` and then send it to the product's `Add(LineItem)` method
- [ ] What question does a director answer?
  - What is the sequence of calls to make to a builder?
    - e.g.
- [ ] Is it okay for the director to know specifically how to build the product?
  - Yes, for example, how to convert from a collection of database records to the product. The director has explicit knowledge of the source data structure.
- [ ] What is the defining characteristic of a builder?
  - The process by which you call its methods.
    - e.g. depth-first builder
- [ ] How do you know when you need an abstract builder?
  - When the means by which you construct a product is different
    - e.g. depth vs breadth-first builder


<!-- Notes:

Break down the problems with the definitions and examples from prominent design pattern literature, citing examples.

Talk about what question each component of the pattern answers:
  * e.g. the abstract builder deals with how something is built - the possible ways of navigating the construction process as an outsider.
  * possibly add a checklist of questions from the problems section, and check them off as they're answered

rich domain favors restrictions/constraints, such that it communicates intent clearly. ironically, a rich domain is actually "capable" of less than an anemic one.
  * e.g. private constructors, and builders nested in their target product types

Show examples of the different levels of implementing the builder
  * constructor
  * non-rich
  * rich
  * looping
  * n <-> m
  
  * include labeling the pieces at work
  * pros/cons

Possibly answer some of the previous questions I've had.

I want this to be narrative, and to take the reader through the learning process, including failed attempts at the final product.

Also, develop a new way of reflection, using retterer's strategy as a foundation.

Questions I remember having:
  * what's the point of a builder if the sequence of calls you make changes every time?
    * i.e. it doesn't seem to automate anything for the one-off, in-code/memory example
    * then show how this can be applied to record from a database
  *

* order, invoice, 
-->
