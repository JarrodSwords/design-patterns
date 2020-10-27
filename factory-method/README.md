# Factory Method

## Purpose

A factory method allows an object A to defer the creation of another object B to one of A's subclasses.

## Review (experience)

I have at different times thought of the factory method pattern as confusing, useless, or an anti-pattern.

### Confusing

The abstract factory and builder patterns introduce what are essentially services for creating fully-initialized Products for Clients.
The demarcation between these services and the clients they work for is crystal clear.

Despite the simplicity of its implementation, objects' roles in the factory method pattern are a little more convoluted.
Clients (can) still utilize Products created by Creators.
But Creators are often portrayed as depending on, being composed of, or utilizing the Product objects they create as well.
This makes them part-client.
So the objects responsible for creating Products aren't third-party services, but are part of the working model itself.

### Useless vs Anti-pattern

Examples that portray Creators as being composed of Products have been problematic for me, though I understand why others may not have this issue.
I prefer building classes that have private property setters and are fully-initialized on instantiation.
Private property setters enforce encapsulation of the creation process (e.g. no external code can initialize properties).
Fully-initializing instances simplifies external usage because it strongly implies its validity (e.g. you can't have an uninitialized public property).
For the sake of my argument, let's ignore the fact that you could defer a property's initialization to the time of access.

In the dofactory example, a `Document` (Creator) is composed of many `Page`s (Products).
The `Document` constructor calls the factory method which - besides placing a virtual member call in a constructor - seems useless.
I can achieve the same thing by creating the `Page`s in the ConcreteCreator constructors.

Keeping with this example, assuming you don't call the factory method in the constructor, you're now left without a fully-initialized Creator until a client calls the factory method.
This makes it seem like an anti-pattern for two reasons: the partially-initialized Creator and the fact that a client would have to know enough about the initialization process of the Creator to know it *needs* to call the factory method.

### Conclusion

If calling the factory method in a constructor is useless and calling it from a client is an anti-pattern, the question becomes, "Where should I call a factory method?"
I just guessed and said, "as part of a function normally called by a client of the `Creator`, where the client may not even be aware that a `Product` needs to be created."

In my example, one call to the factory method occurs when an `Enemy` receives damage. The `Enemy`'s `ReceiveDamage()` function triggers a recalculation of their next move.
This logic can be different for each ConcreteCreator, which is actually the reason for needing the factory method to be abstract.
For example, the ConcreteCreator `Jinx` uses `ValorUp` to raise his defense after falling below a certain `HitPoint` threshold.

The above is a clear use case for the factory method pattern, but even though it sets a property on the Creator, it didn't necessarily have to.
Since many examples dealt with Creators that were composed with `Product` properties, I decided to also lazily-initialize the `NextMove` property.
If a client decides to use the `NextMove` value before `ReceiveDamage()` has been executed - significant because it's the only other place the factory method is called - it still receives a move determined by the factory method.

I'm quite happy to have found two use cases of the factory method that don't betray my personal values and tendencies.

## Review (pattern)

### Strengths

* simplicity of implementation
    * it's possible most developers have written this pattern without knowing it; it's one of the most basic use cases of inheritance
* strong coupling between ConcreteCreators and their associated ConcreteProducts
    * as opposed to a client attempting to send in the appropriate ConcreteProducts

### Weaknesses

* deceptive; simplicity of implementation gives the false impression of a simple pattern to use
* muddy roles of participants
* numerous poor qualtiy examples floating around the internet
* creation of objects feels like a second responsibility for a ConcreteCreator code smell (but it might not be)
* seems to be of limited, not particularly scalable use
    * abstract factory would be a remedy for at least two problems: needing more than one factory method or having two identical ConcreteCreator factory method implementations
* may not have a place in narrow, reusable domain objects that would be ConcreteCreators
