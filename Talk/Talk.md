# Introduction
Thank you for attending to this workshop about Evolutionary Architectures using .NET to build a solution, and MS Azure to deploy it.  
Today we are going to investigate the difficulties that every developers, or architects, has at the beginning of any project.  
Usually someone comes to us with a request to solve some business problem, and the first thought in our heads is about the architecture.  
We have a lot of possibilities, monolithic, microservices, serverless, SOA, EDA, etc.  
The first problem that we encounter is that at the moment of taking this decision we have the lowest level of knowledge about the domain on which we are going to work.  
In this situation it's easy to make things complicated, but it's complicated to make them simple (Gall's law).  
We will come back on Gall's law later in this workshop.  

# What is Evolutionary Architecture?
A metaphor attempts to describe similarities between two unrelated things in order to clarify their essentials elements. A good example of this is with software architecture. We commonly attempt to describe software architecture by comparing it to the structure of a building.  
The old view is that in both cases are things that, once in place, are very hard to change later. And that's exactly where the building metaphor breaks down.  
Today, the building metaphor for software architecture is no longer a valid one.

> - Incremental: Evolutionary architectures are built one part at a time, with many different increments. Speed to the next increment is key.  
> - Fitness Functions: Every system at different points of their life need to optimize to be "fit" for its environment. Evolutionary architectures make it explicit what "fit" means with as much automation as possible.  
> - Multiple Dimensions: Evolutionary architectures must support both *technical* and *domain* changes.

# Scenario
We will work on this scenario: the CEO of a brewery ask to us to create a system to manage the purchases of the beers by his suppliers, put the beers into the warehouse when the order will be closed, and the send a notification to his customers about the available beers.

# Avoid Ignorance
Back in 2000,Philip Armour published an article called "Five Orders of Ignorance" with subtitle "Viewing software developments as knowledge acquisition and ignorance reduction".
The article identifies file level of it
> - ***The zero level*** (lack of ignorance). It is knowledge; at this level you have most of knowledge and know what to do and how do it.
> - ***The first level*** (lack of knowledge). It is when you don't know something, but you realize and accept this fact.
> - ***The second level*** (lack of awareness). It is when you don't know that you don't know. This level can also be observed when people pretend to have competence the don't possess, and at same time are ignorant of it.
> - ***The third level*** (lack of process). On this level you don't even know how find out about your lack of awareness. Literally, you don't have a way to figure out you don't know that you don't know.
> - ***The fourth level*** (meta-ignorance). It is when you don't know about the five degrees of ignorance.

Ignorance is the opposite of knowledge, The only way to decrease ignorance is to increase understanding.  
A high level of ignorance leads to a lack of knowledge and a misinterpretation of the problem, and therefore increases the chance of building the wrong solution.  
Frequently we take our decision about the solution at the beginning of a project, and this is when we have the least knowledge and the most ignorance. (E. Evans - locking in your ignorance)

Dan North recommends using ***Introducing Deliberate Discovery*** that is, seeking knowledge from the start.  
He suggests that we realize our position of being on at least the second level of ignorance when we start any project.  

## Domain Exploration
Of course we did a Domain Exploration, like an Event Storming. For those who don't know EventStorming, are a series of workshop to aim the exploration of the problem starting from a big picture to the Software Design exploration.  
Why we need to explore the domain with Domain Experts? The lack of understanding always result in a lack of interest.  
What went wrong with requirements?  
Requirements not only focus on the solution and hide problems, but requirements also tend to translate business language to more technical language.  
The more levels of translation that are being added, the less relevant information reaches the receiver without disturbed beyond recognition.  
The translation slows down communication.  
Learning the Domain Language is crucial to establish effective communication between domain experts and developers.  

# EventStorming
EventStorming is a family of workshop united by one principle: the possibility of representing the complexity of the system using Events as a tool for exploration.  
The other key principle is that of exploration on collaboration design with different stakeholders and different interests.  
The three main formats are:
> - Big Picture
> - Process Modeling
> - Software Design

In our EventStorming we can find blue stickies and orange stickies. The first represent the Command inside our domain, and the second the Domain Events. A Command has the purpose to modify the state of our system, more specifically, of the our aggregate. When the state of our aggregate is changed, the aggregate itself raises a DomainEvent; this Domain Event will be used to the ReadModel side to update its database, used to satisfy the query that comes from UI. This pattern is named CQRS + ES, but it's another history.  
As you can see, we use a common language to describe our intentions inside the EventStorming (CreatePurchaseOrder, PurchaseOrderCreated). Specifically, we use a past tense to describe an Event, because a DomainEvents is something that happened! This particular language that we use is named "Ubiquitous Language";  

# Hands On
It's time to get our hands dirty.
So, because software development is a collaborative activity, split up in groups and try to implement a solution to solve the business problem.
You don't need to write the code, but it's important to looking for a solution that can evolve if the business will grow.

# Share
Sharing solutions  
Every group has to share its solution to the other, and explain why they made those choices

# Monolithic vs Microservices
Both, monolithic and microservices, have pros and cons.  
*Monolithic advantages*  
> - Easy Development
> - Performance
> - Simplified testing
> - Easy debugging
> - Easy deploy  

*Microservice advantages*  
> - Agility
> - Flexible scaling
> - Continuous deployment
> - High maintainability and testable
> - Independently deployable
> - Technology flexibility
> - High reliability

Microservices come with a premium:  
> - Team coordination
> - Dealing with failure
> - Eventual Consistency
> - Automating deployments
> - Managing multiple services

# Evolutionary Architecture
Speaking about Evolutionary Architecture involve at least two areas of inquiry: *mechanics and structure*.  
The *mechanics* side concern the engineering practices and verification that allow an architecture to evolve, which overlap architectural governance.  
This covers engineering practices, testing, metrics and a host of other moving parts that make evolving software possible.  
The *structure* side concerns the topology of software systems.  
Do some architecture styles better facilitate building systems that are easier to evolve?  
Are there structural decisions in architecture that should be avoided to make evolution easier?  

Evolutionary architectures are built one part at a time, with many different increments. Speed to the next increment is key.

# Modular Monolithic
***Gall's Law***  
A complex system that works is invariably found to have evolved from a simple system that worked. The inverse proposition also appears to be true:  
A complex system designed from scratch never works and cannot be made to work. You have to stat over, beginning with a working simple system.  
So, after hearing this theorem, are you still confident about starting a new project directly with microservices?  
(John Gall: Systemantics: How Systems Really Work and How They Fail)

# Fitness Functions
Every system at different points of their life need to optimize to be "fit" for its environment. Evolutionary architectures make it explicit what "fit" means with as much automation as possible. 

# Consumer-Driven Contract
For an HTTP API (and other synchronous protocols), this would involve checking that the provider accepts the expected requests, and that it returns the expected responses.  
For a system that uses messages queues, this would involve checking that the provider generates the expected message.

# References
System design is inherently about boundaries (what's in, what's out, what spans, what move between), and about tradeoffs.
It reshapes what is outside, just as it shapes what is inside.
(Ruth Malan)

"As small as possible" ... is almost universally bad advice in software design. Some critical logic is going to cross those boundaries and result in poorly implemented, preventable, workarounds.
(Mathias Verraes)

There are many useful and revealing heuristics for defining the boundaries of a service. Size is one of the least useful.
(Nick Tune)

Coupling defines the components' degrees of freedom
(Michael Nygard)