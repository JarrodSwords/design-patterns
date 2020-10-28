# Prototype

1.
1.
1.

## Purpose

Delegate the creation of a clone to the object being cloned.

## Experience

I got more out of trying the prototype pattern than I was anticipating.

My previous, incorrect impression of prototypes was that they were objects created specifically for the purpose of spawning clones.
I'm not sure if that is a common misconception, but it was how I understood them.
That has always seemed to be a pretty useless thing and the pattern has never interested me.

When would something like that even be necessary?
Maybe it would be useful if you had a huge, monolithic object that you only wanted to create once after pulling data from storage.

Wouldn't this just create a bunch of wasted memory?

### Additional Confusion

Should there be a class for every item in an RPG?
I've asked myself this question multiple times and I feel stupid every time I fail to answer it.

A Mushroom and a Mid Mushroom differ only by their values: name, price, and amount of hit points recovered.
The difference is important, and needs to exist somewhere.

Does this difference exist only in storage?
That seems bizarre.
Should I really have to hit a storage every time I need to create an item?
How would I even know the set of items to choose from in the code?

Does this difference exist in constructors of otherwise empty subclasses of `ConsumableItem`?
That also seems bizarre because the `Mushroom` class wouldn't really describe the set of all mushrooms any better than the `ConsumableItem` class does.
It just exists for initializing the `ConsumableItem` data in its constructor.

To cap off the confusion, all this focus on values makes it seem like we're working with value objects - objects that differ only by their values.
This isn't right.
If I put Mushroom A and Mushroom B on the floor, they are clearly different references since they occupy different spaces.
This makes them entities not value objects.

### Tell Don't Ask

If you look at a Prototype as just an object that *can* clone itself rather than one that *exists to* clone itself, you get a perfect embodiment of the Tell Don't Ask principle.

Tell Don't Ask is the most important development principle I've learned when it comes to writing rich domains.
It is a reminder that classes encapsulate *behavior* as well as data, that classes are collections of objects *and* collections of operations on those objects.

Common ways of obtaining a clone of an object is to feed an existing object's properties into a constructor or object initializer.
Here, you *ask* the target object what its values are and then do the cloning yourself.
Even if you're passing the properties into the target class's constructor, you're still writing the cloning logic because you're deciding what and how to clone.
Aside from this not always being possible (e.g. the target object has internal fields you could be unaware of), this leads to anemic domain models because you are modeling behavior in client code.

Rather than ask the target object about its properties and then using them to create a clone, you can just *tell* a Prototype to clone itself.
Hey Mr. Prototype, give me a clone - please and thank you.
The Prototype conveniently has everything necessary to do this.

Empowering a class to clone itself enriches it as a domain model.
Its expanded capabilities are clearly communicated to all its clients through its expanded interface.
Clients have an easier time working with them because they no longer need to figure out how to obtain a clone.
Cloning code becomes restricted to one location.

### Example

In my example, I tackled the RPG item problem.
I created a `MushroomKingdomShop` that contains a collection of purchasable `Item`s.
These would viewable as a list in the UI.
When the player makes a purchase, they aren't purchasing the exact reference listed in the UI, they're just requesting that the shop give them an instance of the `SelectedItem`.
The shop responds by telling the `SelectedItem` to clone itself in order to fulfill the transaction.

I love it.
There isn't any requirement to access storage to populate values.
There isn't any unnecessary inheritance tree specifying what a Honey Syrup is or how its values are produced.
The `ConcretePrototype`s also exist for more purpose than just cloning themselves.
They are normal instances of domain models and they fulfill the primary purpose of composing the shop's inventory.
They just also happen to be able to clone themselves when necessary.
The Prototypes and clones are entities too, as demonstrated by the final test line.

Two side notes:

This could be taken a step further.
The shop could be a client of a larger list of prototypes, and populate its inventory from this master collection.

From memory, the Prototype implementation is extremely similar to the Memento pattern, though they serve different purposes.

## Review (pattern)

### Strengths

* perfect example of Tell Don't Ask
* encourages rich domain models
* simplicity of implementation
* can be used to prevent unnecessary inheritance trees
* `Clone()` implementations can vary by subclass

### Weaknesses

* currently unaware of any
