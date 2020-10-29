# Prototype

1. [Learning Experience](#learning-experience)
   1. [Previous Experience](#previous-experience)
   1. [Breakthrough](#breakthrough)
   1. [Tell Don't Ask](#tell-dont-ask)
1. [Application](#application)
   1. [Example](#example)
1. [Review](#review)
   1. [Strengths](#strengths)
   1. [Weaknesses](#weaknesses)
1. [References](#references)

## Learning Experience

I got more out of building this demo than I anticipated.
It's a testament to the value of learning-by-doing.

### Previous Experience

The GoF and most common definition I've seen reads:

> Specify the kind of objects to create using a prototypical instance, and create new objects by copying this prototype.

Thanks, I hate it.
It's technically true, but it's also worded so poorly that it doesn't actually convey the purpose of the pattern.

Thoughts provoked by the definition:

> Specify the kind of objects to create...

* *What* specifies the kind of objects to create? This sentence doesn't appear to have a subject.
I'm going to assume an implied "you," which in programming probably means a Client object.
* I'm going to assume "kind" means "type"

> ...using a prototypical instance...

* It seems like a prototypical instance is the component that specifies the kind of object to create, which contradicts my previous assumption.
* What is a "prototypical instance?" Is it just an instance of a Prototype? It kind of sounds like an object that exists specifically for the purpose of cloning.

>...and create new objects by copying this prototype

* At least I understand the second half of the sentence...

You might agree that it's a bad definition or you might blame my reading comprehension.
Either way, I never understood this definition, which means I never understood the pattern or its use cases.
Why would I want an object solely for the purpose of cloning itself?
That seems useless.
The [oodesign page](https://www.oodesign.com/prototype-pattern.html) talks about performance as a motivation, Liskov's Substitution Principle, and hash tables.
What?

All this confusion stunted my interest in the pattern.

### Breakthrough

By chance, I recently discovered [refactoring.guru](https://refactoring.guru/).
It looks nearly identical to [sourcemaking.com](https://sourcemaking.com/), a blog I've known about for awhile.
It even sells the same book, which I'll probably purchase because it's there that I found the alternate definition:

> Prototype is a creational design pattern that lets you copy existing objects without making your code dependent on their classes.

Oh.

### Tell Don't Ask

Tell Don't Ask is the most important development principle I've learned when it comes to building rich domain models.
It is a reminder that classes encapsulate *behavior* as well as data - that classes are collections of objects *and* collections of operations on those objects.
If you look at a Prototype as just an object that *can* clone itself rather than one that *exists to* clone itself, it is the perfect embodiment of the Tell Don't Ask principle.

A client newing up a fresh instance and copying properties is probably the most common way of cloning an object:

```csharp
public void DoSomething(Foo foo)
{
    var clone = new Foo { Bar = foo.Bar };

    // do something with the clone
}
```

In this would-be Client function, in order to clone `foo`, the client *asks* `foo` for its `Bar` value.
The client decides what and how to clone, and this code would potentially be duplicated anywhere this functionality is required.
Worse, it might be impossible for a client to completely clone `foo` since it only has access to its public interface.

The better approach to this problem is to empower `Foo` objects to clone themselves:

```csharp
public void DoSomething(Foo foo)
{
    var clone = foo.Clone();

    // do something with the clone
}
```

This accomplishes several things:
* It enriches the `Foo` class because it adds a behavior that is communicated to its clients through an expanded public interface.
* It simplifies its usage for clients that no longer need to figure out how to obtain clones.
* It restricts cloning logic to `Foo` and its subclasses.

And that's it.
It's barely a pattern.
It's only a creational pattern because that's arbitrarily the content of the function.
You could do this with literally any functionality and call it a pattern by these standards.
The Print Pattern&trade; adds a `Print()` function that delegates the printing of an object to its subclasses... I'm a genius.

## Application

I noticed this great idea in the [Pros and Cons](https://refactoring.guru/design-patterns/prototype#pros-cons) section of refactoring.guru:

> You get an alternative to inheritance when dealing with configuration presets for complex objects.

Wow.

I've asked myself the following question multiple times and have never come up with a satisfying answer:

> Should there be a class for every item in an RPG?

In Super Mario RPG, a Mushroom and a Mid Mushroom are consumable items that differ only by their values (e.g. name, base price, amount of hit points recovered, etc.).

Does this difference exist only in storage?
Are there just different `ConsumableItem` instances that are either Mushrooms or Mid Mushrooms based on their contents?
Does this mean have to hit storage every time I need to create a `ConsumableItem`?

Do I create `Mushroom` and `MidMushroom` classes?
Now I have stronger typing and am decoupled from any storage, but these subclasses don't really describe Mushrooms or Mid Mushrooms any better than the `ConsumableItem` class does.
They just exist for a place to hard code the `ConsumableItem` properties.
Creating subclasses without changing form or behavior seems like a code smell.

### Example

I created a `MushroomKingdomShop` that can list and sell its `Inventory`.
The `Item`s in its inventory would be displayed on the UI.
When the player makes a purchase, we don't move the referenced `Item` to his inventory because the shop still needs it.
The shop clones the `Item` in order to provide the player with an equivalent `Item` and fulfill the transaction.

I love it.
The `Item` instances in the shop are normal domain objects.
They also happen to be able to clone themselves when necessary.
There isn't an unnecessary inheritance tree specifying how each instance is populated.

Note:

This could be taken a step further.
The shop could be a client of a larger list of prototypes.
It could populate its inventory from this master collection.

## Review

The Prototype design pattern is barely a pattern.
It is an application of Tell Don't Ask for the use case of cloning.

### Strengths

* simplicity of implementation
* encourages rich domain models
* can be used to prevent unnecessary inheritance trees
* `Clone()` implementations can vary by subclass

### Weaknesses

* prevalence of bad training materials

### Caveats

* Due to my preference for readonly public properties, I don't think I'll be using the .NET `ICloneable` interface implementation with `Object.MemberwiseClone()` anytime soon.
* Prototype usage (especially with a dedicated constructor) is extremely similar to both the Memento and Builder patterns

## References

* https://dofactory.com/net/prototype-design-pattern
* https://www.oodesign.com/prototype-pattern.html
* https://sourcemaking.com/design_patterns/prototype
* https://refactoring.guru/design-patterns/prototype
