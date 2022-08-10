# UselessApi (also known as ThoughtfulApi) is an Api that thinks.

## CORE FUNCTIONALITY

You can ask UslessApi to remember thoughts (strings).

You can retrieve the lastest thought.

You can replace the latest thought with a different thought.

You can delete the latest thought. This makes an older thought the latest thought (stack data structure).

You can get a random inspirational quote, to help you 

## FREQUENTLY ASKED QUESTIONS:
### Does UselessApi have two different configuration files that produce a notible change in how the project is run?
Yes. There are two different configuration files that dictate what kind of information is polled from the API.

appsettings.SmallQuotes.json -> Limits the API calls to retrieve small quotes only

appsettings.TechQuotes.json -> Limits the API calls to retrieve tech quotes only

### How does middleware via DI (dependancy injection) simplify your code?
I used the middle ware: SwashBuckle, via dependancy injection. It provided a framework for documentation 
and a easy way to present my API. This greatly simplified my code as I was able to abstract 
these tasks to it, rather than messily implement it myself. 

### Why did the middleware libraries make your code easier to test?
I was able to confirm the core functionality of my API, the CRUD requests, pretty easily through the SwashBuckle middleware.
This made it much easier to test, as I did not need to write test cases for what I was able to determine through SwashBuckle.
Using middleware also limited the amount of code I created which in turn means I need to write fewer test cases. 

### Does UselessApi make a call to another Api?
Yes it makes a call to quotable quotes (https://github.com/lukePeavey/quotable)


