using System;
using System.Collections.Generic;
using System.Text;

namespace CLASSES
{
    class Program
    {
        static void Main(string[] args)
        {
            // nick this is properties!!! the customer Class has two properties
            // id and name right? so you can set them to anything and later
            // call them back!
           
            for (int i = 0; i < 5; i++)
            {
                Customer cust = new Customer();

                cust.SetID(i);
                cust.SetName("Amelio Rosales");

                Console.WriteLine(
                    "ID: {0}, Name: {1}",
                    cust.GetID(),
                    cust.GetName());
            }

        Console.ReadKey();

            

        }
    }
}
public class Customer
{
    private int m_id = -1;

    public int GetID()
    {
        return m_id;
    }

    public void SetID(int id)
    {
        m_id = id;
    }

    private string m_name = string.Empty;

    public string GetName()
    {
        return m_name;
    }

    public void SetName(string name)
    {
        m_name = name;
    }
}

