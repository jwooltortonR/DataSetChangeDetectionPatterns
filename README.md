# DataSet Change Detection Patterns
An implementation for the various patterns for identifying changes in DataSets.   

##Patterns:
* ChangingStatus
* KeyColumnHash
* BruteForceFullTable

## Intro.

When working on various software projects I regularly come across a requirement for some level of change information to be provided on a datasource.  Whether 
it is a simple csv file that's regularly received or a table in a database where CDC/Change tracking isn't possible.   This repository is an attempt 
at putting some of these strategies into an easy to use package.  Each approach has pros and cons, depending on the size, complexity, quality and regularity
of the data.  

## Getting Started

