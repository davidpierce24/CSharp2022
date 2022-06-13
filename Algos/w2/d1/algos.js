// Binary Search Tree

// Nodes
class Node{
    constructor(val){
        this.data = val;
        // all smaller values go to the left
        this.left = null;
        // all larger values go to the right
        this.right = null;
    }
}

class BST {
    constructor(val){
        // this is the same as SLLs head pointer
        // all trees start at the root
        this.root = null;
    }

    // is our tree empty
    isEmpty() {
        return this.root == null;
    }

    // we can find the min very quickly
    min() {
        // start at root
        var runner = this.root;
        // keep going left until we find null
        while(runner.left) {
            runner = runner.left;
        }
        // the node right before null is our value
        return runner.data;
    }

    // we can find the max very quickly
    max() {
        // start at root
        var runner = this.root;
        // keep going left until we find null
        while(runner.right) {
            runner = runner.right;
        }
        // the node right before null is our value
        return runner.data;
    }
}


var myBST = new BST();
console.log("Is my tree empty?");
console.log(myBST.isEmpty());
var node1 = new Node(30);
myBST.root = node1;
console.log("Is my tree empty?");
console.log(myBST.isEmpty());
// console.log(myBST);
var node2 = new Node(20);
var node3 = new Node(40);
var node4 = new Node(10);
var node5 = new Node(50);

myBST.root.right = node3;
myBST.root.left = node2;
myBST.root.left.left = node4;
myBST.root.right.right = node5;
// console.log(myBST);

console.log("Our minimum value is: " + myBST.min());
console.log("Our maximum value is: " + myBST.max());