# ASSIGNAMENT_2

## Your work
In this exercise you have to implement in a python notebook using the spark framework:

 
1. The distributed (map/reduce) algorithm  (in notebook "8-Item-to-Items-globalfiltering-recommenders-py3-sshow.ipynb") for computing the cosine similarity of a set of products with negative and positive ratings, using as input information an RDD (or spark dataframe that is also distributed) with ratings with this format:

 
(userID,movieID,rating)


However, you have to implement a version of the algorithm where when reducing the final cosine similarity value you have to save also the number of common users between the two movies being compared. This implies you will have also to add more information in the initial tuple values obtained in the first step of the algorithm. When showing information about the most similar pairs, we will use this information to not consider pairs with a low number of common users.

That is, the format of the final answer computed in the last step of the algorithm should be for each pair of different movies i and j:

                   ((i,j), (cosine similarity between i and j , number of common users between movie i and movie j) )
 

2. The computation of the Cosine Similarity (with the previous algorithm) of all the pairs of movies from the different files you have with this exercise:

filtered100movies.csv

filtered200movies.csv

filtered300movies.csv

filtered400movies.csv

 

Each file contains ratings for a different set of movies, but the ones in a smaller file are always a subset of a file with bigger size. We provide files with different size in case you have some memory issues in your computer, so use the biggest file you are able to use, although during "testing" of your code you can of course use the smallest file, or even any smaller subset of the file filtered100movies.csv.

 

3. Show on the screen the information for the "top 10" most similar pairs among pairs of movies that have **at least 20 common users**, but using the name of the movies you can find in the  movies file.

All the steps should be implemented always with map/reduce operations with spark RDDs/dataframes. Except the last step, when you have to find the name of the movies in the top-ten recommendations.

Present your notebook with plenty of comments in all your functions.


NOTE: The ratings for movies come from a dataset obtained from the smallest dataset from:

https://grouplens.org/datasets/movielens/

But the ratings have been re-scaled from the range [0,5] to the range [-3,2.5].

 

## Some considerations about the distributed algorithm of the slides
 
It is worth noticing that by implementing the mentioned distributed algorithm, you are actually implementing an slightly restricted version of the cosine similarity algorithm. This is due to the users that do not give a rating for a given product. Let's assume that NO rating is encoded with the value "0", as mentioned at the end of the previous section.


Then, in that algorithm, for a given pair of products (movies) (p1,p2) you only consider users that have given a rating for BOTH products, as in the first map-reduce step you map pairs of the kind:

(u,p1,r1), (u,p2,r2)    to   ((p1,p2) , (r1*r2, r_1^2, r_2^2))

So, these pairs are only generated when user u has ratings for both products. But this is the version of consine similarity I want you to implement, do not try to "fix" the algorithm. By using this version of the algorithm, we do not have to worry about the meaning of users that do not give a rating for a movie.

 

## Possible results for the 100 movies set
The actual cosine values obtained can be sensitive to details about how you perform the implementation of the algorithm, so your results could be not exactly equal to the ones I show here, but should not be too different from these ones.

Best 10 pairs when  number of shared users is at least 20:

Cos dist between  Reservoir Dogs (1992) Apocalypse Now (1979)  :  0.926890406845099  #shared users :  75
Cos dist between  Platoon (1986) Usual Suspects, The (1995)  :  0.9269621290884402  #shared users :  42
Cos dist between  Reservoir Dogs (1992) Goodfellas (1990)  :  0.9322477869271819  #shared users :  86
Cos dist between  Star Wars: Episode VI - Return of the Jedi (1983) Star Wars: Episode IV - A New Hope (1977)  :  0.9342673969280977  #shared users :  175
Cos dist between  Reservoir Dogs (1992) Platoon (1986)  :  0.9364700594629586  #shared users :  43
Cos dist between  Platoon (1986) Fargo (1996)  :  0.9374347353342417  #shared users :  43
Cos dist between  Platoon (1986) Pulp Fiction (1994)  :  0.9396928763131717  #shared users :  45
Cos dist between  Raiders of the Lost Ark (Indiana Jones and the Raiders of the Lost Ark) (1981) Indiana Jones and the Last Crusade (1989)  :  0.942606433250396  #shared users :  123
Cos dist between  Platoon (1986) Goodfellas (1990)  :  0.9504490201227582  #shared users :  41
Cos dist between  Star Wars: Episode V - The Empire Strikes Back (1980) Star Wars: Episode IV - A New Hope (1977)  :  0.9560939845339547  #shared users :  190 
 

