# Builder 3

I'm writing this example in an effort to capture my thoughts after struggling through a different problem set brought to me by a friend. And while it's unlikely that more than three sets of eyes ever read it, I believe the learning experience I had here is significant enough to warrant documentation. I learned a lot about this problematic design pattern (for me anyway), the shortcomings of the way software development skills are taught, and the value of cultivating expertise over time.

<p align="center">
 <img src="https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExNmFsbHNrMXI4cmN6YWRyeGdjNm1mNXZ6YzUwN2Zkc2d3ZndnMXQzbSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/8YmZ14DOpivXMuckSI/giphy.gif" />
</p>

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
