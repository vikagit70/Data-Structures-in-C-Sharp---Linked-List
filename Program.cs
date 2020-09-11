using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node
    {
        public string data;
        public Node next;

        public Node(string i)
        {
            data = i; //data
            next = null; //pointer
        }
        public void Print()
        {
            if (next != null)
            {
                Console.Write(data + ",");
                if (next != null)
                {
                    next.Print();
                }
            }
            else
            {
                Console.Write(data);
            }
        }

        public void AddToEnd(string data)
        {
            if (next == null)
            {
                next = new Node(data);
            }
            else
            {
                next.AddToEnd(data);
            }
        }
    }

    public class MyList
    {
        public Node headNode;
        public MyList()
           
        {
            headNode = null;
        }
        public void AddToEnd(string data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else
            {
                headNode.AddToEnd(data);
            }
        }
        public void DeleteNode(string input)
        {
            if (headNode == null) return;
            if (headNode.data == input)
            {
                headNode = headNode.next;
                return;
            }
            Node current = headNode;
            while (current.next != null)
            {
                if (current.next.data == input)
                {
                    current.next = current.next.next;
                    return;
                }
                current = current.next;
            }
        }
        public void AddToBeginning(string data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else
            {
                Node temp = new Node(data);
                temp.next = headNode;
                headNode = temp;
            }
        }

        public void ConsolidatedList ( MyList list1, MyList list2, MyList list3)
        {
            if (list1.headNode == null && list2.headNode == null) return;
            if (list2.headNode == null) list3.Print();
                if (list1.headNode != null && list2.headNode != null)
            {
                if (list1.headNode.next == null)
                {
                    list2.AddToBeginning(list1.headNode.data);
                }
                else
                {
                    list2.AddToBeginning(list1.headNode.data);
                    list1.headNode = list1.headNode.next;
                    ConsolidatedList(list1, list2, list3);
                }
            }
        }
        public void Print()
        {
            if (headNode != null)
            {
                headNode.Print();
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            MyList temp = new MyList();
            MyList tempReversed = new MyList();
            string[] names = new string[]
            {
                "Hasan Minhaj",
                "Nick Jonas",
                "Priyanka Chopra",
                "Angelina Jolie",
                "Varun Dhawan",
                "Zayn Malik",
                "Taylor Swift",
                "Shahrukh Khan",
                "Selena Gomez",
                "Kim Kardashian",
                "Salman Khan",
                "Sonam Kapoor",
                "Kevin Hart",
                "Amitabh Bachchan",
                "Kanye West"
            };

            for (var i = 0; i < names.Length; i++)
            {
                list.AddToEnd(names[i]);
            }
            Console.WriteLine("Hi, Welcome to Tina’s Planning! Here are a few options for the seating arrangement for your event!");
            Console.WriteLine();
            list.Print();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Type the name from the list above following proper letter case who would you like to seat first? ");
            do
            {
                string userInput = Console.ReadLine();
                //validate input 
                if (userInput == "")
                {
                    Console.WriteLine("Input cannot be blank");
                }
                else
                {
                    if (userInput != "finish")
                    {
                        temp.AddToBeginning(userInput);
                        tempReversed.AddToEnd(userInput);
                        list.DeleteNode(userInput);
                        Console.WriteLine();
                        Console.WriteLine("Ok, here’s the new arrangement: ");
                        tempReversed.Print();
                        Console.Write(", ");
                        list.Print();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Who would you like to seat next? ");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Great! Here is the final seating arrangement: ");
                        list.ConsolidatedList(temp, list, tempReversed);
                        list.Print();
                        Console.WriteLine();
                        Console.WriteLine("The End");
                    }
                }
            }
            while (true);
        }
    }
}

