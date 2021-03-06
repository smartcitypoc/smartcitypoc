#  ***APPENDIX B - PROJECT SCENARIOS***

> **Produce a reusable neighborhood model including data input, documented algorithms and dataoutputs utilizing Microsoft Azure. The model should include a visual dashboard that provides ananalysis of the data.**

It is our understanding that The Denver Smart City team would like to design and develop predictive machine learning models to analyze weather, transportation, freight, weather, and neighborhood data models to enable data driven decisions to improve the safety and health of Denver citizens. We decomposed the scenario into two hypothetical use cases as described below.

 - [X] Developed a [Neighborhood Model](https://github.com/smartcitypoc/smartcitypoc/tree/master/Neighborhood-Model) based on available datasets from the City of Denver demographic data to predict crime in a neighborhood.
 - [X] Developed [Real-time Dashboards](https://github.com/smartcitypoc/smartcitypoc/tree/master/Realtime-Analytics) leveraging Azure Stream Analytics, based on events produced by IoT devices such as weather sensors, traffic signals etc. to analyze and improve security, safety and well-being of Denver citizens.


> **Produce a Restful Public API in JSON format that will provide external entities the ability to receivethe data identified above in an industry standard format including the following parameters:**
 `Starting Date (Month, Day, Year)`, `Ending Date (Month, Day, Year)`, `Data Type (transportation, demographic, air quality, demographic, all)`, `Neighborhood (Denver)`

- [X] Public [RESTful APIs](https://github.com/smartcitypoc/smartcitypoc/tree/master/RESTful%20API) were created using Azure functions that conforms to industry standard formats such as JSON to expose Crime and Census Data for public consumption.
