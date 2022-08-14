# UselessApi (also known as ThoughtfulApi) is an Api that thinks.

## CORE FUNCTIONALITY

You can ask UslessApi to remember thoughts (strings).

You can retrieve the lastest thought.

You can replace the latest thought with a different thought.

You can delete the latest thought. This makes an older thought the latest thought (stack data structure).

You can get a random inspirational quote, to help you think of better thoughts.

## FREQUENTLY ASKED QUESTIONS:
### Is there one ontroller that implements CRUD operations?
Yes, see MemoryController.cs

### Does it make a call to another Api?
Yes, it makes a call to quotable quotes (https://github.com/lukePeavey/quotable)

### Does UselessApi have two different configuration files that produce a notible change in how the project is run?
Yes. There are two different configuration files that dictate what kind of information is polled from the API.

appsettings.Development.json -> Limits the API calls to retrieve small quotes only

appsettings.Production.json -> Limits the API calls to retrieve tech quotes only

### How does middleware via DI (dependancy injection) simplify your code?
I used the middle ware: SwashBuckle, via dependancy injection. It provided a framework for documentation 
and a easy way to present my API. This greatly simplified my code as I was able to abstract 
these tasks to it, rather than messily implement it myself. 

To clarify, the project just needs to be built/run and it will display all the API details + documentation.

### Do you use at least one substitute to test your code?
Yes, I used NSubstitute to create a substitute for the controller that accessed the API (QuoteController.cs)
I was able to test if my system for storing thoughts (strings) could take data that came from the API.

### Why did the middleware libraries make your code easier to test?
I was able to confirm the core functionality of my API, the CRUD requests, pretty easily through the SwashBuckle middleware.
This made it much easier to test, as I did not need to write test cases for what I was able to determine through SwashBuckle.
Using middleware also limited the amount of code I created which in turn means I need to write fewer test cases.
