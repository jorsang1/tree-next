using System;
using System.Diagnostics;

//
// Welcome to the <<Tree -> next>> kata
//
// We have a tree that is built using the class Node where an instance of the class
// represents a node in the tree. For simplicity, the node has a single data field of
// type int.
//
// Your task is to write the extension method NodeExtensions.Next() to find the next
// element in the tree. Your solution should also contain a unit test to test your
// algorithm. You can write as many helper methods as you want.
// 
// In the Main method, we create an example tree. We then call the method you have to
// implement and show the expected output.
//
// - You are not allowed to make modifications to the class Node itself.
// - Your solution should work for all trees and not just for the example.
// - We favor readability over performance. But we care about performance.
//
// Submission: Please submit your solution within the next days to osk@templafy.com
//
//
namespace TreeNext
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test tree:
            // 
            // 1
            // +-2
            //   +-3
            //   +-4
            // +-5
            //   +-6
            //   +-7
            //
            var root = new Node(
                1,
                new Node(
                    2,
                    new Node(3),
                    new Node(4)),
                new Node(
                    5,
                    new Node(6),
                    new Node(7)));

            // Expected output:
            //
            // 1
            // 2
            // 3
            // 4
            // 5
            // 6
            // 7
            //
            var n = root;
            while (n != null)
            {
                Console.WriteLine(n.Data);
                n = n.Next();
            }

            // Test
            //
            n = root;
            Debug.Assert(n.Data == 1);
            n = n.Next();
            Debug.Assert(n.Data == 2);
            n = n.Next();
            Debug.Assert(n.Data == 3);
            n = n.Next();
            Debug.Assert(n.Data == 4);
            n = n.Next();
            Debug.Assert(n.Data == 5);
            n = n.Next();
            Debug.Assert(n.Data == 6);
            n = n.Next();
            Debug.Assert(n.Data == 7);
            n = n.Next();
            Debug.Assert(n == null);
        }
    }
}