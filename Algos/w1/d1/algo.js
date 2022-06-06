// Node and SLL classes

// Node class
class Node {
    // pass in a value every time we create a node
    constructor(value) {
        // that value is passed into the data
        this.data = value;
        // we can't assume this node has anything to point to so it starts at null
        this.next = null;
    }
}

// Singly linked list class
class SLL {
    // this creates a list with nothing inside of it
    constructor() {
        this.head = null;
    }

    //we are going to be writing methods that make this class function
    //how do we identify that a singly linked list is empty?
    isEmpty() {
        //If the head is pointing at null, there is nothing in our SLL
        if(this.head == null) {
            // yes, the sll is empty
            return true;
        } else {
            return false;
        }

        // a more efficient way of writing the question
        // return this.head == null
    }
    print() {
        // print all values in our sll
        // we want to push all the values into an array and print out the array
        var arr = [];
        var runner = this.head;
        // we need to use .push to push in the data of the node
        // we want to keepp going until we hit null
        // we don't know how many times we're going to run, so a while loop is the optimal solution
        while(runner.next != null) {
            // we need to add the data to the array
            arr.push(runner.data);
            // we NEED to iterate
            runner = runner.next;
        }
        console.log(arr);
    }
}



var sll = new SLL();
var node1 = new Node(5);
var node2 = new Node(7);
var node3 = new Node(9);
var node4 = new Node(1);
console.log(sll.isEmpty());
sll.head = node1;
console.log(sll.isEmpty());
// remember the head is a pointer
// the pointer is pointing at a node
// the node has a data and a next value
// so when we represent the node as head, we are able to grab its attributes
sll.head.next = node2;
sll.head.next.next = node3;
sll.head.next.next.next = node4;

console.log(sll)
sll.print();
