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

    contains(val){
        // initialize runner at root
        let runner = this.root;
        if (this.isEmpty()){
            return false;
        }
        while(runner){
            // if val is found, return true
            if (runner.data == val){
                return true;
            }
            // if val is less than runner, iterate left
            else if(runner.data > val){
                runner = runner.left;
            }
            // if val is greater than runner, iterate right
            else if(runner.data < val){
                runner = runner.right;
            }
        }
        return false;

    }

    containsRecursive(val, runner = this.root){
        // break condition
        if (runner == null){
            return false;
        }
        else if (runner.data == val){
            return true;
        }
        else if(runner.data > val){
            return this.containsRecursive(val, runner.left);
        }
        else if(runner.data < val){
            return this.containsRecursive(val, runner.right);
        }
        
    }

    findRange(){
        let max = this.findMax();
        let min = this.findMin();
        let range = max - min;
        return range;
    }

    // Given a value, insert it into the correct location in the binary search tree
    insert(val){
        // initialize runner at root
        let runner = this.root;
        if (this.isEmpty()){
            var node1 = new Node(val);
            this.root = node1;
            return this
        }
        while(runner){
            // if val is found, return true
            if (runner.data == val){
                var nodeD = new Node(val);
                runner.left = nodeD;
                return this
            }
            // if val is less than runner, iterate left
            if(runner.data > val){
                if(runner.left == null){
                    var nodeL = new Node(val);
                    runner.left = nodeL;
                    return this
                }
                runner = runner.left;
            }
            // if val is greater than runner, iterate right
            else if(runner.data < val){
                if(runner.right == null){
                    var nodeR = new Node(val);
                    runner.right = nodeR;
                    return this
                }
                runner = runner.right;
            }
        }
    }

    // Now that you've solved insert iteratively, write it recursively
    insertRecursive(val, runner = this.root){
        if (this.isEmpty()){
            var node1 = new Node(val);
            this.root = node1;
            return this;
        }
        // if val is found, return true
        if (runner.data == val){
            var nodeD = new Node(val);
            runner.left = nodeD;
            return this;
        }
        // if val is less than runner, iterate left
        if(runner.data > val){
            if(runner.left == null){
                var nodeL = new Node(val);
                runner.left = nodeL;
                return this
            }
            return this.insertRecursive(val, runner.left);
        }
        // if val is greater than runner, iterate right
        else if(runner.data < val){
            if(runner.right == null){
                var nodeR = new Node(val);
                runner.right = nodeR;
                return this
            }
            return this.insertRecursive(val, runner.right);
        }
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

myBST.insert(9);
console.log("Our minimum value is: " + myBST.min());
myBST.insert(60);
console.log("Our maximum value is: " + myBST.max());

myBST.insert(5);
console.log("Our minimum value is: " + myBST.min());
myBST.insert(5);
console.log("Our minimum value is: " + myBST.min());
myBST.insertRecursive(70);
console.log("Our maximum value is: " + myBST.max());

myBST.insert(25);
console.log(myBST.root.left)
myBST.insertRecursive(35);
console.log(myBST.root.right)