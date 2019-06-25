The sample exposes a simple OData entity set People of entity type Person. The sample implemented a custom aggreation function People.TotalAge.

Following examples can be used to do the test
Get {endpoint}/People?$apply=groupby((Gender), aggregate(Age with People.TotalAge as TotalAge))

Get {endpoint}/People?$apply=aggregate(Age with min as MinAge)

Get {endpoint}/People?$apply=aggregate(UserName with countdistinct as DistinctNameCount)

Get {endpoint}/People?$apply=aggregation($count as PeopleCount)

For more extensive investigation, please go to https://github.com/OData/WebApi. There are test examples under https://github.com/OData/WebApi/tree/master/test/E2ETest/Microsoft.Test.E2E.AspNet.OData/Aggregation


