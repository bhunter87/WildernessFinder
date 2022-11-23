# Wilderness Finder
> A serverless React application built around the Explore America API, and leveraging Google Maps API to quickly locate and show directions to the nearest State park, National Park, or National forest.

## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Features](#features)
* [Screenshots](#screenshots)
* [Usage](#usage)
* [Project Status](#project-status)
* [Room for Improvement](#room-for-improvement)



## General Information
- *What* - A web application displaying the closest park(s) to your location! 
- *Why* - I've lived a somewhat adventurous life, and wish that everyone knew that no matter where you are in the country, there is an adventure and wilderness within a short drive!
- *How* - A functionally built React application built with Chakra.ui and axios



## Tools and Technologies Used
- React
- Google Maps API
- Axios


## Features
- Quick and responsive UI
- Location and direction services from anywhere in the world
- Access to every state park, national park, national forest, and other national and state attractions.


## Screenshots
![Demo](WildernessFinder.gif)


## Usage
If you'd like to use the application as-is, you'll need to reach out to me for access to the database! With access, this should be fairly plug and play, assuming you download the dependencies (axios, charka.ui) and have an active Google Cloud account with access to Maps, Places, and Directions APIs 

NOTE: if you would like to use the application as is, without the Explore America API as a backend, you can change the API call to the NPS API and run it with only national parks. I haven't tried this, but it should work perfectly for that if you choose. The above requirements still apply, as well as an active NPS API key


## Project Status
Project is: _in progress_ 

I plan to add more features as I build out the Explore America API


## Room for Improvement

Room for improvement:
- It's not as responsive as I'd like, and I hope to build a stand-alone mobile application (in React Native) which I expect would be used more often than a web application
- I've barely scratched the surface of React's capabilities and imagine there is a good bit of refactoring I can do. 

To do:
- Info windows
- Yelp API with local bars at the end point of your adventure
- Trip planning

