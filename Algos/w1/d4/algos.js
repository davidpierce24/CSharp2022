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
        if (this.head == null) {
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

        // while(runner.next != null) {
        // while(runner != null) {
        // this while runner is the most succint way to write it b/c if the value = null, it will automatically stop
        while (runner) {
            // we need to add the data to the array
            arr.push(runner.data);
            // we NEED to iterate
            runner = runner.next;
        }
        // arr.push(runner.data);
        console.log(arr);
    }

    insertAtBack(val) {
        if (this.isEmpty()) {
            this.head = new Node(val);
        } else {
            var runner = this.head;
            // we need to get to the back
            while (runner.next) {
                runner = runner.next;
            }
            runner.next = new Node(val);
        }
    }
    // Given a value, insert that value as a node at the front of your singly linked list
    insertAtFront(val) {
        var newHead = new Node(val);
        newHead.next = this.head;
        this.head = newHead;
    }

    // Remove and return the head node from your list (remember this means we need a new head)
    removeHead() {
        if (this.isEmpty()) {
            return null;
        } else {
        var oldHead = this.head
        this.head = this.head.next;
        return oldHead
        }
    }

    // EXTRA: calculate the average of all the values in your list (ex: if you list contained the values 3, 5, 2, 7, 3, then your average should come out as 4)
    average() {
        var sum = 0;
        var count = 0;
        var runner = this.head;
        // we need to get to the back
        while (runner) {
            count++
            sum += runner.data
            runner = runner.next;
            // console.log(runner.data)
        }
        return sum/count
    }

        // Given a value, return true or false whether that value is in your list
        // iteration version
    contains(val){
        if (this.isEmpty()) {
            return false;
        } else {
            var runner = this.head;
            // we need to get to the back
            while (runner) {
                console.log(runner.data)
                if(runner.data == val){
                    return true
                }
                runner = runner.next;
                }
                return false
        }
    }

    // recursive version
    containsRecursive(val, runner = this.head){
        if (this.isEmpty()) {
            return false;
        } 
        else {
            if(runner.data == val){
                return true
            } else {
                if(runner.next == null){
                    return false
                } else {
                    return this.containsRecursive(val, runner.next)
                }
                
            }
            
        }
    }

    // If you didn't already come up with the solution recursively, try that now! Or, if you did solve it recursively, how might you do it iteratively? 

    // Remove and return the last value in your list
    removeBack(){
        if (this.isEmpty()) {
        return null;
        } else {
        var runner = this.head;
        // we need to get to the back
        var last 
        while (runner) {
            if(runner.next.next == null){
                last = runner.next.data
                runner.next = null
                return last
                }
            runner = runner.next;
            }
        }
    }

    // Return (don't remove) the second to last value in your list (ex: if your list is 2, 5, 6, 3, 9, you should return 3)
    secondToLast(){
        if (this.isEmpty()) {
            return null;
            }
            var runner = this.head;
            // we need to get to the back
            while (runner.next.next != null) {
                runner = runner.next;
                }
                return runner.data
            }

    // Given a value, remove that value from the list and return true or false whether it was removed
    removeVal(val){
        // your code here
    }
    // Note: how would this code look if you only wanted to remove one instance of the value? How would this code look if you wanted to remove ALL instances of the value? (ie: plan for duplicates)

    // EXTRA: Given ValueA and ValueB, insert a node with ValueA BEFORE the node containing ValueB (this is called a prepend) and return true or false whether it was pre-pended
    prepend(ValA, ValB){
        // your code here
    }
}


var sll = new SLL();
var node1 = new Node(5);
var node2 = new Node(7);
var node3 = new Node(9);
var node4 = new Node(1);
console.log(sll.isEmpty());
// sll.head = node1;
console.log(sll.isEmpty());
// remember the head is a pointer
// the pointer is pointing at a node
// the node has a data and a next value
// so when we represent the node as head, we are able to grab its attributes
// sll.head.next = node2;
// sll.head.next.next = node3;
// sll.head.next.next.next = node4;

sll.insertAtBack(5);
sll.insertAtBack(7);
sll.insertAtBack(9);
sll.insertAtBack(1);
sll.insertAtBack(3);
sll.insertAtBack(11);

console.log(sll)
sll.print();


sll.insertAtFront(4);
console.log(sll)
sll.print();



sll.removeHead()
console.log(sll)
sll.print();


console.log(sll.average())

var sll2 = new SLL();
// var node10 = new Node(5);
sll2.insertAtBack(5);
console.log(sll2.average())

console.log(sll.removeHead())
sll.print();

console.log(sll.containsRecursive(5));

console.log(sll.removeBack())
sll.print();

console.log(sll.secondToLast())