# Abstract Factory

## Purpose

An abstract factory provides an interface for creating groups of related objects for clients that utilize those objects' abstractions.

## Application

The key is to identify sets of related objects - not necessarily related in a domain sense, but in any sense - that need to be created by a client. The names of the sets become your concrete factories.

## Review (experience)

For whatever reason, abstract factory has always been difficult for me to wrap my head around. It's just never made sense to me why someone would need this. I've tried coming up with decent use-cases many times in the past to no avail. I think it is because the majority of objects I use come from repositories and applications with anemic domain models.

Even today, I deleted a couple of different ideas before settling on this one. I chose to encapsulate the creation of repositories.

* *Client* - The object that will be utilizing the products created by the whichever factory it uses. In this case, I built a simple `CustomerService` for fetching common collections of data. There would be many screens that require such a service, since customer and contract data would be vital during many business operations. It could be used to populate reports, displays, combo boxes, etc.. It could also be an expensive operation for infrequently changed data, so caching might be desired for oft-refreshed screens. On the other hand, pulling cached values when editing would be incorrect.
* *Abstract Factory* - The `IRepositoryFactory` interface provides a means of creating repositories but returns only the abstractions `IContractRepository` and `ICustomerRepository`.
* *Concrete Factory* - The two `RepositoryFactory` implementations reside in different persistence pseudo-.dlls. They create either all cache or all database repositories.
* *Abstract Product* - The `ICustomerRepository` and `IContractRepository` interfaces. The service just wants to utilize the repositories and the details of their implementations are irrelevant to its operation.
* *Concrete Product* - The sets of related objects here are cache and database `CustomerRepository` and `ContractRepository` implementations.

## Review (pattern)

The abstract factory pattern is extremely simple - and that might be the problem. I know I've solved this problem in poor ways before. For example, I've created a factory for each type of dependent and injected each individual factory instead of just creating one that is responsible for all. I think this comes from not understanding how important it is that the client is the context and it is primarily responsible for the need for this functionality. Grouping create functions by client needs makes everything make sense.

It's also one of many patterns that just feel like enabling "modes of operation" which might cause me to misapply a different pattern. I might not be skilled enough at recognizing its use cases yet.

I do like the clarity of my example though. The client just wants to fetch some data, and it can be done in two different ways. It isn't in control of how the data is fetched - that responsibility lies in the repositories. And it doesn't make any sense to have a cache and database service because the difference in operation is solely at the product/repository level. So even though I am not returning domain objects that interact in different ways, I believe this pattern is appropriate.

It is possible that this pattern would pair very well with application settings. The setting would essentially choose the concrete factory for a service.
