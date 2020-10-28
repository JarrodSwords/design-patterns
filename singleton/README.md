# Singleton

## Purpose

Ensure only one instance of an object can exist and provide a point of access to it.

## Review (experience)

The singleton pattern isn't particularly deep or interesting.
It is often called an anti-pattern but I've not really agreed with any support of this notion.
It does feels like a code smell though, particularly the way it it accessed.

The implementation is so simple that I included a larger context for demonstrating a possible use case.
Continuing along from my Prototype ideas, I built a Singleton `ItemRepository` that just maintains the list of all available `Items`.
You might need to access this Singleton when creating the different shops around the map.
It could potentially be problematic to have multiple sources of truth when it comes to `Item` creation, so there is only one instance of the repository and the collection it contains.

It is also a reasonable example of how multiple creation patterns can work together to achieve a larger goal.
The `ShopBuilder` constructs `Shop`s.
The `Item`s used to populate the `Shop` inventories are cloned from the Prototypes in the Singleton `ItemRepository`.

## Review (pattern)

### Strengths

* simplicity of implementation of base use case

### Weaknesses

* complexity of implementation for different use cases including multi-threading
* feels like a code smell
* in my experience, usually ends up being unnecessary
* forces hard coupling to client code
