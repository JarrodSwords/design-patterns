# Builder

1. [Learning Experience](#learning-experience)
1. [Review](#review)
   1. [Strengths](#strengths)
   1. [Weaknesses](#weaknesses)
1. [References](#references)

## Learning Experience

The Builder pattern suffers from being woefully underexplained, which is unfortunate for something as convoluted as the Builder pattern.

### Previous Experience

I've had difficulty answering all of the following questions at times:

* Are ConcreteBuilders all supposed to return the same Product type?
* If so, do the created objects differ only by their data?
* Is a client going to utilize the Builder interface or ConcreteBuilders?
* How can I pass arguments to the places they're required?
* What is the purpose of the Director?
* What if the sequence of steps in the Director needs to vary slightly?
* What does adding a ConcreteBuilder accomplish?
* What does adding a different Director build function accomplish?

You can tell by how scattered the questions are, that it is difficult for me to understand the purpose of a pattern from reading articles and looking at examples.
Even if another would argue that the purpose is clearly stated, for me understanding a pattern's purpose is a process of discovery through trial and error.
So here are some answers to the above in the form of tips:



* no, ConcreteBuilders aren't required to return the same Product type
    * do not define a build function in the Builder interface; this saddles the ConcreteBuilders to a Product type
* the created objects *might* only differ by data
    * this possibility probably shouldn't cause you to utilize the builder pattern; I think this is misrepresented in a lot of examples, including DoFactory's
* my current understanding is that the client *should* specify a builder type - even if only through what is injected into the client
    * it doesn't make any sense to have a client that wants something of `Product` type and not care about which builder is being used
* arguments shoudln't go through the Director; if necessary, they can be injected or passed to a ConcreteBuilder on construction
* the Director establishes the sequence of steps that will be taken on Product construction; if this is unimportant, maybe skip implementing one
* reevaluate the build process for a bad abstraction
    * possibly create additional sequences of execution; this might be a bad idea though
* adding a ConcreteBuilder can help you produce a Product with a new process, or a product of a different type
* adding a different Director build function allows for differing sequences of construction



Utilize the Builder pattern to:

* encapsulate one or more configuration sequences
* decouple a configuration sequence from its output type
    * abstract the steps of a configuration sequence
* reduce the complextity of a constructor's body
* simplify a complicated constructor signature
    * by reducing its parameters to a Builder

Consider the Builder pattern when:

* a client needs to be able to specify the Product type
* you notice configuration logic in client code
    * e.g. it makes decisions about which optional parameters to send
* you need to construct an object step-by-step at runtime:
    * make decisions about which construction steps to run based on some input
        * e.g. create a legal document with different sections based on database records

Nuances:

* optionally reduce a Product's constructor to 


* Builder
    * declares the construction process interface
    * does not declare the build function with return type
        * this would restrict the possible Products
        * a generic return type T does not make sense
            * the construction process is not the same for all possible objects T
            * a type constraint would restrict the possible Products to an interface or superclass
        * you are unlikely to be working with a ConcreteBuilder of which you do not know the type
            * e.g. you are unlikely to have a factory that produces an IBuilder as an output
            * you will most likely be creating a specific ConcreteBuilder and using it to get a Product
    * should probably be named for a high-level product
        * since Builder does not correspond to a type or supertype, 
* Product
    * target output of a ConcreteBuilder
    * one-to-many with ConcreteBuilder
    * while builders are likely named for a category of object (e.g. )
* ConcreteBuilder
    * implements the construction process
    * declares the build function for a Product return type
        * not sure when you would want to return like a Product superclass
    * can be made fluent for directorless, uncommon configurations
* Director
    * encapsulates one or more configuration sequences



I'm not going to say I completely understand this pattern right now, but I certainly have a much better appreciation for its power after creating this example.
I'd mostly used this pattern for the purpose of Product constructor simplification - largely ignoring the fact that you could implement multiple ConcreteBuilders.
This example demonstrates the latter very well:

* the Products are different `Battle` objects, based on the specific game implementation
* some common Product properties like `IBattleSystem` and `IProgressionSystem` differ only by value
* some appear to be common Product values but are actually different types altogether
    * e.g. `FinalFantasyX.Party` is actually different than `SuperMarioRpg.Party` and Osrs doesn't even have a party because it has a `Player` instead; despite this, all of these battle participants are created during the `WithParticipants` portion of the build process

Something that still doesn't sit right about this pattern is that the existence of a sequence of creation steps seems to be integral to the primary use case of the pattern, yet the Director - the component that houses said sequence - is the most expendable part of the pattern.
I think if my reading materials hadn't made a big deal about the order or inclusion of all the steps, I'd have said that the Director is useless.
But if you can create one it will prevent you from duplicating all of the specific Builder calls, so maybe that's all it really needs to do to justify its existence.

## Review

* facilitates the construction of complex, immutable Product objects
    * especially when forcing Product construction with a (Concrete)Builder parameter
* simplifies Product class interfaces by eliminating numerous or complicated construtors
* localizes initializaion code
    * keeps Product and client classes clean of initialization code
    * prevents duplicate initialization code in similar Product classes
    * creates logging and error handling opportunities
* prevent developers from forgetting initialization steps or the step order

What code does this prevent the duplication of?
What code becomes isolated?

### Strengths

* ConcreteBuilders can produce Products of any type
* enables clients to specify the desired Product type by selecting an appropriate ConcreteBuilder
* ConcreteBuilders can be created to respond to changes in the build process, available parameters, or return types
* ConcreteBuilders are useful even without a Director for simplifying initialization
* Builders can be fluent
* Builders of particularly complicated Products can theoretically be passed to multiple Directors or Director functions. Similar to the interface segregation principle, Directors can be narrow and utilized by many unrelated Builders.
    * e.g. Combatants, Spells, and Weapons all implement INameable and ICombatStats - create a Director for this part of the construction process

### Weaknesses

* boilerplate creation of ConcreteBuilder and Director in clients
* boilerplate in ConcreteBuilders: duplicating Product properties, creating functions for setting those properties, fluent returns
* difficult to determine use cases
* difficult to define sequences of steps

## References

* https://dofactory.com/net/builder-design-pattern
* https://www.oodesign.com/builder-pattern.html
* https://sourcemaking.com/design_patterns/builder
* https://refactoring.guru/design-patterns/builder
