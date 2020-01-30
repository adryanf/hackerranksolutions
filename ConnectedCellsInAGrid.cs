using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the connectedCell function below.
    static int connectedCell(int[][] matrix, int n, int m) {
        
        var visited = new bool[n,m];
        var maxCellCount = 0;
        for(var i=0; i<n; i++){
            for(var j=0; j<m; j++) {
                var connectedCellCount = 0;
                var currentCell = matrix[i][j];
                if(currentCell==1 && !visited[i, j]) {
                    Console.WriteLine("1 found at ["+i+"]["+j+"] will enqueue");
                    
                    var neighbourQ = new Queue<Tuple<int,int>>();
                    neighbourQ.Enqueue(new Tuple<int,int>(i,j));

                    while(neighbourQ.Count > 0){
                        var neighbour = neighbourQ.Dequeue();
                        Console.WriteLine("Dequeued ["+neighbour.Item1+"]["+neighbour.Item2+"]");
                        visited[neighbour.Item1,neighbour.Item2] = true;
                        Console.WriteLine("Visited ["+neighbour.Item1+"]["+neighbour.Item2+"]=true");
                        connectedCellCount++;
                        
                        var neighborCoordDifferences = new int[]{-1,0,1};
                        foreach(var neighborCoordDifferenceI in neighborCoordDifferences){
                            foreach(var neighborCoordDifferenceJ in neighborCoordDifferences)                        {  
                                var neighborCoordI = neighbour.Item1+neighborCoordDifferenceI;
                                var neighborCoordJ = neighbour.Item2+neighborCoordDifferenceJ;
                                if(neighborCoordI >= 0 &&
                                    neighborCoordI < n &&
                                    neighborCoordJ >= 0 &&
                                    neighborCoordJ < m &&
                                    !visited[neighborCoordI, neighborCoordJ] &&
                                    matrix[neighborCoordI][neighborCoordJ] ==1)
                                {
                                    Console.WriteLine("Neighbour 1 found at ["+neighborCoordI+"]["+neighborCoordJ+"] will enqueue");
                                    visited[neighborCoordI,neighborCoordJ] = true;
                                    Console.WriteLine("Visited ["+neighborCoordI+"]["+neighborCoordJ+"]=true");
                                    neighbourQ.Enqueue(new Tuple<int,int>(neighborCoordI,neighborCoordJ));
                                }
                            }
                        }
                    }
                }
                maxCellCount = Math.Max(maxCellCount, connectedCellCount);
            }
        }
        
        return maxCellCount;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        int[][] matrix = new int[n][];

        for (int i = 0; i < n; i++) {
            matrix[i] = Array.ConvertAll(Console.ReadLine().Split(' '), matrixTemp => Convert.ToInt32(matrixTemp));
        }

        int result = connectedCell(matrix,n,m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
