using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true;
        } else
        {
            if (value < Data)
            {
                if (Left is null)
                {
                    return false;
                }
                else
                {
                    return Left.Contains(value);
                }
                
            } else
            {
                if (Right is null)
                {
                    return false;
                }
                else
                {
                    return Right.Contains(value);
                }
            }

        }

        // return false;
    }

    

    public int GetHeight( int height=1)
    {
        // TODO Start Problem 4
    
        if ( Left is null && Right is null)
        {
            
            return height;
        }
        else
        {
           // Evaluate Left?.GetHeight():
           // If Left is not null, call GetHeight() on it
           // If Left is null, the expression returns null
           // Apply ?? 0:
           // If the result from step 1 is not null, use that value
           // If the result from step 1 is null, use 0 instead

            return Math.Max(Left?.GetHeight(height + 1) ?? 0, Right?.GetHeight(height + 1) ?? 0 );
            
        }
    }
}