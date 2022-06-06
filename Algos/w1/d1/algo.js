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
}

var sll = new SLL();
console.log(sll.isEmpty())