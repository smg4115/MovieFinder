# Welcome to MovieRater
This application is meant to give users the ability to leave a review on any movie that currently
resides in our database. The goal of the project was to have tables connected through foreign keys to 
create a cohesive API.  This did not happen.  Therefore, all testing was done in isolation from the other
tables.  Another goal was to make sure each table had basic CRUD functionality.

## How to run the code
The Reviews and Movies tables have been merged into the Develop branch.  This code builds and runs just fine.
Reviews and Develop should have full CRUD functionality.  To access Users and Genres, switch to the branch named 'sam'. 
We weren't sure if we should merge with the main branch if all of the code hadn't been finalized in develop first.

## Tables
The application is built using the following tables (properties included):
1. Users (created by Sam)
- Id (primary key, int)
- Username (string)
- Password (string)
- Confirm Password (string)

2. Genres (Created by Sam)
- Id (primary key, int)
- Name (string)

3. Reviews (Created by Solomon)
- Id (pk int)
- Movie Id (foreign key, int)
- User Id (foreign key, int) 
- Rating (out of 10.0) (double)
- Comment (string)

4. Movies (Created by Mitch)
- Id (primary key, int)
- Title (string)
- Director (string)
- mpaRating (string)
- Genre (foreign key, int)