## Possible results for the 200 movies set
Best 10 pairs when  number of shared users is at least 20:

Cos dist between  Star Wars: Episode VI - Return of the Jedi (1983) Star Wars: Episode IV - A New Hope (1977)  :  0.9342673969280977  #shared users :  175
Cos dist between  Reservoir Dogs (1992) Platoon (1986)  :  0.9364700594629586  #shared users :  43
Cos dist between  Saving Private Ryan (1998) Dirty Dozen, The (1967)  :  0.937431893408025  #shared users :  25
Cos dist between  Platoon (1986) Fargo (1996)  :  0.9374347353342417  #shared users :  43
Cos dist between  Platoon (1986) Pulp Fiction (1994)  :  0.9396928763131717  #shared users :  45
Cos dist between  L.A. Confidential (1997) Citizen Kane (1941)  :  0.941241407642987  #shared users :  38
Cos dist between  Raiders of the Lost Ark (Indiana Jones and the Raiders of the Lost Ark) (1981) Indiana Jones and the Last Crusade (1989)  :  0.942606433250396  #shared users :  123
Cos dist between  Platoon (1986) Goodfellas (1990)  :  0.9504490201227582  #shared users :  41
Cos dist between  From Russia with Love (1963) Dr. No (1962)  :  0.9511897312113419  #shared users :  22
Cos dist between  Star Wars: Episode V - The Empire Strikes Back (1980) Star Wars: Episode IV - A New Hope (1977)  :  0.9560939845339547  #shared users :  190 
 


## Possible results for the 300 movies set
Best 10 pairs when  number of shared users is at least 20:

Cos dist between  Departed, The (2006) Town, The (2010)  :  0.9414987537990535  #shared users :  20
Cos dist between  Raiders of the Lost Ark (Indiana Jones and the Raiders of the Lost Ark) (1981) Indiana Jones and the Last Crusade (1989)  :  0.942606433250396  #shared users :  123
Cos dist between  Apocalypse Now (1979) Deer Hunter, The (1978)  :  0.9448101641608201  #shared users :  28
Cos dist between  Dark Knight, The (2008) Dark Knight Rises, The (2012)  :  0.947214493282615  #shared users :  70
Cos dist between  Platoon (1986) Goodfellas (1990)  :  0.9504490201227582  #shared users :  41
Cos dist between  From Russia with Love (1963) Dr. No (1962)  :  0.9511897312113419  #shared users :  22
Cos dist between  Dark Knight, The (2008) Town, The (2010)  :  0.9530582945523791  #shared users :  20
Cos dist between  Star Wars: Episode V - The Empire Strikes Back (1980) Star Wars: Episode IV - A New Hope (1977)  :  0.9560939845339547  #shared users :  190
Cos dist between  L.A. Confidential (1997) Inception (2010)  :  0.9590191799852237  #shared users :  23
Cos dist between  Dances with Wolves (1990) Inception (2010)  :  0.9599671084408885  #shared users :  23

 

## Possible results for the 400 movies set
Best 10 pairs when  number of shared users is at least 20:

Cos dist between  Singin' in the Rain (1952) Some Like It Hot (1959)  :  0.9523597027619615  #shared users :  22
Cos dist between  Dark Knight, The (2008) Town, The (2010)  :  0.9530582945523791  #shared users :  20
Cos dist between  12 Angry Men (1957) Rear Window (1954)  :  0.9549354516691845  #shared users :  26
Cos dist between  Dial M for Murder (1954) Star Wars: Episode IV - A New Hope (1977)  :  0.95606716870653  #shared users :  20
Cos dist between  Star Wars: Episode V - The Empire Strikes Back (1980) Star Wars: Episode IV - A New Hope (1977)  :  0.9560939845339547  #shared users :  190
Cos dist between  Rear Window (1954) North by Northwest (1959)  :  0.9585497285899834  #shared users :  42
Cos dist between  Blue Velvet (1986) Citizen Kane (1941)  :  0.9585628425477306  #shared users :  20
Cos dist between  L.A. Confidential (1997) Inception (2010)  :  0.9590191799852237  #shared users :  23
Cos dist between  Dances with Wolves (1990) Inception (2010)  :  0.9599671084408885  #shared users :  23
Cos dist between  North by Northwest (1959) Casablanca (1942)  :  0.9613239971430126  #shared users :  36
