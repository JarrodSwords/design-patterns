# Builder 3

Over the years, the builder design pattern has both fascinated and frustrated me. It's obvious when you consider that this is the third builder entry in this repository. It's possible and even likely that others don't have trouble understanding this pattern at all. I think it's important to acknowledge my personal difficulty here because it's nothing to be ashamed of, despite how many in the profession tend to carry themselves. There isn't anything wrong with not understanding something. And there isn't any need to pretend that it's trivial to understand once you obtain that understanding.

I'm writing this example in an effort to capture my thoughts after struggling through a different problem set brought to me by a friend. And while it's unlikely that more than three sets of eyes ever read it, I believe the learning experience I had here is significant enough to warrant documentation. I learned a lot about this problematic design pattern, the shortcomings of the way software development skills are taught, and the value of cultivating expertise over time.

<p align="center">
 <img src="https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExNmFsbHNrMXI4cmN6YWRyeGdjNm1mNXZ6YzUwN2Zkc2d3ZndnMXQzbSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/8YmZ14DOpivXMuckSI/giphy.gif" />
</p>

## Intent

From *Design Patterns: Elements of Reusable Object-Oriented Software*

> Separate the construction of a complex object from its representation so that the same construction process can create different representations.

What I can say about this summary of the builder pattern's intent, is that it makes sense to me now (on 2025-04-09) but that has not always been the case.
One might read it for the first time and initially think that they understand it. 
It's short, succinct, and there aren't any obscure or difficult words.
But it wouldn't surprise me if most developers are somewhat lost after reading this the first time.

I'm going to break this down as much as I can.

> Separate the construction of a complex object from its representation...

> ...a complex object...

> ...its representation...

> ...so that the same construction process can create different representations.

> ...the same construction process...

> ...different representations.

## Step by Step

## Motivation



## The desperate need for some kind of realistically complex real world example

- [ ] What classifies as "a complex object?"
  - I think the intended meaning here is something along the lines of "a non-trivial object to instantiate"
  - But I think it is more accurate to just say, a domain object, entity, aggregate, etc.
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
