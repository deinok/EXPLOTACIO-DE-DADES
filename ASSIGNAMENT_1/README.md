1st Assignment : PageRank
=========================
Goal
------------
Your goal is to finish the implementation of the Pagerank algorithm you
have partially implemented in the notebook about Pagerank you have in
the resources in the virtual campus.

Then, you should execute the algorithm with a graph about researchers and their
joint collaborations, that I provide with this assignment, a graph that is studied in
the paper:

     Finding community structure in networks using the eigenvectors of matrices
     by M. E. J. Newman. 
     in: Phys. Rev. E 74, 036104 – Published 11 September, 2006
     DOI: https://doi.org/10.1103/PhysRevE.74.036104 
      
Your program should show the top five researchers of the graph, with
respect to the rank obtained. For each of these top five researchers, it
should also show the vertex integer identifier together with their
corresponding name. For that goal, your program should also
create a RDD (namesRDD), with (key,value) pairs, where the key is the
integer identifier of a vertex and value is the name of the researcher
correponding to that vertex. **All this work must be implemented with
spark transformations (do not sort the results or look for vertices
names with sequential code in the driver)**.

You have the two following "json lines" (jsonl) files with the
description of the graph (you will find them in the PageRank folder
of the Resources of this site):

-   Node names (netscience-v.jsonl): it contains json lines with the
    structure:

    {"PEREZVICENTE, C": 5}

    where the key is the name of a researcher and the value is the corresponding
    vertex integer identifier. Observe that this structure is the
    inverse one of the structure you need for the namesRDD distributed
    dataset.

-   Node links (netscience-e.jsonl): it contains json lines with the
    structure:

    {"3": [4, 5, 6, 7, 3]}

    where the key represents a source vertex integer identifier (i) and
    all the vertices identifiers in the list represent vertices j such
    that there is a directed link from i to j in the graph. Each vertex
    in the graph will have only one such line, so all its target nodes j
    will be found on that single line. Observe that this is actually the
    information needed in each record of the linksRDD distributed data
    set.

Note: The graph I have provided is a version of the original graph I
found in the web:

 https://public.websites.umich.edu/\~mejn/netdata/
 
(but they are in GML format) but I have added a self-loop in each vertex of
the graph, to make our simplified version of the pagerank algorithm to
work in a natural way even in the presence of original vertices with no
outgoing edges.

Requeriments
--------------------------------------
-   (4 points): You must implement in the right way the PageRank
    algorithm, and include plenty of explanatory comments in each step
    of your functions. But you must implement the version actually introduced
    by google, that considers a "damping" factor. This time, at each
    step with probability d the random walk proceeds in the regular way,
    but with probability (1-d) you jump randomly to any node of the graph.
    In that case, the update equation at time t+1 is equal to:

     
πt+1(i)=1−dN+d⋅(∑nodes j that link to iπt(j)1odeg(j))

-   (3 points): You must load the data of the algorithm in RDDs (or
    spark dataframes if you prefer) by implementing a function that
    takes the jsonl files as input, and then it creates in a distributed
    way (with spark transformations) three distributed datasets:
      LinksRDD, namesRDD, and initial RankRDD,
    that are needed by your pagerank algorithm. The
    namesRDD shoud be a dataset of (key,value) pairs, where each key is
    a vertex integer identifier and the value is the corresponding name
    of the researcher.

If you are not able to implement this load function with spark code
(distributed transformations), you will not get these three points. But
the fact that I provide you with "json lines" files, and not with
regular json files can give you a very clear clue about how can you
easily map these jsonl files to the needed RDDs.

-   (3 points): For three different damping factors ({0.7,0.85,1})
    you must show the results for  four different number
    of iterations ({10,20,30,40}), but including the names of the top 
    five researchers of each execution, and make a clear comparison
    between the results of all the executions. Explain what is 
    the effect in the final ranks of all the vertices 
    when the damping factor is decreased. Does it make sense?

Although providing an optimized code (for execution time) is not a goal
of the assignment, a very simple initial configuration of the two input
RDDs can make some difference in the performance when joining the
LinksRDD with the RankRDD in every iteration.

If you ask for the following partitions at the beginning of the
algorithm:

    RankRDD = RankRDD.partitionBy(4)
    LinksRDD = LinksRDD.partitionBy(4).persist()

At least the partitions of LinksRDD will not change in every iteration,
and this will improve the shuffling performed by the join operation.
Also, asking for a low number of partitions is the best option when
running spark in a local computer (not a cluster), using as number of
partitions at most the number of cores you can use in your spark
application.

Then, if you do not force to "collect()" the RankRDD at every iteration,
it also helps the overall performance. But this can be useful when testing
your algorithm but with small/medium size graphs.

In addition, an implementation based on spark dataframes could also gave
you a more optimized application, although the structure based on plain
RDDs is actually quite simple.

 

What to deliver
---------------------------------------------------------
You have to deliver your notebook with the implementation of pagerank
and the different results and  comparisons between them also in
the same notebook. If you prefer, you can deliver your detailed notebook 
(with comments in all the code), but the final explanation and comparison
of results in a separate PDF file.

Specify CLEARLY the name of the TWO/ONE participants of your group.
