# WeAreDevelopers-2023
Workshop @ WeAreDevelopers conference in Berlin - 2023

# ModularArchitecture
Starting from a monolithic solution, how we can guarantee that our solution will grow?
The "module" idea is not a new concept. E. Evans also wrote about module, and recently this kind of architecture is growing as a good alternative to microservices.
In this solution you can see a .NET version of monolithic architecture, with relative test to ensure that every module is low coupling with each other.

# Microservices
When the requests grow, we need to scale, not necessary all the solution, but at least just one module. In this case we have to split the monolithic version into microservices.
If we have worked well before, this isn't a complicated task. Here you can find a possible solution that implements the CQRS-ES pattern using a broker and an EventStore.
Before running the projects, you need to start the services (EventStore, MongoDb, RabbitMQ) by running the following docker command in `./Infrastructure/` folder :

    docker-compose up -d

After that you can run the projects from visual studio or visual studio code
